namespace DuplicateSearcher {
    partial class DSSearchComplete {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.OkButton = new System.Windows.Forms.Button();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.Label();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.TotalMatchingFilesLabel = new System.Windows.Forms.Label();
            this.TotalMatchingFiles = new System.Windows.Forms.Label();
            this.TotalGroups = new System.Windows.Forms.Label();
            this.TotalGroupsLabel = new System.Windows.Forms.Label();
            this.TotalMatchesLabel = new System.Windows.Forms.Label();
            this.TotalMatches = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(109, 180);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(12, 23);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.StartTimeLabel.TabIndex = 1;
            this.StartTimeLabel.Text = "Start Time:";
            // 
            // StartTime
            // 
            this.StartTime.Location = new System.Drawing.Point(136, 23);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(146, 13);
            this.StartTime.TabIndex = 2;
            this.StartTime.Text = "StartTime";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(12, 50);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.EndTimeLabel.TabIndex = 3;
            this.EndTimeLabel.Text = "End Time:";
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(136, 50);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(146, 13);
            this.EndTime.TabIndex = 4;
            this.EndTime.Text = "EndTime";
            // 
            // TotalMatchingFilesLabel
            // 
            this.TotalMatchingFilesLabel.AutoSize = true;
            this.TotalMatchingFilesLabel.Location = new System.Drawing.Point(12, 105);
            this.TotalMatchingFilesLabel.Name = "TotalMatchingFilesLabel";
            this.TotalMatchingFilesLabel.Size = new System.Drawing.Size(105, 13);
            this.TotalMatchingFilesLabel.TabIndex = 5;
            this.TotalMatchingFilesLabel.Text = "Total Matching Files:";
            // 
            // TotalMatchingFiles
            // 
            this.TotalMatchingFiles.Location = new System.Drawing.Point(136, 105);
            this.TotalMatchingFiles.Name = "TotalMatchingFiles";
            this.TotalMatchingFiles.Size = new System.Drawing.Size(146, 13);
            this.TotalMatchingFiles.TabIndex = 6;
            this.TotalMatchingFiles.Text = "TotalMatchingFiles";
            // 
            // TotalGroups
            // 
            this.TotalGroups.Location = new System.Drawing.Point(136, 133);
            this.TotalGroups.Name = "TotalGroups";
            this.TotalGroups.Size = new System.Drawing.Size(146, 13);
            this.TotalGroups.TabIndex = 8;
            this.TotalGroups.Text = "TotalGroups";
            // 
            // TotalGroupsLabel
            // 
            this.TotalGroupsLabel.AutoSize = true;
            this.TotalGroupsLabel.Location = new System.Drawing.Point(12, 133);
            this.TotalGroupsLabel.Name = "TotalGroupsLabel";
            this.TotalGroupsLabel.Size = new System.Drawing.Size(71, 13);
            this.TotalGroupsLabel.TabIndex = 7;
            this.TotalGroupsLabel.Text = "Total Groups:";
            // 
            // TotalMatchesLabel
            // 
            this.TotalMatchesLabel.AutoSize = true;
            this.TotalMatchesLabel.Location = new System.Drawing.Point(12, 77);
            this.TotalMatchesLabel.Name = "TotalMatchesLabel";
            this.TotalMatchesLabel.Size = new System.Drawing.Size(78, 13);
            this.TotalMatchesLabel.TabIndex = 9;
            this.TotalMatchesLabel.Text = "Total Matches:";
            // 
            // TotalMatches
            // 
            this.TotalMatches.Location = new System.Drawing.Point(136, 77);
            this.TotalMatches.Name = "TotalMatches";
            this.TotalMatches.Size = new System.Drawing.Size(146, 13);
            this.TotalMatches.TabIndex = 10;
            this.TotalMatches.Text = "TotalMatches";
            // 
            // DSSearchComplete
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 226);
            this.Controls.Add(this.TotalMatches);
            this.Controls.Add(this.TotalMatchesLabel);
            this.Controls.Add(this.TotalGroups);
            this.Controls.Add(this.TotalGroupsLabel);
            this.Controls.Add(this.TotalMatchingFiles);
            this.Controls.Add(this.TotalMatchingFilesLabel);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DSSearchComplete";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Search Complete/Stopped";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DSSearchComplete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.Label TotalMatchingFilesLabel;
        private System.Windows.Forms.Label TotalMatchingFiles;
        private System.Windows.Forms.Label TotalGroups;
        private System.Windows.Forms.Label TotalGroupsLabel;
        private System.Windows.Forms.Label TotalMatchesLabel;
        private System.Windows.Forms.Label TotalMatches;
    }
}