using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public partial class NotificationForm : Form
    {
        private static int windowCount = 0;
        private static readonly int offsetY = 210; // pixels up per new window
        private static readonly int offsetX = 0; // pixels left per new window

        private Timer openTimer;
        private Timer closeTimer;
        private bool isClosing = false;
        private Point targetLocation;
        private Timer autoCloseTimer;
        public NotificationForm(string title, string text, string imageUrl, bool priority)
        {
            InitializeComponent();
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = Path.GetFullPath("C:\\Windows\\Media\\Windows Notify System Generic.wav");
            soundPlayer.Play();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            lblTitle.Text = title;
            rtfText.Text = text;
            picImage.ImageLocation = imageUrl;
            if (!priority) 
            {
                // Initialize the timer
                autoCloseTimer = new System.Windows.Forms.Timer();
                autoCloseTimer.Interval = 10000; // 10 seconds
                autoCloseTimer.Tick += autoCloseTimer_Tick; // Link the Tick event to the handler

                // Start the timer when the form loads
                autoCloseTimer.Start();
            }
            else
            {
                // Do nothing here
            }
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            // Position from bottom-right of full screen (including taskbar)
            var screenBounds = Screen.PrimaryScreen.Bounds;

            int baseX = screenBounds.Right - this.Width - 20;
            int baseY = screenBounds.Bottom - this.Height - 20;

            // Stack each window upward and to the left
            int stackedX = baseX - (offsetX * windowCount);
            int stackedY = baseY - (offsetY * windowCount);

            targetLocation = new Point(stackedX, stackedY);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(stackedX, screenBounds.Bottom); // Start off-screen

            openTimer = new Timer { Interval = 10 };
            openTimer.Tick += OpenTimer_Tick;
            openTimer.Start();

            windowCount++; // Increase for next window
        }

        private void OpenTimer_Tick(object sender, EventArgs e)
        {
            int step = 20;
            if (this.Top > targetLocation.Y)
            {
                this.Top = Math.Max(targetLocation.Y, this.Top - step);
            }
            else
            {
                this.Top = targetLocation.Y;
                openTimer.Stop();
                openTimer.Dispose();
            }
        }

        private void autoCloseTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            autoCloseTimer.Stop();

            // Close the form
            this.Close();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                closeTimer = new Timer { Interval = 10 };
                closeTimer.Tick += CloseTimer_Tick;
                closeTimer.Start();
                isClosing = true;
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            int step = 20;
            var screenBounds = Screen.PrimaryScreen.Bounds;

            if (this.Top < screenBounds.Bottom)
            {
                this.Top = Math.Min(screenBounds.Bottom, this.Top + step);
            }
            else
            {
                closeTimer.Stop();
                closeTimer.Dispose();
                windowCount = Math.Max(0, windowCount - 1); // Decrease
                this.Close();
            }
        }
    }
}
