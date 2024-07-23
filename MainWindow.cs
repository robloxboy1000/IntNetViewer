using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace IntNetViewer
{
    public partial class MainWindow : Form
    {
        private string version = "v" + Application.ProductVersion;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region update
        private void CheckForUpdates()
        {
            string owner = "robloxboy100058";
            string repo = "IntNetViewer-Windows";
            string apiUrl = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("User-Agent", "Mozilla/5.0");
                    string json = webClient.DownloadString(apiUrl);
                    JObject releaseInfo = JObject.Parse(json);
                    string latestVersion = releaseInfo["tag_name"].ToString();
                    if (IsUpdateAvailable(latestVersion))
                    {
                        MessageBox.Show($"An update is available. Please visit the download page to get the latest version.\r\nNew Version: {latestVersion}\r\nCurrent Version: {version}",
                            "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start("https://github.com/robloxboy100058/IntNetViewer-Windows/releases/latest");
                    }
                    else
                    {
                        MessageBox.Show($"You are using the latest version of the web browser.\r\nCurrent Version: {version}\r\nGitHub Version: {latestVersion}",
                            "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}",
                    "Update Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsUpdateAvailable(string latestVersion)
        {
            string currentVersion = version;
            return latestVersion.CompareTo(currentVersion) > 0;
        }
        
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_New aboutForm = new About_New();
            aboutForm.ShowDialog();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = toolStripTextBox1.Text;
                webBrowser1.Navigate(url);
            }
        }

        private void toolStripBtnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripBtnFwd_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripBtnReload_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripBtnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://robloxboy1000.neocities.org");
        }

        private void toolStripBtnStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://robloxboy1000.neocities.org");
        }
    }
}
