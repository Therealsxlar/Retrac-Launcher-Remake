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

namespace LauncherV1
{
    public partial class Launcher : Form
    {
        private const int CORNER_RADIUS = 10; // the gui corner radius (can be changed)
        private const int FADE_INTERVAL = 6;
        private const double FADE_STEP = 0.03; // fade in speed (can be changed)
        private double currentOpacity = 0.0;
        private Timer fadeTimer;

        private Point destination;
        private bool isFadingIn = false;
        private Point mouseOffset;
        private bool isMouseDown = false;
        private bool isFadingOut = false;
        private Timer buttonfadingredonlaunch;

        public Launcher()
        {
            InitializeComponent();
            CloseLauncherProcessIfRequired();
            this.MouseDown += Launcher_MouseDown;
            this.MouseMove += Launcher_MouseMove;
            this.MouseUp += Launcher_MouseUp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            fadeTimer = new Timer();
            fadeTimer.Interval = FADE_INTERVAL;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            destination = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);

            this.Location = new Point(screenWidth, (screenHeight - this.Height) / 2);
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            isFadingIn = true; // if this is false the GUI will not load!!!!! DON'T CHANGE THIS
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SelectedFolderPath))
            {
                FortnitePathButton.Text = "Change Fortnite Path";
                FortnitePath.Text = $"Fortnite Path: {Properties.Settings.Default.SelectedFolderPath}";
            }
            else
            {
                FortnitePathButton.Text = "Select Fortnite Path";
                FortnitePath.Text = "Fortnite Path";
            }
        }


        // Start on Fading in so on startup there's no lag
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
                this.Location = new Point(this.Left + dx, this.Top + dy);
            }
            else if (isFadingOut)
            {
                currentOpacity -= FADE_STEP;
                if (currentOpacity <= 0.0)
                {
                    currentOpacity = 0.0;
                    isFadingOut = false;
                    Environment.Exit(0);
                }

                this.Opacity = currentOpacity;
            }
        }

        // Makes the GUI rounded DONT MESS WITH ANY OF THIS
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
            using (Pen pen = new Pen(Color.FromArgb(0, 10, 10, 10), 2)) // transparent? - update IT'S TRANSPARENT GUYS!
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        // End

        // This is how the GUI moves when mouse is dragging the GUI yk?
        private void Launcher_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseOffset = new Point(e.X, e.Y);
            }
        }

        private void Launcher_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(-mouseOffset.X, -mouseOffset.Y);
                Location = mousePos;
            }
        }
        private void Launcher_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        // This is how the GUI moves when mouse is dragging the GUI yk?
        // Ima also add it for the picture boxes so even if your trying to drag a picture box sense it's not the form it wont drag ykykykyk

        private void ExitPictureBox_Click(object sender, EventArgs e)
        {
            isFadingOut = true;
            CloseLauncherProcessIfRequired(); // if someone exits the launcher then it automatically exits fortnite
        }

        // Start on fortnite launching/closing
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

        private void CloseLauncherProcessIfRequired()
        {
            Process[] fortniteProcesses = Process.GetProcessesByName("FortniteClient-Win64-Shipping_BE");
            foreach (Process fortniteProcess in fortniteProcesses)
            {
                fortniteProcess.Kill();
            }

            fortniteProcesses = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
            foreach (Process fortniteProcess in fortniteProcesses)
            {
                fortniteProcess.Kill();
            }

            fortniteProcesses = Process.GetProcessesByName("FortniteLauncher");
            foreach (Process fortniteProcess in fortniteProcesses)
            {
                fortniteProcess.Kill();
            }

            fortniteProcesses = Process.GetProcessesByName("EpicGamesLauncher");
            foreach (Process fortniteProcess in fortniteProcesses)
            {
                fortniteProcess.Kill();
            }
        }

        private bool IsFortniteRunning()
        {
            Process[] processes = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
            return processes.Length > 0;
        }
        // End on fortnite launching/closing

        // Start on Launching Fortnite
        private async void LaunchButton_Click(object sender, EventArgs e)
        {
            LaunchButton.Text = "Fortnite is running";
            FadeOnLaunch_Tick(null, null);
            buttonfadingredonlaunch = new Timer();
            buttonfadingredonlaunch.Interval = 75;
            buttonfadingredonlaunch.Tick += FadeOnLaunch_Tick;
            buttonfadingredonlaunch.Start();

            Downloader downloaderForm = new Downloader();
            downloaderForm.Show();

            // Center downloaderForm in the middle of Main.cs
            int x = this.Location.X + (this.Width - downloaderForm.Width) / 2;
            int y = this.Location.Y + (this.Height - downloaderForm.Height) / 2;
            downloaderForm.Location = new Point(x, y);

            if (IsFortniteRunning())
            {
                MessageBox.Show("Fortnite is already running. If you closed it, please restart the launcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                downloaderForm.FadeOut();
                buttonfadingredonlaunch.Stop();
                buttonfadingredonlaunch.Dispose();
                return;
            }

            string clientPath = Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64", game.ClientExecutable);
            string[] requiredFiles = { game.dll, game.memory, game.console };

            string launcherURL = "https://github.com/Therealsxlar/CycloServer-Dlls/raw/main/FortniteLauncher.exe";
            string dllUrl = "https://github.com/Therealsxlar/CycloServer-Dlls/raw/main/CycloServer.dll";

            string dllPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CycloServer.dll");

            try
            {
                downloaderForm.UpdateStatus("Downloading CycloServer.dll");
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += (s, eventArgs) =>
                    {
                        downloaderForm.SetProgress(eventArgs.ProgressPercentage);
                    };

                    await webClient.DownloadFileTaskAsync(dllUrl, dllPath);
                }

                downloaderForm.FadeOutLabel();
                await Task.Delay(500);

                downloaderForm.UpdateStatus("Downloading FortniteLauncher.exe");
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += (s, eventArgs) =>
                    {
                        downloaderForm.SetProgress(eventArgs.ProgressPercentage);
                    };

                    await webClient.DownloadFileTaskAsync(launcherURL, Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe.new"));
                }
                LockedPictureBox.Visible = true;
                await Task.Delay(800);
                downloaderForm.FadeOut();
            }
            catch (Exception ex)
            {
                FailedDownload failedDownload = new FailedDownload();
                failedDownload.Show();
                downloaderForm.Close();
                LockedPictureBox.Visible = false;
                LaunchButton.FillColor = Color.FromArgb(68, 173, 77);
                LaunchButton.ForeColor = Color.White;
                LaunchButton.Text = "Launch";
                return;
            }
            try
            {
                File.Delete(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe"));
                File.Move(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe.new"), Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe"));
            }
            catch (Exception ex)
            {
                LaunchButton.Text = "ERROR";
                MessageBox.Show($"Please restart the launcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaunchButton.FillColor = Color.FromArgb(255, 191, 0);
                LockedPictureBox.Visible = false;
                LaunchButton.ForeColor = Color.White;
                LaunchButton.Text = "Restart Required";
                downloaderForm.Close();
                return;
            }

            LaunchButton.Text = "Fortnite is running";
            await Task.Run(() =>
            {
                Process process = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe"), true, "");
                Process gameProcess = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe"), true, "");

                string email = "CycloServer-User@snows.rocks";
                string password = "zzzzzzzzzzzzzzzz";

                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                {
                    MessageBox.Show("Invalid Email");
                    CloseLauncherProcessIfRequired();
                    return;
                }

                if (password.Length != 16)
                {
                    MessageBox.Show("Your Secret key is invalid.");
                    CloseLauncherProcessIfRequired();
                    return;
                }

                password = Uri.EscapeDataString(password);

                Process authProcess = StartProcess(Path.Combine(Properties.Settings.Default.SelectedFolderPath, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"), false, $"-AUTH_TYPE=epic -AUTH_LOGIN={email} -AUTH_PASSWORD={password}");

                authProcess.WaitForInputIdle();

                int processId = authProcess.Id;
                foreach (string file in requiredFiles)
                {
                    string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.dll));
                    System.Threading.Thread.Sleep(40000);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.memory));
                    System.Threading.Thread.Sleep(20000);
                    inject.InjectDll(processId, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), game.console));
                }

                authProcess.WaitForExit();
            });

            base.Show();
            LaunchButton.Text = "Launch";
        }

        private void FadeOnLaunch_Tick(object sender, EventArgs e) // idek anymore this is to hard to do in C#
        {
            int speed = 100;
            int targetR = 227;
            int targetG = 64;
            int targetB = 57;

            if (LaunchButton.FillColor.R > targetR)
                LaunchButton.FillColor = Color.FromArgb(Math.Max(LaunchButton.FillColor.R - speed, targetR), LaunchButton.FillColor.G, LaunchButton.FillColor.B);
            else if (LaunchButton.FillColor.R < targetR)
                LaunchButton.FillColor = Color.FromArgb(Math.Min(LaunchButton.FillColor.R + speed, targetR), LaunchButton.FillColor.G, LaunchButton.FillColor.B);
            else if (LaunchButton.FillColor.G > targetG)
                LaunchButton.FillColor = Color.FromArgb(LaunchButton.FillColor.R, Math.Max(LaunchButton.FillColor.G - speed, targetG), LaunchButton.FillColor.B);
            else if (LaunchButton.FillColor.G < targetG)
                LaunchButton.FillColor = Color.FromArgb(LaunchButton.FillColor.R, Math.Min(LaunchButton.FillColor.G + speed, targetG), LaunchButton.FillColor.B);
            else if (LaunchButton.FillColor.B > targetB)
                LaunchButton.FillColor = Color.FromArgb(LaunchButton.FillColor.R, LaunchButton.FillColor.G, Math.Max(LaunchButton.FillColor.B - speed, targetB));
            else if (LaunchButton.FillColor.B < targetB)
                LaunchButton.FillColor = Color.FromArgb(LaunchButton.FillColor.R, LaunchButton.FillColor.G, Math.Min(LaunchButton.FillColor.B + speed, targetB));

            if (LaunchButton.FillColor.R == targetR && LaunchButton.FillColor.G == targetG && LaunchButton.FillColor.B == targetB)
            {
                LaunchButton.Text = "Fortnite is running";
                LaunchButton.ForeColor = Color.FromArgb(248, 204, 202);
                LockedPictureBox.Visible = true;
                buttonfadingredonlaunch.Stop();
                buttonfadingredonlaunch.Dispose();
            }
        }
        // End on Launching Fortnite

        private void FortnitePathButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Make sure you select the folder containing the 'Engine' and 'FortniteGame' folders";
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.SelectedPath = Properties.Settings.Default.SelectedFolderPath;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    if (Directory.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "Engine")) &&
                        Directory.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "FortniteGame")))
                    {
                        Properties.Settings.Default.SelectedFolderPath = folderBrowserDialog.SelectedPath;
                        Properties.Settings.Default.Save();
                        FortnitePath.Text = folderBrowserDialog.SelectedPath;
                        FortnitePathButton.Text = "Change Fortnite Path";
                    }
                    else
                    {
                        Properties.Settings.Default.SelectedFolderPath = "";
                        FortnitePath.Text = "";
                        MessageBox.Show("Hmm seems like the 'Engine' and 'FortniteGame' folders aren't found. Re-enter your path containing them.", "Retrac-Remake Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FortnitePathButton.Text = "Select Fortnite Path";
                    }
                }
            }
        }

        private void DiscordButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://dsc.gg/sxlar");
        }

        private void PlayersOnlineLabel_Click(object sender, EventArgs e)
        {

        }

        private void LaunchButton_MouseHover(object sender, EventArgs e)
        {
            LockedPictureBox.BackColor = Color.FromArgb(231, 92, 86);
        }

        private void LockedPictureBox_MouseHover(object sender, EventArgs e)
        {
            LockedPictureBox.BackColor = Color.FromArgb(231, 92, 86);
        }

        private void LaunchButton_MouseEnter(object sender, EventArgs e)
        {
            LockedPictureBox.BackColor = Color.FromArgb(231, 92, 86);
        }

        private void LaunchButton_MouseLeave(object sender, EventArgs e)
        {
            LockedPictureBox.BackColor = Color.FromArgb(227, 64, 57);
        }

        private void SettingsPictureBox_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}