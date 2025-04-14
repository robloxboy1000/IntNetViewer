using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public partial class VideoPlayerLoader : Form
    {
        public VideoPlayerLoader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var videoPlayer = new BorderlessVideoPlayer(textBox1.Text.Trim());
            videoPlayer.Show();
        }
    }
}
