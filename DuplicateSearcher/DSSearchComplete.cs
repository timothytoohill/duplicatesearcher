using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DuplicateSearcher {
    public partial class DSSearchComplete : Form {
        DSModel model = null;

        public DSSearchComplete(DSModel model, Control parent) {
            InitializeComponent();
            this.model = model;
            DSUtilities.CenterControlOnParent(this, parent);
        }

        private void DSSearchComplete_Load(object sender, EventArgs e) {
            try {
                if (model.SearchCompleted)
                    Text = "Search Complete";
                else
                    Text = "Search Stopped";

                StartTime.Text = model.StartTime.ToString();
                EndTime.Text = model.EndTime.ToString();
                TotalMatches.Text = model.TotalNewMatchesRetrieved.ToString();
                TotalMatchingFiles.Text = model.TotalMatchedCount.ToString();
                TotalGroups.Text = model.TotalMatchedGroupCount.ToString();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        private void OkButton_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
