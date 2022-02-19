using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace DuplicateSearcher {
    public partial class DSUpdate : Form {
        //private static members
        private static object syncObj = new object();
        private static DSUpdate update = new DSUpdate();
        private static Thread updateThread = null;
        private static Thread autoUpdateThread = null;
        private static string updateStatus = "";
        private static string updateAddress = "http://www.duplicatesearcher.com/update/getUpdateLocation.php";
        private static int updateConnectionTimeout = 10000;
        private static int autoUpdateThreadSleepInterval = 500;
        private static int autoUpdateCheckIntervalInHours = 48;
        private static int autoUpdateAttemptIntervalInHours = 12;
        private static int waitTimeForUpdateThread = updateConnectionTimeout + 1000;
        private static int waitTimeForAutoUpdateThread = autoUpdateThreadSleepInterval + 1000;
        private static bool automaticallyUpdate = DSSettings.GetSetting("AutomaticallyUpdate", true);
        private static DateTime lastTimeUpdated = DSSettings.GetSetting("LastTimeUpdated", default(DateTime));
        private static DateTime lastTimeAttemptedUpdate = DSSettings.GetSetting("LastTimeAttemptedUpdate", default(DateTime));
        private static bool successfullyUpdated = DSSettings.GetSetting("SuccessfullyUpdated", false);
        private static bool isUpdating = false;
        private static bool isStoppingUpdate = false;
        private static bool isAutoUpdating = false;
        private static int updateProcessID = 0;
        private static WebClient webClient = new WebClient();

        // private static properties
        /* instantiate if not created */
        private static Thread UpdateThread {
            get { if (updateThread == null) updateThread = new Thread(new ThreadStart(UpdateThreadFunction)); return updateThread; }
        }

        /* instantiate if not crreated */
        private static Thread AutoUpdateThread {
            get { if (autoUpdateThread == null) autoUpdateThread = new Thread(new ThreadStart(AutoUpdateThreadFunction)); return autoUpdateThread; }
        }

        //public static properties
        /* last time attempted updated */
        public static DateTime LastTimeAttemptedUpdate {
            get { return lastTimeAttemptedUpdate; }
            set { DSSettings.SaveSetting("LastTimeAttemptedUpdate", value); lastTimeAttemptedUpdate = value; }
        }

        /* last time updated */
        public static DateTime LastTimeUpdated {
            get { return lastTimeUpdated; }
            set { DSSettings.SaveSetting("LastTimeUpdated", value); lastTimeUpdated = value; }
        }

        /* flag if update was successful */
        public static bool SuccessfullyUpdated {
            get { return successfullyUpdated; }
            set { successfullyUpdated = value; DSSettings.SaveSetting("SuccessfullyUpdated", successfullyUpdated); }
        }

        /* automatically update */
        public static bool AutomaticallyUpdate {
            get { return automaticallyUpdate; }
            set { 
                DSSettings.SaveSetting("AutomaticallyUpdate", value); 
                automaticallyUpdate = value;
                CheckStartAutoUpdate();
            }
        }

        /* returns the current status */
        public static string Status {
            get { return updateStatus; }
            set { updateStatus = value; }
        }

        /* returns if the update thread is running */
        public static bool IsUpdating {
            get { return isUpdating; }
            set { isUpdating = value; }
        }

        /* returns if the update thread is running */
        public static bool IsAutoUpdating {
            get { return isAutoUpdating; }
            set { isAutoUpdating = value; }
        }

        /* returns if it is waiting to copy the files */
        public static bool IsWaitingToCopyFiles {
            get { return updateProcessID != 0 ? true : false; }
        }

        //public static mehtods
        /* starts the thread to check for updates */
        public static void StartUpdate() { StartUpdate(false); }
        public static void StartUpdate(bool showGUI) {
            try {
                if (updateThread == null) {
                    DSDebug.PrintLine("Starting update thread.");

                    /* clear previous update files */
                    Status = "Cleaning previous update...";
                    KillUpdateProcess();
                    DeleteUpdateFiles();

                    /* start the thread */
                    Status = "Starting update...";
                    UpdateThread.Start();
                    IsUpdating = true;
                }

                /* launch gui */
                if (showGUI) {
                    update.Show();
                    update.Activate();
                }
            } catch (Exception ex) {
                DSDebug.PrintLine("Error starting update: " + ex.Message);
            }
        }

        /* attempts to wait on the update thread */
        private static void StopUpdate(object info) { StopUpdate(false); } // for queuing the call in the thread function
        public static void StopUpdate() { StopUpdate(false); }
        public static void StopUpdate(bool waitIndefinitely) {
            try {
                lock (syncObj) {
                    /* set signalling flag */
                    isStoppingUpdate = true;

                    /* might as well make sure the webClient gets cancelled */
                    webClient.CancelAsync();

                    /* if the update thread is not null, begin the join */
                    if (updateThread != null) {
                        DSDebug.PrintLine("Stopping update thread.");

                        /* wait for thread to die */
                        int waitTime = waitIndefinitely ? Timeout.Infinite : waitTimeForUpdateThread;
                        if (!UpdateThread.Join(waitTime))
                            UpdateThread.Abort();

                        IsUpdating = false;

                        updateThread = null;
                    }

                    /* reset flag */
                    isStoppingUpdate = false;
                }
            } catch (Exception ex) {
                DSDebug.PrintLine("Could not join the update thread: " + ex.Message);
            }
        }

        /* check start auto update */
        public static void CheckStartAutoUpdate() {
            if (!DSMain.IsConsole) {
                if (AutomaticallyUpdate) {
                    StartAutoUpdate();
                } else {
                    StopAutoUpdate();
                }
            }
        }

        /* starts/kills a thread to kick off the update */
        public static void StartAutoUpdate() {
            try {
                /* make sure we don't start autoupdate in console mode */
                if (autoUpdateThread == null) {
                    DSDebug.PrintLine("Starting auto update thread.");
                    AutoUpdateThread.Start();
                    IsAutoUpdating = true;
                }
            } catch (Exception ex) {
                DSDebug.PrintLine("Error starting autoupdate: " + ex.Message);
            }
        }

        /* attempts to wait on the auto update to finish */
        private static void StopAutoUpdate(object info) { StopAutoUpdate(); } // for queuing the call in the thread function
        public static void StopAutoUpdate() {
            try {
                lock (syncObj) {
                    if (autoUpdateThread != null) {
                        DSDebug.PrintLine("Stopping autoupdate thread.");
                        if (!AutoUpdateThread.Join(waitTimeForAutoUpdateThread))
                            AutoUpdateThread.Abort();

                        IsAutoUpdating = false;

                        autoUpdateThread = null;
                    }
                }
            } catch (Exception ex) {
                DSDebug.PrintLine("Could not join the auto update thread: " + ex.Message);
            }
        }

        /* if processupdate was specified on the command line, handle that here */
        public static bool ProcessUpdate(string[] commandLineArgs) {
            int howLongToWaitForProcess = (Timeout.Infinite);

            if (commandLineArgs.Length == 4) {
                if (commandLineArgs[0].ToUpper().Equals("PROCESSUPDATE")) {
                    int processToWaitOn = int.Parse(commandLineArgs[1]);
                    
                    /* if the app exits within that amount of time, perform the file copy */
                    if (System.Diagnostics.Process.GetProcessById(processToWaitOn).WaitForExit(howLongToWaitForProcess)) {
                        string sourcePath = commandLineArgs[2];
                        string destPath = commandLineArgs[3];

                        DSUtilities.CopyDirectory(sourcePath, destPath, true);
                        DSUtilities.DeleteDirectoryRecursively(sourcePath);

                        /* updates the last time updated */
                        LastTimeUpdated = DateTime.Now;
                    }

                    return true;
                }
            }

            return false;
        }

        //private static methods
        /* used by the update thread to check for updates */
        private static void UpdateThreadFunction() {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream s = null;
            string responseContent = "";

            /* main try catch */
            try {
                /* first make sure we are not verifying, then start verify thread */
                Status = "Verifying license...";
                DSLicensing.StopVerifyLicense();
                DSLicensing.StartVerifyLicense(true);
                
                /* check to make sure we verified */
                if (DSLicensing.SuccessfullyVerified) {
                    /* get request object */
                    Status = "Generating update request...";
                    request = DSLicensing.GetHttpRequest(updateAddress, updateConnectionTimeout);

                    /* connect */
                    Status = "Connecting to update server...";
                    response = (HttpWebResponse)request.GetResponse();

                    /* read response */
                    Status = "Reading response...";
                    sr = new StreamReader((s = response.GetResponseStream()));
                    responseContent = sr.ReadLine();
                    sr.Close(); s.Close();
                    sr = null; s = null;

                    /* check to see if we failed */
                    if (responseContent == null) {
                        Status = "No response from server.";
                        SuccessfullyUpdated = false;
                    } else {
                        if (responseContent.IndexOf("UPDATE_LOCATION:") == 0) {
                            string[] updateLocationArray = responseContent.Split(new char[] { ':' }, 2);
                            string updateLocation = updateLocationArray[1];

                            /* we have a location address, now initiate download */
                            Status = "Downloading update...";
                            
                            /* start download if not stopping */
                            if (!isStoppingUpdate) {
                                webClient.DownloadFileAsync(new Uri(updateLocation), GetUpdateFileName());

                                /* wait for download to complete */
                                while (webClient.IsBusy) {
                                    Thread.Sleep(100);
                                }
                            }

                            /* assume success is indicated by the presence of the file */
                            if ((!isStoppingUpdate) && File.Exists(GetUpdateFileName())) {
                                Status = "Extracting update files...";
                                if (ExtractUpdateFiles()) {
                                    Status = "Launching update process...";
                                    if (LaunchUpdateProcess()) {
                                        SuccessfullyUpdated = true;
                                        Status = "Update successfully downloaded. Restart application to complete the update.";
                                    } else {
                                        DeleteUpdateFiles();
                                        Status = "Could not launch the update process. Try again.";
                                        SuccessfullyUpdated = false;
                                    }
                                } else {
                                    DeleteUpdateFiles();
                                    Status = "Could not extract update files. Try again.";
                                    SuccessfullyUpdated = false;
                                }
                            } else {
                                DeleteUpdateFiles();
                                SuccessfullyUpdated = false;
                                Status = "File download was cancelled either by user or the server.";
                            }
                        } else if (responseContent.ToUpper().Equals("VERIFICATION FAILED")) {
                            SuccessfullyUpdated = false;
                            Status = "License verification failed during update.";
                        } else if (responseContent.ToUpper().Equals("FAILED")) {
                            SuccessfullyUpdated = false;
                            Status = "Update failed.";
                        } else if (responseContent.ToUpper().Equals("CURRENT")) {
                            SuccessfullyUpdated = true;
                            Status = Application.ProductName + " version " + Application.ProductVersion + " is up-to-date.";
                        } else {
                            /* whether we performed an update, we made contact with the server and got a response */
                            SuccessfullyUpdated = true;
                            Status = "Unrecognized response from server.";
                        }
                    }
                } else {
                    Status = "Could not successfully verify license.";
                    SuccessfullyUpdated = false;
                }
            } catch (Exception ex) {
                SuccessfullyUpdated = false;
                Status = "Could not update: " + ex.Message;
                DSDebug.PrintException(ex);
            }

            /* second try catch for cleanup */
            try {
                /* queue the stop call */
                ThreadPool.QueueUserWorkItem(new WaitCallback(StopUpdate));

                /* clean up */
                webClient.CancelAsync();
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (sr != null) sr.Close();
                if (s != null) s.Close();

                /* once complete, update the last updated property */
                LastTimeAttemptedUpdate = DateTime.Now;
            } catch (Exception ex) {
                Status = "Could not cleanup the update thread: " + ex.Message;
                DSDebug.PrintException(ex);
            }
        }

        /* used by the auto update feature */
        private static void AutoUpdateThreadFunction() {
            while (AutomaticallyUpdate && !DSMain.IsAppDieing) {
                try {
                    /* if our last update was successful, auto update every autoupdatecheckinveralinhours, otherwise auto update every autoupdatecheckinvervalinhours / 4 */
                    if (LastTimeUpdated.AddHours(autoUpdateCheckIntervalInHours) < DateTime.Now) {
                        if ((!IsWaitingToCopyFiles) && (LastTimeAttemptedUpdate.AddHours(autoUpdateAttemptIntervalInHours) < DateTime.Now))
                            StartUpdate(false);
                    }

                    Thread.Sleep(autoUpdateThreadSleepInterval);
                } catch (Exception ex) {
                    DSDebug.PrintException(ex);
                }
            }

            /* thread clean up */
            try {
                /* queue the stop call */
                ThreadPool.QueueUserWorkItem(new WaitCallback(StopAutoUpdate));
            } catch (Exception ex) {
                DSDebug.PrintLine("Could not clean up autoupdate thread: " + ex.Message);
            }
        }

        /* extract files for update */
        private static bool ExtractUpdateFiles() {
            bool retVal = true;
            return retVal;

            //FileStream zfs = null;
            //ZipInputStream zstream = null;

            //try {
            //    /* first attempt to create our update executable */
            //    File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, GetUpdateExecutableName(), true);

            //    /* create streams from the downloaded zip file update file */
            //    zstream = new ZipInputStream(zfs = File.OpenRead(GetUpdateFileName()));
            //    ZipEntry ze = null;
            //    byte[] data = new byte[2048];
            //    int readAmount = 0;

            //    /* create the update directory */
            //    DirectoryInfo rootDI = new DirectoryInfo(GetUpdateDirectoryPath());
            //    rootDI.Create();

            //    /* while we have entries */
            //    while ((ze = zstream.GetNextEntry()) != null) {
            //        if (ze.IsFile) {
            //            FileInfo fi = new FileInfo(rootDI.FullName + "\\" + ze.Name);
            //            Directory.CreateDirectory(fi.DirectoryName);
            //            FileStream fs = fi.OpenWrite();

            //            /* write file out of zip stream */
            //            while ((readAmount = zstream.Read(data, 0, data.Length)) != 0)
            //                fs.Write(data, 0, readAmount);

            //            fs.Close();
            //        }
            //    }
            //} catch (Exception ex) {
            //    DSDebug.PrintLine(ex.Message);
            //    retVal = false;
            //}

            ///* attempt cleanup */
            //try {
            //    if (zstream != null) zstream.Close();
            //    if (zfs != null) zfs.Close();

            //    File.Delete(GetUpdateFileName());
            //} catch (Exception ex) {
            //    DSDebug.PrintException(ex);
            //    retVal = false;
            //}
            
            //return retVal;
        }

        /* deletes the update files */
        private static void DeleteUpdateFiles() {
            bool cont = true;
            int count = 0;

            /* loop until timeout or continue is false */
            while (cont && (count < 10)) {
                try {
                    if (File.Exists(GetUpdateFileName()))
                        File.Delete(GetUpdateFileName());

                    if (File.Exists(GetUpdateExecutableName()))
                        File.Delete(GetUpdateExecutableName());

                    if (Directory.Exists(GetUpdateDirectoryPath()))
                        DSUtilities.DeleteDirectoryRecursively(GetUpdateDirectoryPath());

                    cont = false;
                } catch {
                    Thread.Sleep(100);
                }
            }
        }

        /* launches the process to perform the update */
        private static bool LaunchUpdateProcess() {
            try {
                string updateExe = GetUpdateExecutableName();
                string updateParameters = "PROCESSUPDATE " + System.Diagnostics.Process.GetCurrentProcess().Id.ToString() + " \"" + GetUpdateDirectoryPath() + "\" \"" + DSUtilities.GetApplicationPath() + "\"";

                updateProcessID = DSUtilities.Launch(updateExe, updateParameters);
            } catch (Exception ex) {
                DSDebug.PrintException(ex);
                return false;
            }

            return true;
        }

        /* kills the update process */
        private static void KillUpdateProcess() {
            if (updateProcessID != 0) {
                Process p = Process.GetProcessById(updateProcessID);
                p.Kill();
                p.WaitForExit();
                updateProcessID = 0;
            }
        }

        /* returns the location to put the update file */
        private static string GetUpdateFileName() {
            return DSUtilities.GetBestWritableOutputPath() + "\\DSUpdate.upd";
        }

        /* returns the location to extract the update files */
        private static string GetUpdateDirectoryPath() {
            return DSUtilities.GetBestWritableOutputPath() + "\\dsupdate";
        }

        /* returns the name of the executeable that will perform the update */
        private static string GetUpdateExecutableName() {
            return DSUtilities.GetBestWritableOutputPath() + "\\DSUpdate.exe";
        }

        //public instance methods 
        /* constructor */
        public DSUpdate() {
            InitializeComponent();
        }

        //private instance methods
        /* handle status update */
        private void StatusTimer_Tick(object sender, EventArgs e) {
            string status = Status;
            string title = "DuplicateSearcher Update";
            int animationSpeed = 100;

            StartButton.Enabled = !DSUpdate.IsUpdating;
            StopButton.Enabled = DSUpdate.IsUpdating;
            StatusProgressBar.Visible = DSUpdate.IsUpdating;

            if (DSLicensing.IsVerifying) {
                if (DSLicensing.VerificationStatus.Length > 0)
                    status = status + "(" + DSLicensing.VerificationStatus + ")";

                title += " - Verifying...";
            }

            if (DSUpdate.IsUpdating) {
                if (StatusProgressBar.MarqueeAnimationSpeed != animationSpeed)
                    StatusProgressBar.MarqueeAnimationSpeed = animationSpeed;
            } else {
                StatusProgressBar.MarqueeAnimationSpeed = 0;
                StatusProgressBar.Value = 0;
                
                if (DSUpdate.SuccessfullyUpdated)
                    title += " - Success";
                else
                    title += " - Failed";
            }

            Text = title;
            StatusLbl.Text = status;
        }

        /* handle form closing */
        private void DSUpdate_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    e.Cancel = true;
                    Hide();
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* handle made visible */
        private void DSUpdate_VisibleChanged(object sender, EventArgs e) {
            try {
                DSUtilities.CenterControlOnParent(this, DSMain.GUI);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* handle close */
        private void CloseButton_Click(object sender, EventArgs e) {
            try {
                Hide();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* handle stopping */
        private void StopButton_Click(object sender, EventArgs e) {
            try {
                StopUpdate();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* handle start */
        private void StartButton_Click(object sender, EventArgs e) {
            try {
                DSUpdate.StartUpdate();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
