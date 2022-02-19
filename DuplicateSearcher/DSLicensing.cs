using System.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
using System.Net;

namespace DuplicateSearcher {
    public class DSLicensing {
        //private consts
        private const string emailAddressFormat = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b";
        private const string base64Format = @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
        private const int trialMaxUsages = 20;
        private const int trialMaxMatches = 100;

        //private static vars
        private static object syncObj = new object();
        private static bool isRegistered = true;
        private static DSEULA eula = new DSEULA();
        private static DSRegister register = new DSRegister();
        private static bool alreadyShowedRegisterWindow = false;
        private static Thread verifyThread = null;
        private static string verificationStatus = "";
        private static int verifyConnectionTimeout = 20000;
        private static int waitTimeForVerifyThread = verifyConnectionTimeout + 1000;
        private static DateTime lastTimeVerifiedLicense = DSSettings.GetSetting("LastTimeVerifiedLicense", default(DateTime));
        private static DateTime lastTimeAttemptedLicenseVerification = DSSettings.GetSetting("LastTimeAttemptedLicenseVerification", default(DateTime));
        private static string verifyAddress = "http://www.duplicatesearcher.com/licensing/verify.php";
        private static bool isVerified = DSSettings.GetSetting("IsLicenseVerified", true);
        private static bool successfullyVerified = false;
        private static int verifyIntervalInHoursWhenAlreadyVerified = 48;
        private static int verifyIntervalInHoursWhenNotVerified = 2;
        private static string computerID = DSSettings.GetSetting("ComputerID", (0).ToString(), false);
        private static bool isVerifying = false;

        // private static properties
        /* instantiate if not created */
        private static Thread VerifyThread {
            get { if (verifyThread == null) verifyThread = new Thread(new ThreadStart(VerifyThreadFunction)); return verifyThread; }
        }

        // public static properties
        /* get the status of the verification */
        public static string VerificationStatus {
            get { return verificationStatus; }
            set { verificationStatus = value; }
        }

        /* returns if it is in the process of verifying */
        public static bool IsVerifying {
            get { return isVerifying; }
            set { isVerifying = value; }
        }

        /* returns whether it was successfully veriifed */
        public static bool SuccessfullyVerified {
            get { return successfullyVerified; }
            set { successfullyVerified = value; }
        }

        /* last time verified */
        public static DateTime LastTimeVerifiedLicense {
            get { return lastTimeVerifiedLicense; }
            set { DSSettings.SaveSetting("LastTimeVerifiedLicense", value); lastTimeVerifiedLicense = value; }
        }

        /* return last time attempted verifcation */
        public static DateTime LastTimeAttemptedVerification {
            get { return lastTimeAttemptedLicenseVerification; }
            set { DSSettings.SaveSetting("LastTimeAttmpetedLicenseVerification", value); lastTimeAttemptedLicenseVerification = value; }
        }

        /* returns if the license code is valid */
        public static bool IsValidLicenseCode {
            get { return ValidateLicenseCode(RegisteredEmailAddress, RegisteredLicenseKey, RegisteredUserName); }
        }

        /* returns if the license code and info has been verified */
        public static bool IsVerified {
            get { StartVerifyLicenseOnInterval(); return isVerified; }
            set {
                isVerified = value;

                /* set isRegisterd ONLY IF isVerified is false... we do not want to set isRegisterd to true only because isVerified is true. */
                if (!isVerified) isRegistered = isVerified;

                DSSettings.SaveSetting("IsLicenseVerified", isVerified);
            }
        }

        /* returns if there is a valid registration */
        public static bool IsRegistered {
            get {
                try {
                    /* first validate the license info if it is not registered */
                    if (!isRegistered) { //cache the result
                        isRegistered = IsValidLicenseCode;

                        /* next check the isverified */
                        if (isRegistered)
                            isRegistered = IsVerified;
                    }
                } catch {
                } // just return false if there is an error

                return true;
                //return isRegistered;
            }
        }

        /* return the stored user name */
        public static string RegisteredUserName {
            get { return DSSettings.GetSetting("RegistrationUserName", "Everyone"); }
        }

