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
            this.PlayersOnlineLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ExitPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.LauncherPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.SettingsPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.FortnitePathButton = new Guna.UI2.WinForms.Guna2Button();
            this.FortnitePath = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DiscordButton = new Guna.UI2.WinForms.Guna2Button();
            this.LockedPictureBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.BorderRadius = 4;
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
            this.LaunchButton.Text = "Launch Fortnite";
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            this.LaunchButton.MouseEnter += new System.EventHandler(this.LaunchButton_MouseEnter);
            this.LaunchButton.MouseLeave += new System.EventHandler(this.LaunchButton_MouseLeave);
            this.LaunchButton.MouseHover += new System.EventHandler(this.LaunchButton_MouseHover);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.MainPanel.BorderRadius = 5;
            this.MainPanel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.MainPanel.Controls.Add(this.guna2HtmlLabel1);
            this.MainPanel.Controls.Add(this.PlayersOnlineLabel);
            this.MainPanel.Controls.Add(this.ExitPictureBox);
            this.MainPanel.Controls.Add(this.LauncherPictureBox);
            this.MainPanel.Controls.Add(this.SettingsPictureBox);
            this.MainPanel.Location = new System.Drawing.Point(-5, -1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(375, 85);
            this.MainPanel.TabIndex = 1;
            // 
            // PlayersOnlineLabel
            // 
            this.PlayersOnlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayersOnlineLabel.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersOnlineLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PlayersOnlineLabel.Location = new System.Drawing.Point(18, 56);
            this.PlayersOnlineLabel.Name = "PlayersOnlineLabel";
            this.PlayersOnlineLabel.Size = new System.Drawing.Size(109, 19);
            this.PlayersOnlineLabel.TabIndex = 66;
            this.PlayersOnlineLabel.Text = "0 Players Online";
            // 
            // ExitPictureBox
            // 
            this.ExitPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.ExitPictureBox.BorderRadius = 5;
            this.ExitPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitPictureBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.ExitPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ExitPictureBox.Image")));
            this.ExitPictureBox.ImageRotate = 0F;
            this.ExitPictureBox.Location = new System.Drawing.Point(294, 15);
            this.ExitPictureBox.Name = "ExitPictureBox";
            this.ExitPictureBox.Size = new System.Drawing.Size(39, 24);
            this.ExitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitPictureBox.TabIndex = 63;
            this.ExitPictureBox.TabStop = false;
            this.ExitPictureBox.Click += new System.EventHandler(this.ExitPictureBox_Click);
            // 
            // LauncherPictureBox
            // 
            this.LauncherPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LauncherPictureBox.Image")));
            this.LauncherPictureBox.ImageRotate = 0F;
            this.LauncherPictureBox.Location = new System.Drawing.Point(-58, -31);
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
            this.SettingsPictureBox.Location = new System.Drawing.Point(336, 15);
            this.SettingsPictureBox.Name = "SettingsPictureBox";
            this.SettingsPictureBox.Size = new System.Drawing.Size(32, 24);
            this.SettingsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SettingsPictureBox.TabIndex = 62;
            this.SettingsPictureBox.TabStop = false;
            // 
            // FortnitePathButton
            // 
            this.FortnitePathButton.BorderRadius = 4;
            this.FortnitePathButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.FortnitePathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FortnitePathButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FortnitePathButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FortnitePathButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FortnitePathButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FortnitePathButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(72)))), ((int)(((byte)(92)))));
            this.FortnitePathButton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FortnitePathButton.ForeColor = System.Drawing.Color.White;
            this.FortnitePathButton.Location = new System.Drawing.Point(16, 372);
            this.FortnitePathButton.Name = "FortnitePathButton";
            this.FortnitePathButton.Size = new System.Drawing.Size(342, 44);
            this.FortnitePathButton.TabIndex = 63;
            this.FortnitePathButton.Text = "Set Fortnite Directory";
            this.FortnitePathButton.Click += new System.EventHandler(this.FortnitePathButton_Click);
            // 
            // FortnitePath
            // 
            this.FortnitePath.BackColor = System.Drawing.Color.Transparent;
            this.FortnitePath.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FortnitePath.ForeColor = System.Drawing.SystemColors.Control;
            this.FortnitePath.Location = new System.Drawing.Point(16, 294);
            this.FortnitePath.Name = "FortnitePath";
            this.FortnitePath.Size = new System.Drawing.Size(340, 19);
            this.FortnitePath.TabIndex = 64;
            this.FortnitePath.Text = "DON\'T DELETE THIS LABEL (used for Fortnite path)\r\n";
            this.FortnitePath.Visible = false;
            // 
            // DiscordButton
            // 
            this.DiscordButton.BorderRadius = 4;
            this.DiscordButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.DiscordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DiscordButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DiscordButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DiscordButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DiscordButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DiscordButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(64)))), ((int)(((byte)(116)))));
            this.DiscordButton.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscordButton.ForeColor = System.Drawing.Color.White;
            this.DiscordButton.Location = new System.Drawing.Point(16, 319);
            this.DiscordButton.Name = "DiscordButton";
            this.DiscordButton.Size = new System.Drawing.Size(342, 44);
            this.DiscordButton.TabIndex = 65;
            this.DiscordButton.Text = "Discord";
            this.DiscordButton.Click += new System.EventHandler(this.DiscordButton_Click);
            // 
            // LockedPictureBox
            // 
            this.LockedPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(64)))), ((int)(((byte)(57)))));
            this.LockedPictureBox.BorderRadius = 5;
            this.LockedPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LockedPictureBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.LockedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LockedPictureBox.Image")));
            this.LockedPictureBox.ImageRotate = 0F;
            this.LockedPictureBox.Location = new System.Drawing.Point(21, 435);
            this.LockedPictureBox.Name = "LockedPictureBox";
            this.LockedPictureBox.Size = new System.Drawing.Size(39, 24);
            this.LockedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LockedPictureBox.TabIndex = 67;
            this.LockedPictureBox.TabStop = false;
            this.LockedPictureBox.Visible = false;
            this.LockedPictureBox.MouseHover += new System.EventHandler(this.LockedPictureBox_MouseHover);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(253, 57);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(115, 19);
            this.guna2HtmlLabel1.TabIndex = 67;
            this.guna2HtmlLabel1.Text = "CycloServer-User";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(370, 481);
            this.Controls.Add(this.LockedPictureBox);
            this.Controls.Add(this.DiscordButton);
            this.Controls.Add(this.FortnitePath);
            this.Controls.Add(this.FortnitePathButton);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LaunchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseUp);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LauncherPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button LaunchButton;
        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2PictureBox LauncherPictureBox;
        private Guna.UI2.WinForms.Guna2PictureBox SettingsPictureBox;
        private Guna.UI2.WinForms.Guna2Button FortnitePathButton;
        private Guna.UI2.WinForms.Guna2PictureBox ExitPictureBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel FortnitePath;
        private Guna.UI2.WinForms.Guna2Button DiscordButton;
        private Guna.UI2.WinForms.Guna2HtmlLabel PlayersOnlineLabel;
        private Guna.UI2.WinForms.Guna2PictureBox LockedPictureBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}

