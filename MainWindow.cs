using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;
using IntNetViewer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;




namespace IntNetViewer
{
    /// <summary>
    /// main IntNetViewer window
    /// </summary>
    public partial class MainWindow : Form
    {
        #region Local Variables
        private readonly string configFilePath = "config.cfg";
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
        private bool isFullScreen = false;
        private FormWindowState oldWindowState;
        private FormBorderStyle oldBorderStyle;
        public string pageTitle;
        private Icon favicon;
        private int backButtonHoldTime = 0;
        private const int HoldThreshold = 500; // 500ms for long press
        #endregion
        #region Constructor
        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            WindowManager.OpenWindows++;  // Increment when a new window is opened
            if (Program.noCef)
            {
                // If noCef is true, don't initialize CEF
                
                // plan to use compatible web browser control
                InitializeBrowserTabs();
                // Attach event handlers for tab changes
                dockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;
            }
            else
            {
                InitializeCef();
                InitializeBrowserTabs();
                // Attach event handlers for tab changes
                dockPanel.ActiveDocumentChanged += DockPanel_ActiveDocumentChanged;
            }
                
            
            EnableHomeButton();
            LoadHistoryFromFile();
            
        }
        #endregion
        #region UI/ Main UI Initialization
        /// <summary>
        /// Event happens when MainWindow is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                List<Bookmark> bookmarks = BookmarkManager.LoadBookmarks();
                PopulateBookmarks(bookmarks, toolStrip1);
                ApplyTheme();
                InitHotkeys();
#if DEBUG
                debugToolStripMenuItem.Visible = true;
#endif
                if (Program.noCef)
                {
                    this.Text = "IntNetViewer (Legacy Mode)";
                }
                else
                {
                    this.Text = "IntNetViewer";
                    if (Cef.IsInitialized == null || Cef.IsInitialized == false)
                    {

                        this.MaximizeBox = false;
                        this.MinimizeBox = false;
                    }
                    else
                    {
                        this.MaximizeBox = true;
                        this.MinimizeBox = true;
                    }
                }
                
