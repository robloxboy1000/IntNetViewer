using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Media;
using WeifenLuo.WinFormsUI.Docking;
using System.Net;
using System.Text.RegularExpressions;


namespace IntNetViewer
{
    /// <summary>
    /// main IntNetViewer window
    /// </summary>
    public partial class MainWindow : Form
    {
        private readonly string configFilePath = "config.ini";
        private string homePage = "intnet://assets/newtab.html"; // Default home page
        private DockPanel dockPanel;
        public static MainWindow Instance;
        public string appPath = Application.StartupPath;
        private readonly List<string> history = new List<string>();
        public HostHandler host;
        private DownloadHandler dHandler;
        private LifeSpanHandler lHandler;
        private ContextMenuHandler mHandler;
        public Dictionary<int, DownloadItem> downloads;
        public Dictionary<int, string> downloadNames;
        public List<int> downloadCancelRequests;
        public Timer ifCefdidntinit = new Timer();
        private bool isFullScreen = false;
        private FormWindowState oldWindowState;
        private FormBorderStyle oldBorderStyle;
        public string pageTitle;
        private Icon favicon;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            WindowManager.OpenWindows++;  // Increment when a new window is opened
            InitializeCef();
            InitializeBrowserTabs();
            
            EnableHomeButton();
            LoadHistoryFromFile();
            // Attach event handlers for tab changes
            //dockPanel.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            dockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;

            

        }
        private void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            UpdateNavigationControls();
            UpdateAddressBar();
        }
        private void InitHotkeys()
        {

            
            KeyboardHandler.AddHotKey(this, ToggleFullscreen, Keys.F11);


        }
        public void ToggleFullscreen()
        {
            var browser = GetCurrentBrowser();
            if (!isFullScreen)
            {
                oldWindowState = this.WindowState;
                oldBorderStyle = this.FormBorderStyle;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
                toolStripContainer3.Visible = false;
                panel2.Visible = false;
                panel1.Visible = false;
                statusStrip1.Visible = false;
                dockPanel.Dock = DockStyle.Fill;
                dockPanel.Location = new Point(0, 0);
                browser.BringToFront();
                dockPanel.Visible = true;
                browser.Dock = DockStyle.Fill;
            }
            else
            {
                this.FormBorderStyle = oldBorderStyle;
                this.WindowState = oldWindowState;
                isFullScreen = false;
                toolStripContainer3.Visible = true;
                panel2.Visible = true;
                panel1.Visible = true;
                statusStrip1.Visible = true;
                dockPanel.Dock = DockStyle.None;
                dockPanel.Location = new Point(0, 72);
                dockPanel.Size = new Size(784, 467);
                dockPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                dockPanel.Visible = true;
                browser.Dock = DockStyle.Fill;
            }
        }
        private void WaitToSaveHistory()
        {
            Timer timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += (sender, e) =>
            {
                SaveHistoryToFile();
                timer.Stop();
            };
        }

        private void SaveHistoryToFile()
        {
            File.WriteAllLines("./assets/history.txt", history);
        }

        private void LoadHistoryFromFile()
        {
            if (File.Exists("./assets/history.txt"))
            {
                history.AddRange(File.ReadAllLines("./assets/history.txt"));
            }
            else
            {
                File.Create("./assets/history.txt");
            }
        }
        private void ClearHistory()
        {
            history.Clear();
            SaveHistoryToFile();
        }

        // Loads settings file
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
        // Initializes CEF with config file
        private void InitializeCef()
        {
            var settings = LoadSettings();
            
            CefSettings cefSettings = new CefSettings();
            // Apply settings loaded from the config file
            if (settings.TryGetValue("CachePath", out string cachePath))
            {
                cefSettings.CachePath = Path.GetFullPath(cachePath);
            }
            if (settings.TryGetValue("UserAgent", out string userAgent))
            {
                cefSettings.UserAgent = userAgent;
            }
            if (settings.TryGetValue("DarkMode", out string darkModeValue) && darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                cefSettings.BackgroundColor = 0;
            }
            cefSettings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "intnet",
                SchemeHandlerFactory = new SchemeHandlerFactory(),
                IsStandard = true, // Ensures it's treated like a normal protocol
                IsCorsEnabled = true, // Allows Fetch API to work
                IsFetchEnabled = true, // Allows Fetch API to work
                IsCSPBypassing = true // Allows bypassing CSP
            });
            cefSettings.IgnoreCertificateErrors = true;
            cefSettings.WindowlessRenderingEnabled = true;

            

            if (settings.TryGetValue(settings["GPUAcceleration"], out string gpuAccelerationValue) && gpuAccelerationValue.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                cefSettings.CefCommandLineArgs.Add("disable-gpu", "1");
            }
            if (settings.TryGetValue(settings["ShowFPSCounter"], out string fpsValue) && fpsValue.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                cefSettings.CefCommandLineArgs.Add("show-fps-counter", "1");
            }

            if (Cef.IsInitialized == null)
            {
                Cef.Initialize(cefSettings);
            }
            homePage = settings.ContainsKey("HomePage") ? settings["HomePage"] : homePage;
            dHandler = new DownloadHandler(this);
            InitDownloads();
            host = new HostHandler(this);
            mHandler = new ContextMenuHandler(this);
            lHandler = new LifeSpanHandler(this);

        }


        private void ApplyTheme()
        {
            var settings = LoadSettings();

            bool isDarkMode = settings.TryGetValue("DarkMode", out string darkModeValue) &&
                              darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase);


            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);    // Dark background
                this.ForeColor = Color.White;                   // Light text
                

                foreach (Control ctrl in this.Controls)
                {
                    ApplyDarkTheme(ctrl);
                }
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                
                
            }
        }

        private void EnableHomeButton()
        {
            var settings = LoadSettings();

            bool isHomeButtonEnabled = settings.TryGetValue("EnableHomeButton", out string enabledValue) &&
                              enabledValue.Equals("true", StringComparison.OrdinalIgnoreCase);

            if (isHomeButtonEnabled)
            {
                homeToolStripButton.Visible = true;
            }
            else {
                homeToolStripButton.Visible = false;
            }

        }

        private void ApplyDarkTheme(Control control)
        {
            control.BackColor = Color.FromArgb(45, 45, 48);
            control.ForeColor = Color.White;
            
            
            foreach (Control child in control.Controls)
            {
                ApplyDarkTheme(child);
            }
        }

        private void InitializeBrowserTabs()
        {
            // Create the TabControl
            dockPanel = new DockPanel
            {
                Dock = DockStyle.None,
                Location = new Point(0, 72),
                Size = new Size(784, 467),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            this.Controls.Add(dockPanel);

            // Configure TabControl for OwnerDraw (for close buttons)
            //dockPanel.DrawMode = TabDrawMode.OwnerDrawFixed;
            //dockPanel.DrawItem += TabControl_DrawItem;
            //dockPanel.MouseUp += TabControl_MouseUp;
            dockPanel.ContentRemoved += DockPanel_ContentRemoved;

            // Add the first browser tab
            AddNewTab("intnet://assets/newtab.html");
        }

        private void DockPanel_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if (dockPanel.Contents.Count == 0)
            {
                Application.Exit();
            }
        }

        public void AddNewTab(string url)
        {
            var settings = LoadSettings();
            bool isDarkMode = settings.TryGetValue("DarkMode", out string darkModeValue) && darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase);
            if (isDarkMode)
            {
                var theme = new VS2015DarkTheme();
                dockPanel.Theme = theme;
            }
            else
            {
                var theme = new VS2015LightTheme();
                dockPanel.Theme = theme;
            }
            
            var newTab = new BrowserTab(url);
            newTab.Show(dockPanel, DockState.Document);
            var browser = GetCurrentBrowser();
            //DockContent tab = new DockContent();
            //browser = new ChromiumWebBrowser(url)
            //{
            //    Dock = DockStyle.Fill,
            //};
            //browser.BringToFront();
            // Attach event handlers
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            browser.StatusMessage += Browser_StatusMessage;
            browser.DownloadHandler = dHandler;
            browser.LifeSpanHandler = lHandler;

            browser.MenuHandler = mHandler;
            // get the favicon
            
                
            
                
                
            
            
            

            //tab.Controls.Add(browser);
            //tab.Show(dockPanel, DockState.Document);



            if (!history.Contains(url))
            {
                history.Add(url);
            }
            if (url.StartsWith(BrowserConfig.InternalURL + ":"))
            {
                
                browser.JavascriptObjectRepository.Register("host", host, true);
            }
        }
        void DownloadFavicon(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] imageData = client.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        using (Bitmap bmp = new Bitmap(ms))
                        {
                            IntPtr hIcon = bmp.GetHicon();
                            Icon icon = Icon.FromHandle(hIcon);

                            // Example: Set the icon to a Form
                            favicon = icon;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error downloading favicon: " + ex.Message);
                }
            }
        }
        private void InitDownloads()
        {
            downloads = new Dictionary<int, DownloadItem>();
            downloadNames = new Dictionary<int, string>();
            downloadCancelRequests = new List<int>();
        }

        public Dictionary<int, DownloadItem> Downloads
        {
            get
            {
                return downloads;
            }
        }

        public void UpdateDownloadItem(DownloadItem item)
        {
            lock (downloads)
            {

                // SuggestedFileName comes full only in the first attempt so keep it somewhere
                if (item.SuggestedFileName != "")
                {
                    downloadNames[item.Id] = item.SuggestedFileName;
                }

                // Set it back if it is empty
                if (item.SuggestedFileName == "" && downloadNames.ContainsKey(item.Id))
                {
                    item.SuggestedFileName = downloadNames[item.Id];
                }

                downloads[item.Id] = item;

                //UpdateSnipProgress();
            }
        }

        public string CalcDownloadPath(DownloadItem item)
        {
            return item.SuggestedFileName;
        }

        public bool DownloadsInProgress()
        {
            foreach (DownloadItem item in downloads.Values)
            {
                if (item.IsInProgress)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// open a new tab with the downloads URL
        /// </summary>
        private void BtnDownloads_Click(object sender, EventArgs e)
        {
            OpenDownloadsTab();
        }
        
        public void OpenDownloadsTab()
        {
            this.Invoke(new Action(() =>
            {
                
                    AddNewTab("intnet://assets/downloads.html");
                
            }));

        }
        public List<int> CancelRequests
        {
            get
            {
                return downloadCancelRequests;
            }
        }
        private void Browser_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            if (e.Value != null)
            {
                this.Invoke(new Action(() =>
                {
                    cefToolTipStatusLabel.Text = e.Value.ToString();
                }));
            }
        }

        private void UpdateNavigationControls()
        {
            var browser = GetCurrentBrowser();
            if (browser != null)
            {
                backButton.Enabled = browser.CanGoBack;
                forwardButton.Enabled = browser.CanGoForward;
                stopButton.Visible = browser.IsLoading;
                refreshButton.Visible = !browser.IsLoading;
            }
            else
            {
                backButton.Enabled = false;
                forwardButton.Enabled = false;
                stopButton.Visible = false;
                refreshButton.Visible = false;
            }
        }

        private void UpdateAddressBar()
        {
            var browser = GetCurrentBrowser();
            if (browser != null)
            {
                if (browser.Address == "intnet://assets/newtab.html")
                {
                    this.Invoke(new Action(() =>
                    {
                        addressTextBox.Text = string.Empty;
                        //searchPanel.Visible = true;
                    }));
                    
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        //searchPanel.Visible = false;
                        addressTextBox.Text = browser.Address;
                    }));
                }
            }
            else
            {
                addressTextBox.Text = string.Empty;
            }
        }

        private ChromiumWebBrowser GetCurrentBrowser()
        {
            return dockPanel.ActiveDocument is BrowserTab activeTab ? activeTab.Browser : null;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Back();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Forward();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Reload();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Stop();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            NavigateToAddress();
        }

        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NavigateToAddress();
            }
        }

        private void NavigateToAddress()
        {
            var browser = GetCurrentBrowser();
            if (browser != null)
            {
                string url = addressTextBox.Text.Trim();

                if (url.StartsWith("intnet:"))
                {
                    Console.WriteLine("Internal URL: " + url);
                    browser.Load(url);
                }
                else
                {
                    string processedUrl = EnsureValidUrl(url);
                    Console.WriteLine(processedUrl);
                    Console.WriteLine("External URL (Processed): " + processedUrl);
                    browser.Load(processedUrl);
                }
                if (!history.Contains(url))
                {
                    history.Add(url);
                }
            }
        }
        static string EnsureValidUrl(string input)
        {
            // Regex for checking if the string ends with a known TLD
            string tldPattern = @"\.(com|org|net|edu|gov|mil|int|io|co|uk|us|info|biz|tv|xyz|ca|de|fr|au|jp|cn|ru|in|br|za|eu|me|cc|us|[a-z]{2,})$";
            if (Regex.IsMatch(input, tldPattern, RegexOptions.IgnoreCase))
            {
                // If input has a TLD but is missing a scheme, add "http://"
                if (!input.StartsWith("http://") && !input.StartsWith("https://"))
                {
                    return "http://" + input;
                }
                return input;
            }
            else
            {
                // If no TLD is found, assume it's a search query
                return "https://www.google.com/search?q=" + Uri.EscapeDataString(input);
            }
        }

        // Cef Subscribed events
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
            if (!(sender is ChromiumWebBrowser browser))
                return;

            if (!(browser.Parent is BrowserTab tabPage))
                return;

            this.Invoke(new Action(() =>
            {
                tabPage.Text = e.Title.Length > 20 ? e.Title.Substring(0, 20) + "..." : e.Title;
                tabPage.ToolTipText = e.Title;
                this.Text = $"{e.Title.Trim()} - IntNetViewer";
                pageTitle = e.Title;
            }));
        }
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            if (!(sender is ChromiumWebBrowser browser))
                return;

            // Update the address bar if this browser is the active tab
            if (GetCurrentBrowser() == browser)
            {
                this.Invoke(new Action(() =>
                {
                    addressTextBox.Text = e.Address;
                }));
            }
        }
        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!(sender is ChromiumWebBrowser browser))
                return;

            // Update navigation buttons and stop button visibility
            this.Invoke(new Action(() =>
            {
                if (GetCurrentBrowser() == browser)
                {
                    backButton.Enabled = e.CanGoBack;
                    forwardButton.Enabled = e.CanGoForward;
                    stopButton.Visible = e.IsLoading;
                    refreshButton.Visible = !e.IsLoading;
                }
            }));
            this.Invoke(new Action(() =>
            {
                if (e.IsLoading)
                { 
                    labelLoading.Visible = true;
                }
                else
                {
                    labelLoading.Visible = false;
                }
            }));
        }
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            var browser = GetCurrentBrowser();
            var tab = (BrowserTab)browser.Parent;
            // Only inject into the main frame
            if (e.Frame.IsMain)
            {
                Console.WriteLine("Getting favicon...");
                await browser.GetMainFrame().EvaluateScriptAsync(@"
    (function() {
        var links = document.getElementsByTagName('link');
        for (var i = 0; i < links.length; i++) {
            if (links[i].rel.includes('icon')) {
                return links[i].href;
            }
        }
        return './assets/favicon.ico'; // Default favicon location
    })();
").ContinueWith(task =>
                {
                    if (!task.IsCompleted || task.Result?.Success != true) return;

                    string faviconUrl = task.Result.Result?.ToString();
                    if (!string.IsNullOrEmpty(faviconUrl))
                    {
                        DownloadFavicon(faviconUrl);
                        Console.WriteLine("Favicon URL: " + faviconUrl);

                    }
                });
                this.Invoke((MethodInvoker)(() => tab.Icon = favicon));
                this.Invoke((MethodInvoker)(() => this.Icon = favicon));
                Console.WriteLine("Favicon: " + favicon);
                var settings = LoadSettings();
                bool isDarkMode = settings.TryGetValue("DarkMode", out string darkModeValue) &&
                                  darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase);

                if (isDarkMode)
                {
                    
                        // Use the DevTools client to force dark mode
                        var devToolsClient = browser.GetDevToolsClient();
                        await devToolsClient.Emulation.SetAutoDarkModeOverrideAsync(true);
                        
                    
                }
            }
            if (!history.Contains(e.Url))
            {
                history.Add(e.Url);
            }
            UpdateAddressBar();
        }
        

        // Tab control
        
        
        
        
        

        private void NewTabButton_Click(object sender, EventArgs e)
        {
            AddNewTab("intnet://assets/newtab.html");
        }

        

        // Asyncronous button to check for updates via https://api.github.com/repos/robloxboy1000/IntNetViewer/releases/latest
        private async void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await UpdateChecker.CheckForUpdates();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_New aboutForm = new About_New();
            aboutForm.ShowDialog();
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            InitHotkeys();

