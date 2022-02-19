namespace DuplicateSearcher {
    partial class DSRegister {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSRegister));
            this.CancelBtn = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.MsgLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RegistrationBox = new System.Windows.Forms.GroupBox();
            this.RegistrationUserNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RegistrationCodeTxt = new System.Windows.Forms.TextBox();
            this.RegistrationEmailAddressTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Msg1Lbl = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Msg3Lbl = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.Msg2Lbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RegistrationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelBtn.Location = new System.Drawing.Point(13, 392);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(129, 33);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "No Thanks, Not Yet";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterButton.Location = new System.Drawing.Point(485, 392);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(129, 33);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // MsgLbl
            // 
            this.MsgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgLbl.BackColor = System.Drawing.Color.Transparent;
            this.MsgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.MsgLbl.Location = new System.Drawing.Point(12, 83);
            this.MsgLbl.Name = "MsgLbl";
            this.MsgLbl.Size = new System.Drawing.Size(605, 49);
            this.MsgLbl.TabIndex = 3;
            this.MsgLbl.Text = "To see all your duplicates or after 60 days of use, you must register DuplicateSe" +
    "archer.";
            this.MsgLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "DuplicateSearcher Registration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrationBox
            // 
            this.RegistrationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationBox.BackColor = System.Drawing.Color.Transparent;
            this.RegistrationBox.Controls.Add(this.RegistrationUserNameTxt);
            this.RegistrationBox.Controls.Add(this.label1);
            this.RegistrationBox.Controls.Add(this.RegistrationCodeTxt);
            this.RegistrationBox.Controls.Add(this.RegistrationEmailAddressTxt);
            this.RegistrationBox.Controls.Add(this.label4);
            this.RegistrationBox.Controls.Add(this.label3);
            this.RegistrationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrationBox.Location = new System.Drawing.Point(12, 247);
            this.RegistrationBox.Name = "RegistrationBox";
            this.RegistrationBox.Size = new System.Drawing.Size(602, 139);
            this.RegistrationBox.TabIndex = 10;
            this.RegistrationBox.TabStop = false;
            this.RegistrationBox.Text = "Registration:";
            // 
            // RegistrationUserNameTxt
            // 
            this.RegistrationUserNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationUserNameTxt.Location = new System.Drawing.Point(131, 54);
            this.RegistrationUserNameTxt.Name = "RegistrationUserNameTxt";
            this.RegistrationUserNameTxt.Size = new System.Drawing.Size(461, 22);
            this.RegistrationUserNameTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name:";
            // 
            // RegistrationCodeTxt
            // 
            this.RegistrationCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationCodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrationCodeTxt.Location = new System.Drawing.Point(131, 82);
            this.RegistrationCodeTxt.Multiline = true;
            this.RegistrationCodeTxt.Name = "RegistrationCodeTxt";
            this.RegistrationCodeTxt.Size = new System.Drawing.Size(461, 49);
            this.RegistrationCodeTxt.TabIndex = 3;
            // 
            // RegistrationEmailAddressTxt
            // 
            this.RegistrationEmailAddressTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationEmailAddressTxt.Location = new System.Drawing.Point(131, 26);
            this.RegistrationEmailAddressTxt.Name = "RegistrationEmailAddressTxt";
            this.RegistrationEmailAddressTxt.Size = new System.Drawing.Size(461, 22);
            this.RegistrationEmailAddressTxt.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email Address:";
            // 
            // Msg1Lbl
            // 
            this.Msg1Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Msg1Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Msg1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Msg1Lbl.Location = new System.Drawing.Point(12, 132);
            this.Msg1Lbl.Name = "Msg1Lbl";
            this.Msg1Lbl.Size = new System.Drawing.Size(602, 33);
            this.Msg1Lbl.TabIndex = 11;
            this.Msg1Lbl.Text = "In order to register DuplicateSearcher, you must purchase a license key. To purch" +
    "ase a license key, browse to the following address (or click the link): ";
            this.Msg1Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(254, 402);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(226, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.duplicatesearcher.com/purchase/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Msg3Lbl
            // 
            this.Msg3Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Msg3Lbl.AutoSize = true;
            this.Msg3Lbl.Location = new System.Drawing.Point(142, 402);
            this.Msg3Lbl.Margin = new System.Windows.Forms.Padding(0);
            this.Msg3Lbl.Name = "Msg3Lbl";
            this.Msg3Lbl.Size = new System.Drawing.Size(115, 13);
            this.Msg3Lbl.TabIndex = 13;
            this.Msg3Lbl.Text = "To purchase a license:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(10, 165);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(604, 23);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://www.duplicatesearcher.com/purchase/";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Msg2Lbl
            // 
            this.Msg2Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Msg2Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Msg2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Msg2Lbl.Location = new System.Drawing.Point(15, 186);
            this.Msg2Lbl.Name = "Msg2Lbl";
            this.Msg2Lbl.Size = new System.Drawing.Size(599, 58);
            this.Msg2Lbl.TabIndex = 15;
            this.Msg2Lbl.Text = resources.GetString("Msg2Lbl.Text");
            this.Msg2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLbl
            // 
            this.StatusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLbl.BackColor = System.Drawing.Color.Transparent;
            this.StatusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusLbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.Location = new System.Drawing.Point(87, 41);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(452, 40);
            this.StatusLbl.TabIndex = 17;
            this.StatusLbl.Text = "Status: unregistered; Remaining Usages: 19";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DSRegister
            // 
            this.AcceptButton = this.RegisterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 437);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.Msg2Lbl);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.Msg3Lbl);
            this.Controls.Add(this.Msg1Lbl);
            this.Controls.Add(this.RegistrationBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MsgLbl);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuplicateSearcher Registration";
            this.Activated += new System.EventHandler(this.DSRegister_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DSRegister_FormClosing);
            this.Load += new System.EventHandler(this.DSRegister_Load);
            this.RegistrationBox.ResumeLayout(false);
            this.RegistrationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label MsgLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox RegistrationBox;
        private System.Windows.Forms.TextBox RegistrationCodeTxt;
        private System.Windows.Forms.TextBox RegistrationEmailAddressTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Msg1Lbl;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label Msg3Lbl;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label Msg2Lbl;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.TextBox RegistrationUserNameTxt;
        private System.Windows.Forms.Label label1;
    }
}