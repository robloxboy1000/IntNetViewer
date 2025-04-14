using CefSharp.DevTools.Network;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IntNetViewer
{
    public partial class BorderlessVideoPlayer : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private string mrl = String.Empty; // Default URL
        private FromType mrlType;
        public BorderlessVideoPlayer(string mrl)
        {
            InitializeComponent();
            this.mrl = mrl;

        }

        private void BorderlessVideoPlayer_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.None;
            if (mrl == null)
            {
                MessageBox.Show("Invalid URL");
                this.Close();
            }
            if (mrl.StartsWith("https"))
            {
                mrlType = FromType.FromLocation;
            }
            else
            {
                mrlType = FromType.FromPath;
            }
            LibVLC libVLC = new LibVLC();
            videoView1.MediaPlayer = new MediaPlayer(libVLC);
            videoView1.MediaPlayer.Media = new LibVLCSharp.Shared.Media(libVLC, mrl, mrlType);
            videoView1.MediaPlayer.EndReached += videoView1_MediaPlayer_EndReached;
            videoView1.MediaPlayer.Buffering += MediaPlayer_Buffering;
            videoView1.MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;
            videoView1.MouseEnter += BorderlessVideoPlayer_MouseEnter;
            videoView1.MouseLeave += BorderlessVideoPlayer_MouseLeave;
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            Console.WriteLine($"An error occoured: {e}");
        }

        private void MediaPlayer_Buffering(object sender, MediaPlayerBufferingEventArgs e)
        {
            Console.WriteLine($"Loading video: {e.Cache} (caching information)");
        }

        private void videoView1_MediaPlayer_EndReached(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }

        private void BorderlessVideoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoView1.MediaPlayer.Dispose();
        }

        private void videoView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point menuLocation = videoView1.PointToScreen(new Point(0, videoView1.Height));
                contextMenuStrip1.Show(menuLocation);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorderlessVideoPlayer_Shown(object sender, EventArgs e)
        {
            videoView1.MediaPlayer.Play();
        }

        private void BorderlessVideoPlayer_MouseHover(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Opacity = 1;
        }

        private void BorderlessVideoPlayer_MouseEnter(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Opacity = 1;
        }

        private void BorderlessVideoPlayer_MouseLeave(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            /* nop */
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