        /* return the stored email address */
        public static string RegisteredEmailAddress {
            get { return DSSettings.GetSetting("RegistrationEmailAddress", ""); }
        }

        /* return the stored license key */
        public static string RegisteredLicenseKey {
            get { return DSSettings.GetSetting("RegistrationLicenseKey", ""); }
        }

        /* returns the computer identifier */
        public static string ComputerID {
            get {
                if (computerID.Equals("0")) {
                    computerID = DSUtilities.GetRandomNumber().ToString();
                    DSSettings.SaveSetting("ComputerID", computerID, false);
                }

                return computerID;
            }
        }

        /* returns if the trial has expired */
        public static bool IsTrialExpired {
            get {
                if (GetUsageCount() >= trialMaxUsages)
                    return true;

                return false;
            }
        }

        /* returns trial info */
        public static int TrialMaxUsages {
            get { return trialMaxUsages; }
        }

        /* returns trial info */
        public static int TrialMaxMatches {
            get { return trialMaxMatches; }
        }

        //private static methods
        /* generates a code from a given string - first validates the email address format */
        private static byte[] GetDSHash(string emailAddress) {
            byte[] code;

            SHA1Managed sha = new SHA1Managed();
            code = sha.ComputeHash(Encoding.ASCII.GetBytes(emailAddress));

            return code;
        }

        /* used by the verify thread to verify license */
        private static void VerifyThreadFunction() {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream s = null;

            /* main try catch */
            if (false) {
                try {
                    /* get request object */
                    request = GetHttpRequest(verifyAddress, verifyConnectionTimeout);

                    /* connect */
                    VerificationStatus = "Connecting to license verification server...";
                    response = (HttpWebResponse)request.GetResponse();

                    /* read response */
                    VerificationStatus = "Reading response...";
                    sr = new StreamReader(s = response.GetResponseStream());
                    string responseContent = sr.ReadLine();
                    sr.Close(); s.Close();
                    sr = null; s = null;

                    /* once complete, update the last verified property and status */
                    if (responseContent == null) {
                        VerificationStatus = "No response from server.";
                        SuccessfullyVerified = false;
                    } else {
                        if (responseContent.ToUpper().Equals("SUCCESS")) {
                            VerificationStatus = "Successfully verified license.";
                            SuccessfullyVerified = true;
                            LastTimeVerifiedLicense = DateTime.Now;
                            IsVerified = true;
                        } else {
                            VerificationStatus = "Failed license verification.";
                            SuccessfullyVerified = false;
                            IsVerified = false;
                        }
                    }
                } catch (Exception ex) {
                    VerificationStatus = "Could not verify license: " + ex.Message;
                    DSDebug.PrintException(ex);
                }
            } else {
                IsVerified = true;
            }

            /* second try catch for cleanup */
            try {
                /* queue stop call */
                ThreadPool.QueueUserWorkItem(new WaitCallback(StopVerifyLicense));

                /* clean up */
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (sr != null) sr.Close();
                if (s != null) s.Close();

                /* be sure to se the last attempt time */
                LastTimeAttemptedVerification = DateTime.Now;
            } catch (Exception ex) {
                VerificationStatus = "Could not cleanup the verify thread: " + ex.Message;
                DSDebug.PrintException(ex);
            }
        }

        //public static methods
        /* check to see if we should start */
        public static void StartVerifyLicenseOnInterval() {
            int verifyIntervalInHours = isVerified ? verifyIntervalInHoursWhenAlreadyVerified : verifyIntervalInHoursWhenNotVerified;

            if (IsValidLicenseCode) {
                if (LastTimeVerifiedLicense.AddHours(verifyIntervalInHours) < DateTime.Now)
                    if (LastTimeAttemptedVerification.AddHours(verifyIntervalInHoursWhenNotVerified) < DateTime.Now)
                        StartVerifyLicense();
            }
        }