                // check for updates automatically via https://api.github.com/repos/robloxboy1000/IntNetViewer/releases/latest
                await UpdateChecker.CheckForUpdates();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading MainWindow: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // This method calls Cef.Shutdown() when closed. Fix if possible. NOTE: Fixed
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.noCef)
            {

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
                              // Shutdown only when no windows are open
                            WaitToSaveHistory();
                        }
                    }
                }
                else
                {
                    WindowManager.OpenWindows--;  // Decrement when a window is closed
                    if (WindowManager.OpenWindows == 0)
                    {
                          // Shutdown only when no windows are open
                        WaitToSaveHistory();
                    }
                }
            }
            else
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
            
        }
        /// <summary>
        /// Loads settings file "config.cfg"; if file is not found, create new file with default settings.
        /// </summary>
        /// <returns></returns>
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
            else
            {
                MessageBox.Show("Config file not found. Creating a new one.", "Config file not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                try
                {
                    using (StreamWriter writer = new StreamWriter(configFilePath))
                    {
                        writer.WriteLine("[BrowserSettings]");
                        writer.WriteLine($"HomePage = http://google.com");
                        writer.WriteLine($@"CachePath = ./cache/");
                        writer.WriteLine($"UserAgent = Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{Cef.ChromiumVersion} Safari/537.36");
                        writer.WriteLine($"GPUAcceleration = true");
                        writer.WriteLine($"ShowFPSCounter = false");
                        writer.WriteLine($"UseAppDataAsCache = true");
                        writer.WriteLine("[General]");
                        writer.WriteLine($"DarkMode = false");
                        writer.WriteLine($"EnableHomeButton = true");
                        writer.WriteLine($"WarnOnExit = true");
                        writer.WriteLine("[Theme]");
                        writer.WriteLine($"AllowCustomTheme = false");
                        writer.WriteLine($"BackgroundColor = SystemColors.Control");
                        writer.WriteLine($"ForegroundColor = SystemColors.ControlText");
                        writer.WriteLine("[Proxy]");
                        writer.WriteLine($"EnableProxy = false");
                        writer.WriteLine($"Host = http://");
                        writer.WriteLine($"Port = 8080");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating config file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
        /// <summary>
        /// Initialize hotkeys
        /// </summary>
        private void InitHotkeys()
        {
            KeyboardHandler.AddHotKey(this, ToggleFullscreen, Keys.F11);
        }
        
        /// <summary>
        /// Changes MainWindow styles for fullscreen (broken)
        /// </summary>
        public void ToggleFullscreen()
        {
            if (Program.noCef)
            {
                return;
            }
            else
            {
                var browser = GetCurrentBrowser();
                if (!isFullScreen)
                {
                    oldWindowState = this.WindowState;
                    oldBorderStyle = this.FormBorderStyle;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }
                else
                {
                    this.FormBorderStyle = oldBorderStyle;
                    this.WindowState = oldWindowState;
                    isFullScreen = false;
                }
            }
                
        }
        /// <summary>
        /// This event is used when IntNetViewer is closing; waits for CEF to finish disposing before saving history
        /// </summary>
        private void WaitToSaveHistory()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            timer.Tick += (sender, e) =>
            {
                SaveHistoryToFile();
                timer.Stop();
            };
        }
        /// <summary>
        /// Save history traditionally
        /// </summary>
        private void SaveHistoryToFile()
        {
            File.WriteAllLines("./assets/history.txt", history);
        }
        /// <summary>
        /// Loads history.txt, Creates new history.txt if file isn't found
        /// </summary>
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
        /// <summary>
        /// Clears the history. Pretty simple.
        /// </summary>
        private void ClearHistory()
        {
            history.Clear();
            SaveHistoryToFile();
        }
        private void ApplyTheme()
        {
            var settings = LoadSettings();

            bool isDarkMode = settings.TryGetValue("DarkMode", out string darkModeValue) &&
                              darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase);
            bool allowCustomTheme = settings.TryGetValue("AllowCustomTheme", out string allowCustomThemeValue) &&
                              allowCustomThemeValue.Equals("true", StringComparison.OrdinalIgnoreCase);


            if (isDarkMode)
            {
                this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);    // Dark background
                this.ForeColor = System.Drawing.Color.White;                   // Light text


                foreach (Control ctrl in this.Controls)
                {
                    ApplyDarkTheme(ctrl);
                }
            }
            else if (allowCustomTheme)
            {
                if (settings.TryGetValue("BackgroundColor", out string backgroundColor) && settings.TryGetValue("ForegroundColor", out string foregroundColor))
                {
                    if (!backgroundColor.Equals("SystemColors.Control") && !foregroundColor.Equals("SystemColors.ControlText"))
                    {
                        this.BackColor = SystemColors.Control;
                        this.ForeColor = SystemColors.ControlText;
                    }
                    else
                    {
                        // Convert hex color to Color object
                        if (backgroundColor.StartsWith("#"))
                        {
                            backgroundColor = backgroundColor.Replace("#", "#FF");
                        }
                        if (foregroundColor.StartsWith("#"))
                        {
                            foregroundColor = foregroundColor.Replace("#", "#FF");
                        }
                        this.BackColor = ColorTranslator.FromHtml(backgroundColor);
                        this.ForeColor = ColorTranslator.FromHtml(foregroundColor);
                        ApplyCustomTheme(this, ColorTranslator.FromHtml(backgroundColor), ColorTranslator.FromHtml(foregroundColor));

                    }

                }
                else
                {
                    ApplyDefaultTheme(this);
                }
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;


            }
        }
        private void ApplyCustomTheme(Control control, Color backgroundColor, Color foregroundColor)
        {
            control.BackColor = backgroundColor;
            control.ForeColor = foregroundColor;
            foreach (Control child in control.Controls)
            {
                ApplyCustomTheme(child, backgroundColor, foregroundColor);
            }
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
        private void ApplyDarkTheme(Control control)
        {
            control.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            control.ForeColor = System.Drawing.Color.White;


            foreach (Control child in control.Controls)
            {
                ApplyDarkTheme(child);
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
            else
            {
                homeToolStripButton.Visible = false;
            }

        }


        private void BtnDownloads_Click(object sender, EventArgs e)
        {
            OpenDownloadsTab();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.GoBack();
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Back();
            }
            
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.GoForward();
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Forward();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Refresh();
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Reload();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Stop();
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Stop();
            }
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
        

        private void PopulateBookmarks(List<Bookmark> bookmarks, ToolStrip toolStrip)
        {
            toolStrip.Items.Clear(); // Clear existing items

            foreach (var bookmark in bookmarks)
            {
                if (!string.IsNullOrEmpty(bookmark.Url))
                {
                    // It's a regular bookmark
                    var button = new ToolStripButton(bookmark.Name);
                    button.Tag = bookmark.Url; // Store URL for navigation
                    button.Click += BookmarkButton_Click;
                    toolStrip.Items.Add(button);
                }
                else if (bookmark.Children != null && bookmark.Children.Count > 0)
                {
                    // It's a folder
                    var dropdown = new ToolStripDropDownButton(bookmark.Name);
                    AddFolderItems(dropdown, bookmark.Children);
                    toolStrip.Items.Add(dropdown);
                }
            }
        }

        private void AddFolderItems(ToolStripDropDownButton dropdown, List<Bookmark> children)
        {
            foreach (var child in children)
            {
                if (!string.IsNullOrEmpty(child.Url))
                {
                    var item = new ToolStripMenuItem(child.Name);
                    item.Tag = child.Url;
                    item.Click += BookmarkButton_Click;
                    dropdown.DropDownItems.Add(item);
                }
                else if (child.Children != null && child.Children.Count > 0)
                {
                    var subFolder = new ToolStripMenuItem(child.Name);
                    AddSubFolderItems(subFolder, child.Children);
                    dropdown.DropDownItems.Add(subFolder);
                }
            }
        }

        private void AddSubFolderItems(ToolStripMenuItem menuItem, List<Bookmark> children)
        {
            foreach (var child in children)
            {
                if (!string.IsNullOrEmpty(child.Url))
                {
                    var item = new ToolStripMenuItem(child.Name);
                    item.Tag = child.Url;
                    item.Click += BookmarkButton_Click;
                    menuItem.DropDownItems.Add(item);
                }
                else if (child.Children != null && child.Children.Count > 0)
                {
                    var subFolder = new ToolStripMenuItem(child.Name);
                    AddSubFolderItems(subFolder, child.Children);
                    menuItem.DropDownItems.Add(subFolder);
                }
            }
        }

        private void BookmarkButton_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            string url = item.Tag as string;
            if (!string.IsNullOrEmpty(url))
            {

                if (Program.noCef)
                {
                    var browser = GetCurrentOldBrowser();
                    browser?.Navigate(url);
                }
                else
                {
                    var browser = GetCurrentBrowser();
                    browser?.Load(url);
                }
            }
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



        private void PixlPlaya5OnYouTubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Navigate("https://youtube.com/@pixlplaya5");
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Load("https://youtube.com/@pixlplaya5");
            }
            

        }

        private void PixlPlaya5OnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Navigate("https://github.com/robloxboy1000");
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Load("https://github.com/robloxboy1000/");
            }
                

        }
        private void HomeToolStripButton_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Navigate(homePage);
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Load(homePage);
            }
            
        }

        private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./assets/history.html"))
            {
                File.Create("./assets/history.html").Close();
            }
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Navigate("intnet://assets/history.html");
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Load("intnet://assets/history.html");
            }
            
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
                    if (Program.noCef)
                    {
                        var browser = GetCurrentOldBrowser();
                        browser?.Navigate(url);
                    }
                    else
                    {
                        var browser = GetCurrentBrowser();
                        browser?.Load(url);
                    }
                        // Only open in main tab
                       

                }
            }
        }

        private void DevToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                MessageBox.Show("DevTools are not available in this mode.", "DevTools", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.ShowDevTools();
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

        private void BookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./assets/bookmarks.html"))
            {
                BookmarkManager.ExportBookmarksToHtml();
            }
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                browser?.Navigate($"intnet://assets/bookmarks.html");
            }
            else
            {
                var browser = GetCurrentBrowser();
                browser?.Load($"intnet://assets/bookmarks.html");
            }
            
        }

        private void AddBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                pageTitle = browser?.DocumentTitle;
                var bookmarks = BookmarkManager.LoadBookmarks();
                bookmarks.Add(new Bookmark { Name = pageTitle, Url = browser.Url.ToString() });
                BookmarkManager.SaveBookmarks(bookmarks);
                BookmarkManager.ExportBookmarksToHtml();
            }
            else
            {
                var browser = GetCurrentBrowser();
                var bookmarks = BookmarkManager.LoadBookmarks();
                bookmarks.Add(new Bookmark { Name = pageTitle, Url = browser.Address });
                BookmarkManager.SaveBookmarks(bookmarks);
                BookmarkManager.ExportBookmarksToHtml();
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



        private void NotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notify.NotifyIcon("IntNetViewer", "This is a test notification.", Resources.IntNetViewerIconImage, false);
        }

        private void testErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("This is a test error.");
        }

        private void backButton_MouseDown(object sender, MouseEventArgs e)
        {
            backButtonHoldTime = 0;
            holdTimer.Start();
        }

        private void backButton_MouseUp(object sender, MouseEventArgs e)
        {
            holdTimer.Stop();

            if (backButtonHoldTime < HoldThreshold)
            {
                // Quick click: go back in history
                if (Program.noCef)
                {
                    var browser = GetCurrentOldBrowser();
                    browser?.GoBack();
                }
                else
                {
                    var browser = GetCurrentBrowser();
                    browser?.Back();
                }
            }
            else
            {
                // Already showed history popup during hold
            }
        }

        private void holdTimer_Tick(object sender, EventArgs e)
        {
            backButtonHoldTime += holdTimer.Interval;

            if (backButtonHoldTime >= HoldThreshold)
            {
                holdTimer.Stop();
                ShowHistoryMenu();
            }
        }
        private void ShowHistoryMenu()
        {
            historyMenu.Items.Clear();

            // If you're using the same `history` list from before:
            foreach (string url in history)
            {
                var menuItem = new ToolStripMenuItem(url);
                menuItem.Click += (s, e) =>
                {
                    if (Program.noCef)
                    {
                        var browser = GetCurrentOldBrowser();
                        browser?.Navigate(url);
                    }
                    else
                    {
                        var browser = GetCurrentBrowser();
                        browser?.Load(url);
                    }
                };
                historyMenu.Items.Add(menuItem);
            }

            // Show the menu below the Back button
            Point menuLocation = backButton.PointToScreen(new Point(0, backButton.Height));
            historyMenu.Show(menuLocation);
        }

        private void importantNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notify.NotifyIcon("IntNetViewer", "This is a test notification that'll be here indefinitely.", Resources.IntNetViewerIconImage, true);
        }



        private void MainWindow_Shown(object sender, EventArgs e)
        {
#if DEBUG
            DialogResult dialogResult = MessageBox.Show("Can you see this window?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                return;
            }
            else
            {
                Application.Restart();
            }
#endif
        }

        private void dlWithoutChromiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StandaloneDLFormLoader form = new StandaloneDLFormLoader();
            form.Show();
        }

        private void getAppPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("App Path: " + appPath);
        }

        private async void hangUiThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Thread.Sleep(5000));
        }

        private void testVideoPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoPlayerLoader loader = new VideoPlayerLoader();
            loader.Show();
        }
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion
        #region Cef/Dockpanel related stuff
        /// <summary>
        /// Called on tab switched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            UpdateNavigationControls();
            UpdateAddressBar();
        }

        /// <summary>
        /// Initializes CEF with config file. if Progam.noCef is true, it will use the default web browser control.
        /// </summary>
        private void InitializeCef()
        {

            try
            {
                var settings = LoadSettings();
                CefSettings cefSettings = new CefSettings();
                // Apply settings loaded from the config file
                if (settings.TryGetValue("UseAppDataAsCache", out string appdataPath) && appdataPath.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    cefSettings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IntNetViewer", "cache");
                }
                if (appdataPath.Equals("false", StringComparison.OrdinalIgnoreCase))
                {
                    cefSettings.CachePath = Path.Combine(appPath, "cache");
                }
                if (settings.TryGetValue("UserAgent", out string userAgent))
                {
                    cefSettings.UserAgent = userAgent;
                }
                if (settings.TryGetValue("DarkMode", out string darkModeValue) && darkModeValue.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    cefSettings.BackgroundColor = 0;
                }
                if (settings.TryGetValue("EnableProxy", out string enableProxy) && enableProxy.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    if (settings.TryGetValue("Host", out string host) && settings.TryGetValue("Port", out string port))
                    {
                        cefSettings.CefCommandLineArgs.Add("proxy-server", $"{host}:{port}");
                    }
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
                //lHandler.OnBeforePopup += LHandler_OnBeforePopUp;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing CEF, {ex.Message}");
            }
        }

        private void InitializeBrowserTabs()
        {
            try
            {
                // Create the TabControl
                dockPanel = new DockPanel
                {
                    Dock = DockStyle.Fill,
                };
                mainCefPanel.Controls.Add(dockPanel);
            }
            catch
            {
                MessageBox.Show("Error creating DockPanel. Please check your installation.");
                return;
            }

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
            else
            {
                UpdateNavigationControls();
                UpdateAddressBar();
            }
        }

        public void AddNewTab(string url)
        {
            
            try
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
                if (Program.noCef)
                {
                    var browser = GetCurrentOldBrowser();

                    // Attach event handlers
                    browser.DocumentTitleChanged += OnOldBrowserTitleChanged;
                    browser.LocationChanged += OnOldBrowserAddressChanged;
                    browser.Navigating += Browser_Navigating;
                    browser.Navigated += Browser_Navigated;
                    browser.DocumentCompleted += Browser_DocumentCompleted;
                    browser.StatusTextChanged += Browser_StatusTextChanged;
                    if (!history.Contains(url))
                    {
                        history.Add(url);
                    }

                }
                else
                {
                    var browser = GetCurrentBrowser();
                    // Attach event handlers
                    browser.TitleChanged += OnBrowserTitleChanged;
                    browser.AddressChanged += OnBrowserAddressChanged;
                    browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
                    browser.FrameLoadEnd += Browser_FrameLoadEnd;
                    browser.StatusMessage += Browser_StatusMessage;
                    browser.DownloadHandler = dHandler;
                    browser.LifeSpanHandler = lHandler;
                    browser.MenuHandler = mHandler;
                    browser.JsDialogHandler = new JsDialogHandler();
                    browser.RequestHandler = new CustomRequestHandler();
                    browser.DragHandler = new DragHandler();
                    browser.KeyboardHandler = new KeyboardHandler(this);
                    if (!history.Contains(url))
                    {
                        history.Add(url);
                    }
                    if (url.StartsWith(BrowserConfig.InternalURL + ":"))
                    {
                        browser.JavascriptObjectRepository.Register("host", host, true);
                    }
                }
                    

                


                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating new tab: {ex.Message}");
                return;
            }

        }

        private void Browser_StatusTextChanged(object sender, EventArgs e)
        {
            if (sender is WebBrowser browser)
            {
                this.Invoke(new Action(() =>
                {
                    cefToolTipStatusLabel.Text = browser.StatusText;
                }));
            }
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (!(sender is WebBrowser browser))
                return;
            if (!history.Contains(browser.Url.ToString()))
            {
                history.Add(browser.Url.ToString());
            }
            UpdateAddressBar();
        }

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!(sender is WebBrowser browser))
                return;
            // Update navigation buttons and stop button visibility
            this.Invoke(new Action(() =>
            {
                if (GetCurrentOldBrowser() == browser)
                {
                    backButton.Enabled = browser.CanGoBack;
                    forwardButton.Enabled = browser.CanGoForward;
                    stopButton.Visible = browser.IsBusy;
                    refreshButton.Visible = !browser.IsBusy;
                }
            }));
            this.Invoke(new Action(() =>
            {
                if (browser.IsBusy)
                {
                    labelLoading.Visible = true;
                }
                else if (browser.ReadyState == WebBrowserReadyState.Complete)
                {
                    labelLoading.Visible = false;
                }
                else if (browser.ReadyState == WebBrowserReadyState.Loading)
                {
                    labelLoading.Visible = true;
                }
            }));
        }

        private void OnOldBrowserAddressChanged(object sender, EventArgs e)
        {
            if (!(sender is WebBrowser browser))
                return;
            // Update the address bar if this browser is the active tab
            if (GetCurrentOldBrowser() == browser)
            {
                this.Invoke(new Action(() =>
                {
                    addressTextBox.Text = browser.Url.ToString();
                }));
            }
        }

        private void OnOldBrowserTitleChanged(object sender, EventArgs e)
        {
            if (!(sender is WebBrowser browser))
                return;
            if (!(browser.Parent is BrowserTab tabPage))
                return;
            this.Invoke(new Action(() =>
            {
                tabPage.Text = browser.DocumentTitle.Length > 20 ? browser.DocumentTitle.Substring(0, 20) + "..." : browser.DocumentTitle;
                tabPage.ToolTipText = browser.DocumentTitle;
                this.Text = $"{browser.DocumentTitle.Trim()} - IntNetViewer";
                pageTitle = browser.DocumentTitle;
            }));
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
                            favicon = icon;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error downloading favicon: " + ex.Message);
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
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                if (browser != null)
                {
                    backButton.Enabled = browser.CanGoBack;
                    forwardButton.Enabled = browser.CanGoForward;
                    stopButton.Visible = browser.IsBusy;
                    refreshButton.Visible = !browser.IsBusy;
                }
                else
                {
                    backButton.Enabled = false;
                    forwardButton.Enabled = false;
                    stopButton.Visible = false;
                    refreshButton.Visible = false;
                }
            }
            else
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
                
        }

        private void UpdateAddressBar()
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                if (browser != null)
                {
                    if (browser.Url.ToString() == "intnet://assets/newtab.html")
                    {
                        this.Invoke(new Action(() =>
                        {
                            addressTextBox.Text = string.Empty;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            addressTextBox.Text = browser.Url.ToString();
                        }));
                    }
                }
                else
                {
                    addressTextBox.Text = string.Empty;
                }
            }
            else
            {
                var browser = GetCurrentBrowser();
                if (browser != null)
                {
                    if (browser.Address == "intnet://assets/newtab.html")
                    {
                        this.Invoke(new Action(() =>
                        {
                            addressTextBox.Text = string.Empty;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            addressTextBox.Text = browser.Address;
                        }));
                    }
                }
                else
                {
                    addressTextBox.Text = string.Empty;
                }
            }
                
        }

        private ChromiumWebBrowser GetCurrentBrowser()
        {
            return dockPanel.ActiveDocument is BrowserTab activeTab ? activeTab.cefBrowser : null;
        }

        private WebBrowser GetCurrentOldBrowser()
        {
            return dockPanel.ActiveDocument is BrowserTab activeTab ? activeTab.webBrowser : null;
        }



        private void NavigateToAddress()
        {
            if (Program.noCef)
            {
                var browser = GetCurrentOldBrowser();
                if (browser != null)
                {
                    string url = addressTextBox.Text.Trim();
                    if (url.StartsWith("intnet:"))
                    {
                        Console.WriteLine("Internal URL: " + url);
                        browser.Navigate(url);
                    }
                    else
                    {
                        string processedUrl = EnsureValidUrl(url);
                        Console.WriteLine(processedUrl);
                        Console.WriteLine("External URL (Processed): " + processedUrl);
                        browser.Navigate(processedUrl);
                    }
                    if (!history.Contains(url))
                    {
                        history.Add(url);
                    }
                }
                return;
            }
            else
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
                    if (url.StartsWith("chrome:"))
                    {
                        Console.WriteLine("Internal (Chrome) URL: " + url);
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
        }
        static string EnsureValidUrl(string input)
        {
            string tldPattern = @"\.(com|org|net|edu|gov|mil|int|io|co|uk|us|info|biz|tv|xyz|ca|de|fr|au|jp|cn|ru|in|br|za|eu|me|cc|us|dev|[a-z]{2,})($|/|\?|:)";

            // URL is assumed to have scheme

            // Check if the string ends with a known TLD
            if (Regex.IsMatch(input.Trim(), tldPattern, RegexOptions.IgnoreCase))
            {
                return input;
            }

            else
            {
                Console.WriteLine("No TLD was found.");
                // If no TLD is found, assume it's a search query
                return "https://www.google.com/search?q=" + Uri.EscapeDataString(input);
            }

            // Regex for checking if the string ends with a known TLD



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

        #endregion


    }
}
