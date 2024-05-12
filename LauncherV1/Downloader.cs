using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LauncherV1
{
    public partial class Downloader : Form
    {
        private const int CORNER_RADIUS = 5; // the gui corner radius (can be changed)
        private const int FADE_INTERVAL = 6;
        private const double FADE_STEP = 0.03; // fade in speed (can be changed)
        private double currentOpacity = 0.0;
        private System.Windows.Forms.Timer fadeTimer;

        private Point destination;
        private bool isFadingIn = false;
        private bool isFadingOut = false;

        public Downloader()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = FADE_INTERVAL;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            destination = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);

            this.Location = new Point(screenWidth, (screenHeight - this.Height) / 2);
        }

        private void Downloader_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            isFadingIn = true; // if this is false the GUI will not load!!!!! DON'T CHANGE THIS
        }

        public void SetProgress(int percentage)
        {
            ProgressBar.Value = Math.Min(percentage, 100);
        }

        public async void FadeOut()
        {
            while (Opacity > 0)
            {
                Opacity -= 0.1;
                Opacity = Math.Max(Opacity, 0);
                await Task.Delay(50);
            }
            Close();
        }

        public async void FadeOutLabel()
        {
            while (labelStatus.ForeColor.A > 0)
            {
                labelStatus.ForeColor = Color.FromArgb(Math.Max(labelStatus.ForeColor.A - 10, 0), labelStatus.ForeColor.R, labelStatus.ForeColor.G, labelStatus.ForeColor.B);
                await Task.Delay(50);
            }
            labelStatus.Text = "";
        }

        public async void FadeIn()
        {
            while (Opacity < 1)
            {
                Opacity += 0.1;
                Opacity = Math.Min(Opacity, 1);
                await Task.Delay(50);
            }
        }

        public void UpdateStatus(string status)
        {
            if (labelStatus.InvokeRequired)
            {
                labelStatus.Invoke(new Action(() => labelStatus.Text = status));
            }
            else
            {
                labelStatus.Text = status;
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

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