        /* starts the verify thread */
        public static void StartVerifyLicense() { StartVerifyLicense(false); }
        public static void StartVerifyLicense(bool waitIndefinitelyToComplete) {
            try {
                /* start first */
                if (verifyThread == null) {
                    DSDebug.PrintLine("Starting verify thread.");
                    VerificationStatus = "Starting verification...";

                    VerifyThread.Start();

                    IsVerifying = true;
                }

                /* wait if specified */
                if (waitIndefinitelyToComplete)
                    StopVerifyLicense(true);
            } catch (Exception ex) {
                DSDebug.PrintLine("Could not start verification: " + ex.Message);
            }
        }

        /* stops the thread to verify */
        private static void StopVerifyLicense(object info) { StopVerifyLicense(false); }
        public static void StopVerifyLicense() { StopVerifyLicense(false); }
        public static void StopVerifyLicense(bool waitIndefinitely) {
            try {
                lock (syncObj) {
                    if (verifyThread != null) {
                        DSDebug.PrintLine("Stopping verify thread.");

                        int waitTime = waitIndefinitely ? Timeout.Infinite : waitTimeForVerifyThread;
                        if (!VerifyThread.Join(waitTime))
                            VerifyThread.Abort();

                        IsVerifying = false;

                        verifyThread = null;
                    }
                }
            } catch (Exception ex) {
                DSDebug.PrintLine("Could not join the verify thread: " + ex.Message);
            }
        }

        /* returns the request that is going to post to the website (also to be used for updates */
        public static HttpWebRequest GetHttpRequest(string webAddress, int timeout) {
            StreamWriter sw = null;
            Stream s = null;
            HttpWebRequest request = null;

            try {
                /* generate the post data */
                string postString = "computerID=" + ComputerID;
                postString += "&version=" + Application.ProductVersion;
                postString += "&emailAddress=" + HttpUtility.UrlEncode(RegisteredEmailAddress);
                postString += "&userName=" + HttpUtility.UrlEncode(RegisteredUserName);
                postString += "&licenseCode=" + HttpUtility.UrlEncode(RegisteredLicenseKey);

                /* create request and set params */
                request = (HttpWebRequest)WebRequest.Create(webAddress);
                request.Timeout = timeout;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postString.Length;

                /* write the post data */
                sw = new StreamWriter(s = request.GetRequestStream());
                sw.Write(postString);
                sw.Close(); s.Close();
                sw = null; s = null;
            } catch (Exception ex) {
                if (sw != null) sw.Close();
                if (s != null) s.Close();
                if (request != null) request.Abort();

                throw ex;
            }

            return request;
        }

        /* determines if the app can run */
        public static bool CheckAppStart() {
            bool ret = false;

            if (IsRegistered) {
                ret = true;
            } else {
                if (DSLicensing.IsTrialExpired) {
                    ShowRegistrationWindow();
                    if (DSLicensing.IsRegistered) {
                        ret = true;
                    } else {
                        ret = false;
                        //DSUtilities.Msg("You have exceeded the maximum number of times you may use DuplicateSearcher without registering.\r\nYour trial has expired.\r\nYou must now register before you can use DuplicateSearcher.\r\nPlease run DuplicateSearcher again to register.");
                    }
                } else {
                    ret = true;
                }
            }

            /* increment the usage count */
            DSLicensing.IncrementUsageCount();

            return ret;
        }

        /* called from within the model accessor - might be a better way to handle this */
        public static int HandleMaxMatchCount(int requestedMatches, DSModel model) { return HandleMaxMatchCount(requestedMatches, model, true); }
        public static int HandleMaxMatchCount(int requestedMatches, DSModel model, bool showRegistrationWindow) {
            int countAllowed = 0;

            /* if not registered, determine if register window should be shown */
            if (IsRegistered) {
                countAllowed = requestedMatches;
            } else {
                int maxAllowed = trialMaxMatches - model.TotalNewMatchesRetrieved;

                /* if our maxallowed is less than or equal to 0, then we need to show the registration window at least once */
                if (maxAllowed <= 0) {
                    maxAllowed = 0;

                    /* if we haven't shown the register window, show now */
                    if (!alreadyShowedRegisterWindow && showRegistrationWindow) {
                        ShowRegistrationWindow(false);//non modal
                        alreadyShowedRegisterWindow = true;
                    }
                } else {
                    alreadyShowedRegisterWindow = false;
                }

                /* if the requested count of matches is less than max allowed, allow the requested amount, otherwise, set to max allowed */
                if (requestedMatches < maxAllowed)
                    countAllowed = requestedMatches;
                else
                    countAllowed = maxAllowed;
            }

            return countAllowed;
        }

