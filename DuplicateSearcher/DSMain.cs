using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DuplicateSearcher {
    class DSMain {
        //private static vars
        private static bool isConsole = false;
        private static DSModel model = null;
        private static DSConsole console = null;
        private static DSGUI gui = null;
        private static DSSplash splash = null;
        private static bool isClosing = false;

        //public properties
        public static bool IsConsole { get { return isConsole; } }
        public static DSModel Model { get { if (model == null) model = new DSModel(); return model; } }
        public static DSConsole Console { get { if (console == null) console = new DSConsole();  return console; } }
        public static DSGUI GUI { get { if (gui == null) gui = new DSGUI(Model, Console); return gui; } }
        public static DSSplash Splash { get { if (splash == null) splash = new DSSplash(); return splash; } }
        public static bool IsAppDieing { get { return isClosing; } set { isClosing = value; } }

        //public methods
        /* entry point for the app */
        [STAThread]
        public static void Main(string[] args) {
            try {
                /* we are starting not dieing */
                IsAppDieing = false;

                /* check to see if is a gui or console and execute accordingly */
                if (Environment.GetCommandLineArgs()[0].ToUpper().IndexOf("GUI") >= 0) 
                    isConsole = false;
                else
                    isConsole = true;

                /* check to see if this is being used for updating */
                if (DSUpdate.ProcessUpdate(args)) {
                } else {
                    /* first check eula and if our trial has expired, then start ds */
                    if (DSLicensing.CheckEULA())
                        if (DSLicensing.CheckAppStart())
                            StartDS(args);
                }

                /* we are killing ourselves now */
                IsAppDieing = true;

                /* kill the licensing and update threads */
                DSLicensing.StopVerifyLicense();
                DSUpdate.StopAutoUpdate();
                DSUpdate.StopUpdate();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* main function to get the app started */
        public static void StartDS(string[] args) {
            if (IsConsole) {
                /* go console */
                Console.Go(args, Model);

                /* don't close if the registration window is showing */
                DSLicensing.WaitOnRegistrationWindow();
            } else {
                /* set visual styles */
                System.Windows.Forms.Application.EnableVisualStyles();

                /* show the splash maybe */
                DoSplash();

                /* checks for updates if auto update is on */
                DSUpdate.CheckStartAutoUpdate();

                /* and show the main window. closing the window exits the app */
                GUI.ShowDialog();
            }
        }

        /* starts the splash screen */
        public static void DoSplash() {
            if (DSSettings.GetSetting("ShowSplash", true)) {
                Splash.ShowNow();
            }
        }

        /* ends the splash screen */
        public static void StopSplash() {
            Splash.DelayClose();
        }
    }
}
