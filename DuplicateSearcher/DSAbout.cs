using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DuplicateSearcher {
    partial class DSAbout : Form {
        public DSAbout() {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = String.Format("Version {0}", AssemblyVersion);
            this.CopyrightLabel.Text = AssemblyCopyright;
            //this.CompanyNameLabel.Text = AssemblyCompany;
            this.Description.Text = "DuplicateSearcher was created by Timothy Toohill to be an advanced utility for finding duplicate files and folders. One goal of DuplicateSearcher was to output results that could be used by other applications.  The process of identifying duplicates can be complex and time-consuming.  There are many attributes of files and directories that can be compared, and the criteria for identifying a duplicate often depends on the file’s type and contents. DuplicateSearcher enables the user to specify fairly extensive criteria for identifying duplicate files and directories.\r\n\r\nDuplicateSearcher has two operating modes: console and Graphical User Interface (GUI). The console’s executable file is dsc.exe, and the GUI’s executable file is dsgui.exe. Both have the same search capabilities; however, only the GUI supports performing operations on duplicates, such as deleting, moving, or recycling. The GUI makes the criteria easier to specify, and the search results are easier to view. The console makes it easier to integrate the functionality of DuplicateSearcher with other applications. For example, the output from the console could be redirected to a file that is processed by a separate application.\r\n\r\nSee the documentation for more information.";

        }

        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion {
            get {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private void DSAbout_Load(object sender, EventArgs e) {
            if (DSLicensing.IsRegistered) {
                RegistrationStatusLbl.Text = "Registered to: " + DSLicensing.RegisteredUserName; // + " (" + DSLicensing.RegisteredEmailAddress + ")";
            } else
                RegistrationStatusLbl.Text = "UNREGISTERED";
        }

        private void okButton_Click(object sender, EventArgs e) {

        }

        private void CopyrightLabel_Click(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            try {
                DSUtilities.Launch("http://www.Timothy Toohilldevelopments.com/");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void CompanyNameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                DSUtilities.HandleLinkLabelClicked(sender);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                DSUtilities.HandleLinkLabelClicked(sender);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void LogoPictureBox_Click(object sender, EventArgs e) {
            try {
                DSUtilities.Launch("http://www.duplicatesearcher.com/");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
