using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace DuplicateSearcher {
    partial class DSDocumentation : Form {
        public DSDocumentation(DSGUI parent) {
            InitializeComponent();

            /* then load pos */
            DSUtilities.CenterControlOnParent(this, parent);
        }

        private void DSDocumentation_Load(object sender, EventArgs e) {
            try {
                DocBrowser.DocumentText = DSUtilities.GetEmbeddedResourceString("Resources.Documentation.Documentation.htm");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void DSDocumentation_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    e.Cancel = true;
                    Hide();
                }

            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Hide();
        }
    }
}