#if DEBUG
            debugToolStripMenuItem.Visible = true;
#endif
            if (Cef.IsInitialized == null || Cef.IsInitialized == false)
            {
                ifCefdidntinit.Start();
                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
            else 
            {
                this.MaximizeBox = true;
                this.MinimizeBox = true;
            }
            // check for updates automatically via https://api.github.com/repos/robloxboy1000/IntNetViewer/releases/latest
            await UpdateChecker.CheckForUpdates();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the settings form
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(); // Show as a modal dialog
        }

        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This is not recommended. PLEASE use tabs instead of windows. Note: this has been fixed using a counter of open windows.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); // Don't show as a dialog
        }

        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTab("intnet://assets/newtab.html");
        }

        // This method calls Cef.Shutdown() when closed. Fix if possible. NOTE: Fixed
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ask user if they are sure
            if (DownloadsInProgress())
            {
                if (MessageBox.Show("Downloads are in progress. Cancel those and exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            var settings = LoadSettings();
            bool closeWarnMe = settings.TryGetValue("WarnOnExit", out string WarnValue) &&
                                  WarnValue.Equals("true", StringComparison.OrdinalIgnoreCase); ;
            if (closeWarnMe)
            {
                var result = MessageBox.Show("Are you sure you want to close the browser?", "Exit Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Prevent the application from closing
                }
                else
                {
                    // use "WaitToSaveHistory();" instead of "SaveHistoryToFile();" to save history before closing to let CEF dispose all resources
                    WindowManager.OpenWindows--;  // Decrement when a window is closed
                    if (WindowManager.OpenWindows == 0)
                    {
                        Cef.Shutdown();  // Shutdown only when no windows are open
                        WaitToSaveHistory();
                    }
                }
            }
            else
            {
                WindowManager.OpenWindows--;  // Decrement when a window is closed
                if (WindowManager.OpenWindows == 0)
                {
                    Cef.Shutdown();  // Shutdown only when no windows are open
                    WaitToSaveHistory();
                }
            }
        }

        private void PixlPlaya5OnYouTubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Load("https://youtube.com/@pixlplaya5");
            
        }

        private void PixlPlaya5OnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Load("https://github.com/robloxboy1000/");
            
        }
        private void InjectDarkModeCSS()
        {
            var browser = GetCurrentBrowser();

            string darkModeCSS = @"
        const style = document.createElement('style');
        style.innerHTML = `
            html, body {
                background-color: #121212 !important;
                color: #e0e0e0 !important;
            }
            a { color: #bb86fc !important; }
            img, video { filter: brightness(0.8) contrast(1.2); }
            * { border-color: #444 !important; }
        `;
        document.head.appendChild(style);
    ";
            
            // Inject JavaScript that appends the CSS to the page
            browser.ExecuteScriptAsync(darkModeCSS);
        }

        private void HomeToolStripButton_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = GetCurrentBrowser();
            browser?.Load(homePage);
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.Load("intnet://assets/history.html");
        }

        private void HistoryToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            historyToolStripMenuItem.DropDownItems.Clear();
            
            foreach (string url in history)
            {
                historyToolStripMenuItem.DropDownItems.Add(url.Length > 50 ? url.Substring(0, 50) + "..." : url);
            }
        }

        private void HistoryToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (string url in history)
            {
                if (e.ClickedItem.Text == url)
                {
                    // Only open in main tab
                    var browser = GetCurrentBrowser();
                    browser?.Load(url);

                }
            }
        }

        private void DevToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            browser?.ShowDevTools();
        }

        internal void RefreshActiveTab()
        {
            var browser = GetCurrentBrowser();
            browser?.Reload();
        }

        internal void CloseActiveTab()
        {
            if (dockPanel.ActiveDocument is BrowserTab activeTab)
            {
                activeTab.Close();
            }
        }

        private void FullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        private void LegacyModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LegacyMainWindow legacyMainWindow = new LegacyMainWindow();
            legacyMainWindow.Show();
        }

        private void ClearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearHistory();
        }

        /*
        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var browser = GetCurrentBrowser();
            if (e.KeyChar == (char)Keys.Enter)
            {
                browser.Load($"https://www.google.com/search?q={searchTextBox.Text}&udm=14"); // "udm=14" is a custom Google search parameter to only show web results (no images, videos, AI, etc.)
                searchPanel.Visible = false;
            }
        }*/

        private void BookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./assets/bookmarks.html"))
            {
                BookmarkManager.ExportBookmarksToHtml();
            }
            var browser = GetCurrentBrowser();
            browser.Load($"intnet://assets/bookmarks.html");
        }

        private void AddBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = GetCurrentBrowser();
            var bookmarks = BookmarkManager.LoadBookmarks();
            bookmarks.Add(new Bookmark { Name = pageTitle, Url = browser.Address });
            BookmarkManager.SaveBookmarks(bookmarks);
            BookmarkManager.ExportBookmarksToHtml();
        }
        private void ApplyDefaultTheme(Control control)
        {
            control.BackColor = SystemColors.Control;
            control.ForeColor = SystemColors.ControlText;


            foreach (Control child in control.Controls)
            {
                ApplyDefaultTheme(child);
            }
        }

        private void WriteLineToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello, World!");
        }

        private void WriteLineToConsoleDifferentMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.Write("Hello, World!\r\n");
        }

        private void InitializeNotifyIcon(string title, string text)
        {
            var notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information, // Use a built-in system icon
                Visible = true, // Make the icon visible in the system tray
                BalloonTipTitle = title,
                BalloonTipText = text,
                BalloonTipIcon = ToolTipIcon.Info,
                
            };

            // Show the notification
            notifyIcon.ShowBalloonTip(3000); // Display for 3 seconds
        }

        private void NotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeNotifyIcon("IntNetViewer", "test");
        }
    }
}
