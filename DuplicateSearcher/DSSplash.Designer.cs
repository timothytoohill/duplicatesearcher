namespace DuplicateSearcher {
    partial class DSSplash {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSSplash));
            this.HideTimer = new System.Windows.Forms.Timer(this.components);
            this.MainLbl = new System.Windows.Forms.Label();
            this.DescLbl = new System.Windows.Forms.Label();
            this.RegStatusLbl = new System.Windows.Forms.Label();
            this.RegInfoLbl = new System.Windows.Forms.Label();
            this.LoadingMsgLbl = new System.Windows.Forms.Label();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HideTimer
            // 
            this.HideTimer.Interval = 1500;
            this.HideTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainLbl
            // 
            this.MainLbl.AutoSize = true;
            this.MainLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLbl.Location = new System.Drawing.Point(86, 28);
            this.MainLbl.Name = "MainLbl";
            this.MainLbl.Size = new System.Drawing.Size(238, 31);
            this.MainLbl.TabIndex = 2;
            this.MainLbl.Text = "DuplicateSearcher";
            // 
            // DescLbl
            // 
            this.DescLbl.AutoSize = true;
            this.DescLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescLbl.Location = new System.Drawing.Point(94, 70);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new System.Drawing.Size(326, 14);
            this.DescLbl.TabIndex = 3;
            this.DescLbl.Text = "A state of the art utility for finding duplicate files on your computer.";
            // 
            // RegStatusLbl
            // 
            this.RegStatusLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegStatusLbl.AutoSize = true;
            this.RegStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegStatusLbl.Location = new System.Drawing.Point(511, 13);
            this.RegStatusLbl.Name = "RegStatusLbl";
            this.RegStatusLbl.Size = new System.Drawing.Size(84, 12);
            this.RegStatusLbl.TabIndex = 4;
            this.RegStatusLbl.Text = "Registration Status";
            // 
            // RegInfoLbl
            // 
            this.RegInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegInfoLbl.AutoSize = true;
            this.RegInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegInfoLbl.Location = new System.Drawing.Point(522, 31);
            this.RegInfoLbl.Name = "RegInfoLbl";
            this.RegInfoLbl.Size = new System.Drawing.Size(73, 12);
            this.RegInfoLbl.TabIndex = 5;
            this.RegInfoLbl.Text = "Registration Info";
            // 
            // LoadingMsgLbl
            // 
            this.LoadingMsgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingMsgLbl.AutoSize = true;
            this.LoadingMsgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingMsgLbl.Location = new System.Drawing.Point(549, 47);
            this.LoadingMsgLbl.Name = "LoadingMsgLbl";
            this.LoadingMsgLbl.Size = new System.Drawing.Size(46, 12);
            this.LoadingMsgLbl.TabIndex = 6;
            this.LoadingMsgLbl.Text = "Loading...";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(495, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::DuplicateSearcher.Properties.Resources.Header2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // DSSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 113);
            this.ControlBox = false;
            this.Controls.Add(this.LoadingMsgLbl);
            this.Controls.Add(this.RegInfoLbl);
            this.Controls.Add(this.RegStatusLbl);
            this.Controls.Add(this.DescLbl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.MainLbl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DSSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer HideTimer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label MainLbl;
        private System.Windows.Forms.Label DescLbl;
        private System.Windows.Forms.Label RegStatusLbl;
        private System.Windows.Forms.Label RegInfoLbl;
        private System.Windows.Forms.Label LoadingMsgLbl;
        private System.Windows.Forms.Timer AnimationTimer;
    }
}