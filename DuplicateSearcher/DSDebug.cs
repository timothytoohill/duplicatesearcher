using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DuplicateSearcher {
    public partial class DSDebug : Form {
        private static DSDebug debug = new DSDebug();
        private static Queue<string> messages = new Queue<string>(); //for multithreading messages

        public DSDebug() {
            InitializeComponent();

            DSSettings.GetControl(WordWrapChk);
        }

        private void DSDebug_Load(object sender, EventArgs e) {
            try {
                
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void DSDebug_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    e.Cancel = true;
                    Hide();
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e) {
            try {
                Hide();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void OutputKey_Click(object sender, EventArgs e) {
            try {
                DSLicensing.OutputDSPublicKey();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void WordWrapChk_CheckedChanged(object sender, EventArgs e) {
            try {
                OutputTxt.WordWrap = WordWrapChk.Checked;
                DSSettings.SaveControl(WordWrapChk);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void Output(string text) {
            OutputTxt.AppendText(text);
        }

        public static void Print(string text) {
            lock (messages) {
                messages.Enqueue(text);
            }
        }

        public static void PrintLine(string text) {
            Print(text + "\r\n");
        }

        public static void PrintException(Exception ex) {
            PrintLine(ex.Message);
        }

        public static void ShowDebug() {
            debug.Show();
            debug.Activate();
        }

        private void CheckForNewMessages_Tick(object sender, EventArgs e) {
            try {
                lock (messages) {
                    while (messages.Count > 0)
                        Output(messages.Dequeue());
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
