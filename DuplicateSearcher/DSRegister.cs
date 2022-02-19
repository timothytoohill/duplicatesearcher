using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace DuplicateSearcher {
    partial class DSRegister : Form {
        public DSRegister() {
            InitializeComponent();
        }

        private void SetStatus() {
            /* set the status label */
            StatusLbl.Text = "Status: ";
            if (DSLicensing.IsRegistered) {
                StatusLbl.Text += "REGISTERED! Thank you for registering.";
                RegistrationCodeTxt.Enabled = false;
                RegistrationEmailAddressTxt.Enabled = false;
                RegistrationUserNameTxt.Enabled = false;
            } else {
                StatusLbl.Text += "UNREGISTERED; Remaining Usages: " + (DSLicensing.TrialMaxUsages - DSLicensing.GetUsageCount()).ToString();
                if (DSLicensing.IsTrialExpired)
                    StatusLbl.Text += "\r\nYou must register to continue using DuplicateSearcher.";
                else
                    StatusLbl.Text += "\r\nRestricted to " + DSLicensing.TrialMaxMatches.ToString() + " results per search.";
            }

            /* set the message label */
            if (DSLicensing.IsRegistered) {
                MsgLbl.Text = "DuplicateSearcher is registered to " + DSLicensing.RegisteredUserName + " (" + DSLicensing.RegisteredEmailAddress + "). There is no limitation to the number of matches per search, and you can use DuplicateSearcher indefinitely.";

                Msg1Lbl.Visible = false;
                Msg2Lbl.Visible = false;
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;
                Msg3Lbl.Visible = false;
                RegistrationBox.Visible = false;
                CancelBtn.Visible = false;
                RegisterButton.Text = "Ok";
                Height = 200;
            } else {
                if (DSLicensing.IsTrialExpired)
                    MsgLbl.Text = "DuplicateSearcher has been used " + DSLicensing.TrialMaxUsages.ToString() + " times, which is the maximum number of times it can be used before it must be registered.";
                else
                    MsgLbl.Text = "Until DuplicateSearcher is registered, matches are restricted to " + DSLicensing.TrialMaxMatches.ToString() + " per search, and DuplicateSearcher can be used " + DSLicensing.TrialMaxUsages.ToString() + " times. DuplicateSearcher will still search and calculate how many duplicate files you have, but it will not show them.";
            }

            /* set the cancel button text */
            if (DSLicensing.IsTrialExpired && Modal)
                CancelBtn.Text = "Close DuplicateSearcher";
        }

        private void DSRegister_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    e.Cancel = true;
                    Hide();
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            try {
                if (DSLicensing.IsRegistered)
                    Hide();
                else {
                    RegistrationCodeTxt.Text = Regex.Replace(RegistrationCodeTxt.Text, "<.*?>", string.Empty);
                    if (DSLicensing.ValidateLicenseCode(RegistrationEmailAddressTxt.Text, RegistrationCodeTxt.Text, RegistrationUserNameTxt.Text)) {
                        DSLicensing.SaveRegistration(RegistrationEmailAddressTxt.Text, RegistrationCodeTxt.Text, RegistrationUserNameTxt.Text);
                        DSLicensing.StartVerifyLicense();
                        DSUtilities.Msg("Thank you for registering!");
                        Hide();
                    } else {
                        DSUtilities.Msg("The license key or the email address is incorrect.\r\nPlease purchase DuplicateSearcher to obtain a valid license key, or if you have already purchased, please enter the email address, name, and license key again.\r\nClick the '" + CancelBtn.Text + "' button to close the registration window.");
                        Hide();
                    }
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex.Message + "\r\nIf you don't want to register, click the '"+ CancelBtn.Text + "' button to close the registration window.");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            try {
                Hide();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                DSUtilities.HandleLinkLabelClicked(sender);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void DSRegister_Load(object sender, EventArgs e) {
            /* set the status */
            SetStatus();

            if (DSMain.GUI.Visible)
                DSUtilities.CenterControlOnParent(this, DSMain.GUI);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                DSUtilities.HandleLinkLabelClicked(sender);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            try {
                DSUtilities.Launch("http://www.duplicatesearcher.com/");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            try {
                DSUtilities.Launch("http://www.unisoftdevelopments.com/");
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void DSRegister_Activated(object sender, EventArgs e) {
        }
    }
}
