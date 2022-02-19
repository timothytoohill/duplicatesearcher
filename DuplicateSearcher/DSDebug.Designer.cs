namespace DuplicateSearcher {
    partial class DSDebug {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSDebug));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.OutputKey = new System.Windows.Forms.Button();
            this.OutputTxt = new System.Windows.Forms.TextBox();
            this.WordWrapChk = new System.Windows.Forms.CheckBox();
            this.CheckForNewMessages = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.Location = new System.Drawing.Point(579, 415);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // OutputKey
            // 
            this.OutputKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputKey.Location = new System.Drawing.Point(13, 415);
            this.OutputKey.Name = "OutputKey";
            this.OutputKey.Size = new System.Drawing.Size(124, 23);
            this.OutputKey.TabIndex = 2;
            this.OutputKey.Text = "Output Public Key";
            this.OutputKey.UseVisualStyleBackColor = true;
            this.OutputKey.Click += new System.EventHandler(this.OutputKey_Click);
            // 
            // OutputTxt
            // 
            this.OutputTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTxt.Location = new System.Drawing.Point(13, 13);
            this.OutputTxt.Multiline = true;
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.ReadOnly = true;
            this.OutputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTxt.Size = new System.Drawing.Size(642, 396);
            this.OutputTxt.TabIndex = 3;
            this.OutputTxt.WordWrap = false;
            // 
            // WordWrapChk
            // 
            this.WordWrapChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WordWrapChk.AutoSize = true;
            this.WordWrapChk.Location = new System.Drawing.Point(154, 421);
            this.WordWrapChk.Name = "WordWrapChk";
            this.WordWrapChk.Size = new System.Drawing.Size(78, 17);
            this.WordWrapChk.TabIndex = 4;
            this.WordWrapChk.Text = "Word wrap";
            this.WordWrapChk.UseVisualStyleBackColor = true;
            this.WordWrapChk.CheckedChanged += new System.EventHandler(this.WordWrapChk_CheckedChanged);
            // 
            // CheckForNewMessages
            // 
            this.CheckForNewMessages.Enabled = true;
            this.CheckForNewMessages.Tick += new System.EventHandler(this.CheckForNewMessages_Tick);
            // 
            // DSDebug
            // 
            this.AcceptButton = this.CloseBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.WordWrapChk);
            this.Controls.Add(this.OutputTxt);
            this.Controls.Add(this.OutputKey);
            this.Controls.Add(this.CloseBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS Debug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DSDebug_FormClosing);
            this.Load += new System.EventHandler(this.DSDebug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button OutputKey;
        private System.Windows.Forms.TextBox OutputTxt;
        private System.Windows.Forms.CheckBox WordWrapChk;
        private System.Windows.Forms.Timer CheckForNewMessages;
    }
}