using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;

namespace IntNetViewer
{
    public partial class MainWindow : Form
    {
        private string configFilePath = "config.ini";
        private string homePage = "http://example.com"; // Default home page

        public MainWindow()
        {
            InitializeComponent();
            InitializeBrowser();

        }

        #region update
       /* private void CheckForUpdates()
        {
            string owner = "robloxboy1000";
            string repo = "IntNetViewer";
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
                        Process.Start("https://github.com/robloxboy1000/IntNetViewer/releases/latest");
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
        }*/
        
        private async void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await UpdateChecker.CheckForUpdates();
        }
        #endregion

        private void InitializeBrowser()
        {
            var settings = LoadSettings();

            // Initialize Cef with the settings
            CefSettings cefSettings = new CefSettings();

            // Apply settings loaded from the config file
            if (settings.TryGetValue("CachePath", out string cachePath))
            {
                cefSettings.CachePath = cachePath;
            }
            if (settings.TryGetValue("UserAgent", out string userAgent))
            {
                cefSettings.UserAgent = userAgent;
            }

            Cef.Initialize(cefSettings);

            // Create the browser and set the home page
            homePage = settings.ContainsKey("HomePage") ? settings["HomePage"] : homePage;
            chromiumWebBrowser1.Load(homePage);

            // JavaScript settings
            if (settings.TryGetValue("JavaScriptEnabled", out string jsEnabled) && bool.TryParse(jsEnabled, out bool jsEnabledBool))
            {
                chromiumWebBrowser1.JavascriptObjectRepository.Settings.LegacyBindingEnabled = jsEnabledBool;
            }

            
        }

        private Dictionary<string, string> LoadSettings()
        {
            var settings = new Dictionary<string, string>();

            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    if (line.Contains("="))
                    {
                        var parts = line.Split('=');
                        var key = parts[0].Trim();
                        var value = parts[1].Trim();
                        settings[key] = value;
                    }
                }
            }

            return settings;
        }

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
                //webBrowser1.Navigate(url);
                chromiumWebBrowser1.LoadUrl(url);
            }
        }

        private void toolStripBtnBack_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
            if (chromiumWebBrowser1.CanGoBack)
            {
                chromiumWebBrowser1.Back();
            }
            
        }

        private void toolStripBtnFwd_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
            if (chromiumWebBrowser1.CanGoForward)
            {
                chromiumWebBrowser1.Forward();
            }
            
        }

        private void toolStripBtnReload_Click(object sender, EventArgs e)
        {
            //webBrowser1.Refresh();
            chromiumWebBrowser1.Refresh();
        }

        private void toolStripBtnHome_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://robloxboy1000.neocities.org");
            chromiumWebBrowser1.Load(homePage);  
        }

        private void toolStripBtnStop_Click(object sender, EventArgs e)
        {
            //webBrowser1.Stop();
            chromiumWebBrowser1.Stop();
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            await UpdateChecker.CheckForUpdates();
            //webBrowser1.Navigate("https://robloxboy1000.neocities.org");
            chromiumWebBrowser1.Load("https://robloxboy1000.neocities.org");
        }

        private void chromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new Action(() => 
            {
                toolStripTextBox1.Text = e.Address.ToString();
            }));

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the settings form
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(); // Show as a modal dialog
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Get the text from the searchTextBox
                string searchQuery = searchTextBox.Text;

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Use a search engine URL template to perform a search
                    string searchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(searchQuery)}&udm=14";
                    chromiumWebBrowser1.Load(searchUrl);
                }
                else
                {
                    MessageBox.Show("Please enter a search term.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