        /* shows the registration window */
        public static void ShowRegistrationWindow() { ShowRegistrationWindow(true); }
        public static void ShowRegistrationWindow(bool modal) {
            if (modal)
                register.ShowDialog();
            else {
                register.Show();
                register.Activate();
            }
        }

        /* if the registration window is showing, waits on it */
        public static void WaitOnRegistrationWindow() {
            if (register.Visible) {
                register.Visible = false;
                register.ShowDialog();
            }
        }

        /* outputs the public key to the debug console */
        public static void OutputDSPublicKey() {
            DSDebug.PrintLine(DSRSA.AppRSA.ToXmlString(false));
        }

        /* prompts user to accept eula, returns true if already accepted and false if not */
        public static bool CheckEULA() {
            return true; // eula.CheckEULA();
        }

        /* prompts user to accept eula, forces display */
        public static bool ForceCheckEULA() {
            return eula.ForceCheckEULA();
        }

        /* generates the hash for a given license code */
        public static bool ValidateLicenseCode(string emailAddress, string licenseKey, string userName) {
            bool validated = false;

            /* trim the crap */
            emailAddress = emailAddress.Trim();
            userName = userName.Trim();
            licenseKey = licenseKey.Trim();

            /* email and names should always be upper */
            emailAddress = emailAddress.ToUpper();
            userName = userName.ToUpper();

            /* first, the string must match a certain pattern */
            if (System.Text.RegularExpressions.Regex.IsMatch(licenseKey, base64Format)) {
                /* the email address has to be right too */
                if (System.Text.RegularExpressions.Regex.IsMatch(emailAddress.ToLower(), emailAddressFormat)) {
                    byte[] licenseKeyBytes = Convert.FromBase64String(licenseKey);
                    validated = DSRSA.ServerRSA.VerifyData(GetDSHash(emailAddress + userName), new SHA1CryptoServiceProvider(), licenseKeyBytes);
                } else {
                    throw new Exception("Invalid email address format.");
                }
            } else {
                throw new Exception("Invalide license code format.");
            }

            return validated;
        }

        /* saves the registration settings */
        public static void SaveRegistration(string emailAddress, string licenseKey, string userName) {
            DSSettings.SaveSetting("RegistrationEmailAddress", emailAddress.Trim());
            DSSettings.SaveSetting("RegistrationLicenseKey", licenseKey.Trim());
            DSSettings.SaveSetting("RegistrationUserName", userName.Trim());
        }

        /* returns the usage count */
        public static int GetUsageCount() {
            return int.Parse(DSSettings.GetSetting("SUC", "0", false));
        }

        /* increments the usage count */
        public static void IncrementUsageCount() {
            DSSettings.SaveSetting("SUC", (GetUsageCount() + 1).ToString(), false);
        }
    }

    /* handles loading RSA */
    public static class DSRSA {
        private static RSACryptoServiceProvider appRSA = null;
        private static RSACryptoServiceProvider serverRSA = null;

        /* gets the internal server rsa obj */
        public static RSACryptoServiceProvider ServerRSA {
            get {
                if (serverRSA == null)
                    LoadRSA();
                return serverRSA;
            }
        }

        /* gets the internal app rsa */
        public static RSACryptoServiceProvider AppRSA {
            get {
                if (appRSA == null)
                    LoadRSA();
                return appRSA;
            }
        }

        /* loads the RSA values */
        private static void LoadRSA() {
            appRSA = new RSACryptoServiceProvider();
            serverRSA = new RSACryptoServiceProvider();

            appRSA.FromXmlString(DSUtilities.GetEmbeddedResourceString("Resources.License.DuplicateSearcherBothKeys.xml"));
            serverRSA.FromXmlString(DSUtilities.GetEmbeddedResourceString("Resources.License.ServerPublicKey.xml"));
        }
    }
}
