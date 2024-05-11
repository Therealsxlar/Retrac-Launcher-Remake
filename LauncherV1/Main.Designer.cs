namespace LauncherV1
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.LaunchButton = new Guna.UI2.WinForms.Guna2Button();
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.ExitPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LauncherPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.SettingsPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.FortnitePathButton = new Guna.UI2.WinForms.Guna2Button();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.BorderRadius = 5;
            this.LaunchButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.LaunchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LaunchButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LaunchButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LaunchButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(173)))), ((int)(((byte)(77)))));
            this.LaunchButton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.ForeColor = System.Drawing.Color.White;
            this.LaunchButton.Location = new System.Drawing.Point(16, 425);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(342, 44);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.MainPanel.BorderRadius = 5;
            this.MainPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.MainPanel.Controls.Add(this.ExitPictureBox);
            this.MainPanel.Controls.Add(this.LauncherPictureBox);
            this.MainPanel.Controls.Add(this.SettingsPictureBox);
            this.MainPanel.Location = new System.Drawing.Point(-4, -1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(375, 100);
            this.MainPanel.TabIndex = 1;
            // 
            // ExitPictureBox
            // 
            this.ExitPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.ExitPictureBox.BorderRadius = 5;
            this.ExitPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitPictureBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ExitPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ExitPictureBox.Image")));
            this.ExitPictureBox.ImageRotate = 0F;
            this.ExitPictureBox.Location = new System.Drawing.Point(323, 9);
            this.ExitPictureBox.Name = "ExitPictureBox";
            this.ExitPictureBox.Size = new System.Drawing.Size(51, 33);
            this.ExitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitPictureBox.TabIndex = 63;
            this.ExitPictureBox.TabStop = false;
            this.ExitPictureBox.Click += new System.EventHandler(this.ExitPictureBox_Click);
            // 
            // LauncherPictureBox
            // 
            this.LauncherPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LauncherPictureBox.Image")));
            this.LauncherPictureBox.ImageRotate = 0F;
            this.LauncherPictureBox.Location = new System.Drawing.Point(-53, -31);
            this.LauncherPictureBox.Name = "LauncherPictureBox";
            this.LauncherPictureBox.Size = new System.Drawing.Size(259, 133);
            this.LauncherPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LauncherPictureBox.TabIndex = 2;
            this.LauncherPictureBox.TabStop = false;
            // 
            // SettingsPictureBox
            // 
            this.SettingsPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.SettingsPictureBox.BorderRadius = 5;
            this.SettingsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsPictureBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.SettingsPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SettingsPictureBox.Image")));
            this.SettingsPictureBox.ImageRotate = 0F;
            this.SettingsPictureBox.Location = new System.Drawing.Point(278, 9);
            this.SettingsPictureBox.Name = "SettingsPictureBox";
            this.SettingsPictureBox.Size = new System.Drawing.Size(51, 33);
            this.SettingsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsPictureBox.TabIndex = 62;
            this.SettingsPictureBox.TabStop = false;
            // 
            // FortnitePathButton
            // 
            this.FortnitePathButton.BorderRadius = 5;
            this.FortnitePathButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.FortnitePathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FortnitePathButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FortnitePathButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FortnitePathButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FortnitePathButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FortnitePathButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(72)))), ((int)(((byte)(92)))));
            this.FortnitePathButton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FortnitePathButton.ForeColor = System.Drawing.Color.White;
            this.FortnitePathButton.Location = new System.Drawing.Point(16, 378);
            this.FortnitePathButton.Name = "FortnitePathButton";
            this.FortnitePathButton.Size = new System.Drawing.Size(342, 41);
            this.FortnitePathButton.TabIndex = 63;
            this.FortnitePathButton.Text = "Select Fortnite Path";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(370, 481);
            this.Controls.Add(this.FortnitePathButton);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LaunchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseUp);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button LaunchButton;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2PictureBox LauncherPictureBox;
        private Guna.UI2.WinForms.Guna2PictureBox SettingsPictureBox;
        private Guna.UI2.WinForms.Guna2Button FortnitePathButton;
        private Guna.UI2.WinForms.Guna2PictureBox ExitPictureBox;
    }
}

