using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DuplicateSearcher {
    public partial class DSSplash : Form {
        private string status = "Loading...";

        public DSSplash() {
            InitializeComponent();

            foreach (Control ctl in Controls)
                ctl.Visible = false;

            pictureBox1.Visible = true;
        }

        public void ShowNow() {
            Show();
            
            /* do events for .5 sec */
            int count = 0;
            while (count++ < 5)
                Application.DoEvents();
        }

        public void DelayClose() {
            HideTimer.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            Hide();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            string text = "";

            //main title
            Font font = MainLbl.Font;
            e.Graphics.DrawString("DuplicateSearcher", font, Brushes.Black, MainLbl.Location);

            //description
            font = DescLbl.Font;
            e.Graphics.DrawString("A state of the art utility for finding duplicate files on your computer.", font, Brushes.Black, DescLbl.Location);
            //e.Graphics.DrawImage(pictureBox2.Image, pictureBox2.Bounds);

            //registration status
            font = RegStatusLbl.Font;
            if (DSLicensing.IsRegistered) {
                text = "Registered to: " + DSLicensing.RegisteredUserName; // + " (" + DSLicensing.RegisteredEmailAddress + ")";
            } else {
                text = "UNREGISTERED";
            }
            e.Graphics.DrawString(text, font, Brushes.Black, GetRightAlignedPosition(RegStatusLbl, e.Graphics, font, text));

            //registration conditions
            font = RegInfoLbl.Font;
            if (DSLicensing.IsRegistered) {
                text = "Unlimited matches and uses.";
            } else {
                text = "Usages remaining: " + (DSLicensing.TrialMaxUsages - DSLicensing.GetUsageCount()).ToString() + ", and " + DSLicensing.TrialMaxMatches.ToString() + " matches per search";
            }
            e.Graphics.DrawString(text, font, Brushes.Black, GetRightAlignedPosition(RegInfoLbl, e.Graphics, font, text));

            //loading message
            font = LoadingMsgLbl.Font;
            text = status;
            e.Graphics.DrawString(text, font, Brushes.Black, GetRightAlignedPosition(LoadingMsgLbl, e.Graphics, font, text));
            
        }

        private Point GetRightAlignedPosition(Control ctl, Graphics g, Font font, string text) {
            Point p = new Point();
            p.X = (ctl.Left + ctl.Width) - (int)g.MeasureString(text, font).Width;
            p.Y = (ctl.Top + (ctl.Height / 2)) - ((int)g.MeasureString(text, font).Height / 2);
            return p;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Hide();
        }

        public void SetStatus(string statusText) {
            status = statusText;
            Refresh();
        }
    }
}
