using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        public Launcher()
        {
            InitializeComponent();
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
        }


        // so legit is has no features yet!
        private void LaunchButton_Click(object sender, EventArgs e)
        {
            string update = "attempting to update";
            Console.WriteLine(update);
        }
    }
}
