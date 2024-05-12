namespace LauncherV1
{
    partial class Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.labelStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LauncherPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LongLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ProgressBar = new Guna.UI2.WinForms.Guna2VProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.labelStatus.Location = new System.Drawing.Point(9, 58);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(12, 20);
            this.labelStatus.TabIndex = 67;
            this.labelStatus.Text = "0";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // LauncherPictureBox
            // 
            this.LauncherPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LauncherPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LauncherPictureBox.Image")));
            this.LauncherPictureBox.ImageRotate = 0F;
            this.LauncherPictureBox.Location = new System.Drawing.Point(-4, -25);
            this.LauncherPictureBox.Name = "LauncherPictureBox";
            this.LauncherPictureBox.Size = new System.Drawing.Size(259, 133);
            this.LauncherPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LauncherPictureBox.TabIndex = 68;
            this.LauncherPictureBox.TabStop = false;
            // 
            // LongLabel
            // 
            this.LongLabel.BackColor = System.Drawing.Color.Transparent;
            this.LongLabel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LongLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.LongLabel.Location = new System.Drawing.Point(9, 33);
            this.LongLabel.Name = "LongLabel";
            this.LongLabel.Size = new System.Drawing.Size(186, 20);
            this.LongLabel.TabIndex = 69;
            this.LongLabel.Text = "This might take a minute.";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BorderRadius = 4;
            this.ProgressBar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.ProgressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(96)))), ((int)(((byte)(190)))));
            this.ProgressBar.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.Location = new System.Drawing.Point(9, 84);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(214)))), ((int)(((byte)(204)))));
            this.ProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(224)))), ((int)(((byte)(145)))));
            this.ProgressBar.Size = new System.Drawing.Size(268, 10);
            this.ProgressBar.TabIndex = 70;
            this.ProgressBar.Text = "ProgressBar";
            this.ProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(289, 106);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.LongLabel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.LauncherPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Downloader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel labelStatus;
        private Guna.UI2.WinForms.Guna2PictureBox LauncherPictureBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel LongLabel;
        private Guna.UI2.WinForms.Guna2VProgressBar ProgressBar;
    }
}