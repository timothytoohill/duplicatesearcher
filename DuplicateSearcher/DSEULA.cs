using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace DuplicateSearcher {
    partial class DSEULA : Form {
        public DSEULA() {
            InitializeComponent();
        }

        private void DSEULA_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    e.Cancel = true;
                    Hide();
                }

            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* call to check if the user has already accepted, and if not, shows form */
        public bool CheckEULA() {
            if (!DSSettings.GetSetting("UserAcceptedLicense", false))
                this.ShowDialog();
            return DSSettings.GetSetting("UserAcceptedLicense", false);
        }

        /* call to check if the user has already accepted, and if not, shows form */
        public bool ForceCheckEULA() {
            DSSettings.SaveSetting("UserAcceptedLicense", false);
            return CheckEULA();
        }

        private void AcceptButton_Click(object sender, EventArgs e) {
            DSSettings.SaveSetting("UserAcceptedLicense", true);
            Hide();
        }

        private void IDontAcceptButton_Click(object sender, EventArgs e) {
            DSSettings.SaveSetting("UserAcceptedLicense", false);
            Hide();
        }

        private void DSEULA_Load(object sender, EventArgs e) {
            try {
                DocBrowser.DocumentText = DSUtilities.GetEmbeddedResourceString("Resources.License.License.htm");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
