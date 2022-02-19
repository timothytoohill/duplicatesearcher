namespace DuplicateSearcher {
    partial class DSAutoSelect {
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
            this.PerformSelectionButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OriginalsLocationsFrame = new System.Windows.Forms.GroupBox();
            this.OriginalsLocationTxt = new System.Windows.Forms.TextBox();
            this.OriginalsLocationsLabel = new System.Windows.Forms.Label();
            this.OriginalsLocationsList = new System.Windows.Forms.ListView();
            this.SearchLocationsListNameColumn = new System.Windows.Forms.ColumnHeader();
            this.RemoveOriginalsLocationButton = new System.Windows.Forms.Button();
            this.AddOriginalsLocationButton = new System.Windows.Forms.Button();
            this.DirectoryBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Largest = new System.Windows.Forms.CheckBox();
            this.LastModified = new System.Windows.Forms.CheckBox();
            this.SeperatorLabel = new System.Windows.Forms.Label();
            this.IgnoreDirectories = new System.Windows.Forms.CheckBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.OriginalsLocationsFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // PerformSelectionButton
            // 
            this.PerformSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PerformSelectionButton.Location = new System.Drawing.Point(12, 355);
            this.PerformSelectionButton.Name = "PerformSelectionButton";
            this.PerformSelectionButton.Size = new System.Drawing.Size(105, 32);
            this.PerformSelectionButton.TabIndex = 0;
            this.PerformSelectionButton.Text = "&Perform Selection";
            this.PerformSelectionButton.UseVisualStyleBackColor = true;
            this.PerformSelectionButton.Click += new System.EventHandler(this.PerformSelectionButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(304, 355);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 32);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OriginalsLocationsFrame
            // 
            this.OriginalsLocationsFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalsLocationsFrame.Controls.Add(this.OriginalsLocationTxt);
            this.OriginalsLocationsFrame.Controls.Add(this.OriginalsLocationsLabel);
            this.OriginalsLocationsFrame.Controls.Add(this.OriginalsLocationsList);
            this.OriginalsLocationsFrame.Controls.Add(this.RemoveOriginalsLocationButton);
            this.OriginalsLocationsFrame.Controls.Add(this.AddOriginalsLocationButton);
            this.OriginalsLocationsFrame.Location = new System.Drawing.Point(12, 82);
            this.OriginalsLocationsFrame.Name = "OriginalsLocationsFrame";
            this.OriginalsLocationsFrame.Size = new System.Drawing.Size(367, 256);
            this.OriginalsLocationsFrame.TabIndex = 2;
            this.OriginalsLocationsFrame.TabStop = false;
            this.OriginalsLocationsFrame.Text = "Originals Locations:";
            // 
            // OriginalsLocationTxt
            // 
            this.OriginalsLocationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalsLocationTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalsLocationTxt.Location = new System.Drawing.Point(63, 59);
            this.OriginalsLocationTxt.Name = "OriginalsLocationTxt";
            this.OriginalsLocationTxt.ReadOnly = true;
            this.OriginalsLocationTxt.Size = new System.Drawing.Size(242, 20);
            this.OriginalsLocationTxt.TabIndex = 12;
            // 
            // OriginalsLocationsLabel
            // 
            this.OriginalsLocationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalsLocationsLabel.Location = new System.Drawing.Point(7, 24);
            this.OriginalsLocationsLabel.Name = "OriginalsLocationsLabel";
            this.OriginalsLocationsLabel.Size = new System.Drawing.Size(354, 30);
            this.OriginalsLocationsLabel.TabIndex = 4;
            this.OriginalsLocationsLabel.Text = "Matches that are located in the following Directorys will be considered originals" +
                " and will not be selected:";
            // 
            // OriginalsLocationsList
            // 
            this.OriginalsLocationsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.OriginalsLocationsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalsLocationsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalsLocationsList.CheckBoxes = true;
            this.OriginalsLocationsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SearchLocationsListNameColumn});
            this.OriginalsLocationsList.FullRowSelect = true;
            this.OriginalsLocationsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.OriginalsLocationsList.HideSelection = false;
            this.OriginalsLocationsList.Location = new System.Drawing.Point(6, 86);
            this.OriginalsLocationsList.Name = "OriginalsLocationsList";
            this.OriginalsLocationsList.Size = new System.Drawing.Size(354, 162);
            this.OriginalsLocationsList.TabIndex = 3;
            this.OriginalsLocationsList.UseCompatibleStateImageBehavior = false;
            this.OriginalsLocationsList.View = System.Windows.Forms.View.Details;
            this.OriginalsLocationsList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OriginalsLocationsList_ItemSelectionChanged);
            // 
            // SearchLocationsListNameColumn
            // 
            this.SearchLocationsListNameColumn.Text = "Path";
            this.SearchLocationsListNameColumn.Width = 1000;
            // 
            // RemoveOriginalsLocationButton
            // 
            this.RemoveOriginalsLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveOriginalsLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveOriginalsLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveOriginalsLocationButton.Location = new System.Drawing.Point(311, 57);
            this.RemoveOriginalsLocationButton.Name = "RemoveOriginalsLocationButton";
            this.RemoveOriginalsLocationButton.Size = new System.Drawing.Size(50, 23);
            this.RemoveOriginalsLocationButton.TabIndex = 2;
            this.RemoveOriginalsLocationButton.Text = "Remo&ve";
            this.RemoveOriginalsLocationButton.UseVisualStyleBackColor = true;
            this.RemoveOriginalsLocationButton.Click += new System.EventHandler(this.RemoveOriginalsLocationButton_Click);
            // 
            // AddOriginalsLocationButton
            // 
            this.AddOriginalsLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddOriginalsLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddOriginalsLocationButton.Location = new System.Drawing.Point(7, 57);
            this.AddOriginalsLocationButton.Name = "AddOriginalsLocationButton";
            this.AddOriginalsLocationButton.Size = new System.Drawing.Size(50, 23);
            this.AddOriginalsLocationButton.TabIndex = 1;
            this.AddOriginalsLocationButton.Text = "A&dd";
            this.AddOriginalsLocationButton.UseVisualStyleBackColor = true;
            this.AddOriginalsLocationButton.Click += new System.EventHandler(this.AddOriginalsLocationButton_Click);
            // 
            // DirectoryBrowserDialog
            // 
            this.DirectoryBrowserDialog.ShowNewFolderButton = false;
            // 
            // Largest
            // 
            this.Largest.AutoSize = true;
            this.Largest.Location = new System.Drawing.Point(12, 36);
            this.Largest.Name = "Largest";
            this.Largest.Size = new System.Drawing.Size(231, 17);
            this.Largest.TabIndex = 6;
            this.Largest.Text = "Select all matches except the largest in size";
            this.Largest.UseVisualStyleBackColor = true;
            // 
            // LastModified
            // 
            this.LastModified.AutoSize = true;
            this.LastModified.Checked = true;
            this.LastModified.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LastModified.Location = new System.Drawing.Point(12, 12);
            this.LastModified.Name = "LastModified";
            this.LastModified.Size = new System.Drawing.Size(364, 17);
            this.LastModified.TabIndex = 5;
            this.LastModified.Text = "Select all matches except those with the latest \'Last Modified\' timestamp";
            this.LastModified.UseVisualStyleBackColor = true;
            // 
            // SeperatorLabel
            // 
            this.SeperatorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SeperatorLabel.BackColor = System.Drawing.Color.Black;
            this.SeperatorLabel.Location = new System.Drawing.Point(12, 346);
            this.SeperatorLabel.Name = "SeperatorLabel";
            this.SeperatorLabel.Size = new System.Drawing.Size(367, 2);
            this.SeperatorLabel.TabIndex = 7;
            // 
            // IgnoreDirectories
            // 
            this.IgnoreDirectories.AutoSize = true;
            this.IgnoreDirectories.Checked = true;
            this.IgnoreDirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IgnoreDirectories.Location = new System.Drawing.Point(12, 59);
            this.IgnoreDirectories.Name = "IgnoreDirectories";
            this.IgnoreDirectories.Size = new System.Drawing.Size(109, 17);
            this.IgnoreDirectories.TabIndex = 8;
            this.IgnoreDirectories.Text = "Ignore Directories";
            this.IgnoreDirectories.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.Location = new System.Drawing.Point(123, 355);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(175, 32);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Ready.";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DSAutoSelect
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 399);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.IgnoreDirectories);
            this.Controls.Add(this.SeperatorLabel);
            this.Controls.Add(this.Largest);
            this.Controls.Add(this.LastModified);
            this.Controls.Add(this.OriginalsLocationsFrame);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PerformSelectionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(399, 423);
            this.Name = "DSAutoSelect";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Auto Select";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DSAutoSelect_FormClosing);
            this.OriginalsLocationsFrame.ResumeLayout(false);
            this.OriginalsLocationsFrame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PerformSelectionButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox OriginalsLocationsFrame;
        private System.Windows.Forms.ListView OriginalsLocationsList;
        private System.Windows.Forms.ColumnHeader SearchLocationsListNameColumn;
        private System.Windows.Forms.Button RemoveOriginalsLocationButton;
        private System.Windows.Forms.Button AddOriginalsLocationButton;
        private System.Windows.Forms.Label OriginalsLocationsLabel;
        private System.Windows.Forms.FolderBrowserDialog DirectoryBrowserDialog;
        private System.Windows.Forms.CheckBox Largest;
        private System.Windows.Forms.CheckBox LastModified;
        private System.Windows.Forms.Label SeperatorLabel;
        private System.Windows.Forms.CheckBox IgnoreDirectories;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox OriginalsLocationTxt;
    }
}