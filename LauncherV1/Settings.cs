using InjectLoadingTest;
using InjectorTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LauncherV1;

namespace LauncherV1
{
    public partial class Settings : Form
    {
        private const int CORNER_RADIUS = 5; // the gui corner radius (can be changed)
        private const int FADE_INTERVAL = 6;
        private const double FADE_STEP = 0.03; // fade in speed (can be changed)
        private double currentOpacity = 0.0;
        private System.Windows.Forms.Timer fadeTimer;

        private Point destination;
        private bool isFadingIn = false;
        private bool isFadingOut = false;

        public Settings()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = FADE_INTERVAL;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();

            this.Opacity = 0;
            this.Location = new Point(16, 465);
            isFadingIn = true; // if this is false the GUI will not load!!!!! DON'T CHANGE THIS
        }

        private void LauncherPictureBox_Click(object sender, EventArgs e)
        {

        }

        // Makes the GUI rounded
        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddLine(rect.X + radius, rect.Y, rect.Right - radius * 2, rect.Y);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddLine(rect.Right, rect.Y + radius * 2, rect.Right, rect.Bottom - radius * 2);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(rect.Right - radius * 2, rect.Bottom, rect.X + radius * 2, rect.Bottom);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(rect.X, rect.Bottom - radius * 2, rect.X, rect.Y + radius * 2);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = GetRoundedRectangle(rect, CORNER_RADIUS);
            this.Region = new Region(path);
            using (Pen pen = new Pen(Color.FromArgb(0, 10, 10, 10), 2)) // transparent? - update IT'S TRANSPARENT GUYS! - Update this is used in most of the code!
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (isFadingIn)
            {
                currentOpacity += FADE_STEP;
                if (currentOpacity >= 1.0)
                {
                    currentOpacity = 1.0;
                    isFadingIn = false;
                }

                this.Opacity = currentOpacity;

                int dx = (destination.X - this.Left) / 10;
                int dy = (destination.Y - this.Top) / 10;
                if (this.Top > 465)
                {
                    this.Location = new Point(this.Left + dx, this.Top - dy);
                }
            }
            else if (isFadingOut)
            {
                currentOpacity -= FADE_STEP;
                if (currentOpacity <= 0.0)
                {
                    currentOpacity = 0.0;
                    isFadingOut = false;
                    this.Hide();
                }

                this.Opacity = currentOpacity;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            isFadingIn = true; // if this is false the GUI will not load!!!!! DON'T CHANGE THIS
            Username.Text = Properties.Settings.Default.Username;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            isFadingOut = true;
        }

        public static Process StartProcess(string path, bool shouldFreeze, string extraArgs = "")
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=5dh74c635862g575778132fb -skippatchcheck" + extraArgs
                }
            };
            process.Start();
            if (shouldFreeze)
            {
                foreach (object obj in process.Threads)
                {
                    ProcessThread thread = (ProcessThread)obj;
                    Win32.SuspendThread(Win32.OpenThread(2, false, thread.Id));
                }
            }
            return process;
        }

        private async void SingleplayerButton_Click(object sender, EventArgs e)
        {
            string clientPath = Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64", game.ClientExecutable);
            string[] requiredFiles = { game.dll, game.memory, game.console };

            string launcherURL = "https://github.com/Therealsxlar/CycloServer-Dlls/raw/main/FortniteLauncher.exe";
            string dllUrl = "https://github.com/Therealsxlar/CycloServer-Dlls/raw/main/CycloServer.dll";

            string dllPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CycloServer.dll");
            if (!File.Exists(dllPath))
            {
                DialogResult result = MessageBox.Show("Seems like there's a DLL missing. Would you like to install it?", "DLL Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            await webClient.DownloadFileTaskAsync(dllUrl, dllPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to download the required DLL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SingleplayerButton.Text = "Host";
                        return;
                    }
                }
                else
                {
                    SingleplayerButton.Text = "Host";
                    return;
                }
            }

            foreach (string file in requiredFiles)
            {
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"\"{file}\" was not found. Please try again or reinstall the launcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SingleplayerButton.Text = "Host";
                    return;
                }
            }

            SingleplayerButton.Text = "Hosting";

            SingleplayerButton.Text = "Hosting";
            await Task.Run(() =>
            {
                Process process = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe"), true, "");
                Process gameProcess = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe"), true, "");

                Process authProcess = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"), false, $"-AUTH_TYPE=epic -AUTH_LOGIN=Sxlardev@gmail.com -AUTH_PASSWORD=yjtjyttjytyt");

                authProcess.WaitForInputIdle();

                int processId = authProcess.Id;
                foreach (string file in requiredFiles)
                {
                    string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.dll));
                    System.Threading.Thread.Sleep(40000);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.memory));
                    System.Threading.Thread.Sleep(20000);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.hosting));
                }

                authProcess.WaitForExit();
            });

            base.Show();
            SingleplayerButton.Text = "Host";
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = Username.Text;
            Properties.Settings.Default.Save();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}