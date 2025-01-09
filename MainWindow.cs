using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;



namespace IntNetViewer
{
    public partial class MainWindow : Form
    {
        private string configFilePath = "config.ini";
        private string homePage = "http://example.com"; // Default home page
        private TabControl tabControl;
        
        
        

        public MainWindow()
        {
            InitializeComponent();
            InitializeCef();
            //InitializeUI();
            InitializeBrowserTabs();

            // Attach event handlers for tab changes
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

        }

        private void InitializeCef()
        {
            var settings = LoadSettings();
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
            if (Cef.IsInitialized == null)
            {
                Cef.Initialize(cefSettings);
            }
            homePage = settings.ContainsKey("HomePage") ? settings["HomePage"] : homePage;
        }
        // This way of rendering UI is deprecated. Please do not uncomment this.
       /* private void InitializeUI()
        {
            

            // Initialize ToolStrip
            navigationToolStrip = new ToolStrip();
            navigationToolStrip.GripStyle = ToolStripGripStyle.Hidden;

            // Back Button
            backButton = new ToolStripButton
            {
                Image = Properties.Resources.back_icon, // Replace with your back icon
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Enabled = false
            };
            backButton.Click += BackButton_Click;
            navigationToolStrip.Items.Add(backButton);

            // Forward Button
            forwardButton = new ToolStripButton
            {
                Image = Properties.Resources.forward_icon, // Replace with your forward icon
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Enabled = false
            };
            forwardButton.Click += ForwardButton_Click;
            navigationToolStrip.Items.Add(forwardButton);

            // Refresh Button
            refreshButton = new ToolStripButton
            {
                Image = Properties.Resources.refresh_icon, // Replace with your refresh icon
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            refreshButton.Click += RefreshButton_Click;
            navigationToolStrip.Items.Add(refreshButton);

            // Stop Button
            stopButton = new ToolStripButton
            {
                Image = Properties.Resources.stop_icon, // Replace with your stop icon
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                Visible = false
            };
            stopButton.Click += StopButton_Click;
            navigationToolStrip.Items.Add(stopButton);

            // Address TextBox
            addressTextBox = new ToolStripSpringTextBox
            {
                AutoSize = false,
                Width = 400
            };
            addressTextBox.KeyDown += AddressTextBox_KeyDown;
            navigationToolStrip.Items.Add(addressTextBox);

            // Go Button
            goButton = new ToolStripButton
            {
                Text = "Go"
            };
            goButton.Click += GoButton_Click;
            navigationToolStrip.Items.Add(goButton);

            // New Tab Button
            newTabButton = new ToolStripButton
            {
                Text = "+",
                DisplayStyle = ToolStripItemDisplayStyle.Text
            };
            newTabButton.Click += NewTabButton_Click;
            navigationToolStrip.Items.Add(newTabButton);
            // Settings / About Context Menu button
            menuButton = new ToolStripDropDownButton
            {
                Text = "More",
                DisplayStyle = ToolStripItemDisplayStyle.Text
            };
            navigationToolStrip.Items.Add(menuButton);

            // Add ToolStrip to the Form
            navigationToolStrip.Dock = DockStyle.Top;
            
            
            this.Controls.Add(navigationToolStrip);
        }*/

        private void InitializeBrowserTabs()
        {
            // Create the TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.None,
                Location = new Point(0, 72),
                Size = new Size(784, 489),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            this.Controls.Add(tabControl);

            // Configure TabControl for OwnerDraw (for close buttons)
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.MouseUp += TabControl_MouseUp;

            // Add the first browser tab
            AddNewTab(homePage);
        }

        private void AddNewTab(string url)
        {
            var tabPage = new TabPage("New Tab");
            var browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };

            // Attach event handlers
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;

            tabPage.Controls.Add(browser);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNavigationControls();
            UpdateAddressBar();
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
                addressTextBox.Text = browser.Address;
            }
            else
            {
                addressTextBox.Text = string.Empty;
            }
        }

        private ChromiumWebBrowser GetCurrentBrowser()
        {
            // If the call is coming from another thread, use Invoke to access the control on the UI thread
            if (InvokeRequired)
            {
                return (ChromiumWebBrowser)Invoke(new Func<ChromiumWebBrowser>(GetCurrentBrowser));
            }

            // Otherwise, proceed as normal on the UI thread
            var tabPage = tabControl.SelectedTab;
            if (tabPage != null && tabPage.Controls.Count > 0)
            {
                return tabPage.Controls[0] as ChromiumWebBrowser;
            }

            return null;
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
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                browser.Load(url);
            }
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
            var browser = sender as ChromiumWebBrowser;
            if (browser == null)
                return;

            var tabPage = browser.Parent as TabPage;
            if (tabPage == null)
                return;

            this.Invoke(new Action(() =>
            {
                tabPage.Text = e.Title.Length > 20 ? e.Title.Substring(0, 20) + "..." : e.Title;
            }));
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            var browser = sender as ChromiumWebBrowser;
            if (browser == null)
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
            var browser = sender as ChromiumWebBrowser;
            if (browser == null)
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
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the tab normally
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);

            // Draw the close button ("X") on the tab
            Rectangle closeButton = new Rectangle(e.Bounds.Right - 15, e.Bounds.Top + 4, 10, 10);
            e.Graphics.DrawString("x", e.Font, Brushes.Red, closeButton);
        }


        private void TabControl_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if it's a left-click
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    Rectangle tabRect = tabControl.GetTabRect(i);
                    Rectangle closeButton = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 10, 10);

                    if (closeButton.Contains(e.Location))
                    {
                        // Close the tab when the close button is clicked
                        //CloseTab(tabControl.TabPages[i]);
                        ClearTabInt(i);
                        break;
                    }
                    else if (tabRect.Contains(e.Location))
                    {
                        // Switch to the clicked tab
                        tabControl.SelectedTab = tabControl.TabPages[i];
                        break;
                    }
                }
            }
            // Check for middle-click to close the tab
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    Rectangle tabRect = tabControl.GetTabRect(i);
                    if (tabRect.Contains(e.Location))
                    {
                        //CloseTab(tabControl.TabPages[i]);
                        ClearTabInt(i);
                        break;
                    }
                }
            }
        }
        // Deprecated feature, do not uncomment
        /*private void CloseTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                var browser = tabPage.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
                if (browser != null)
                {
                    browser.Dispose();
                }
                tabControl.TabPages.Remove(tabPage);
                UpdateNavigationControls(); // Update navigation controls after closing
            }
            
        }*/
        private void ClearTabInt(int index)
        {
            // Ensure there's always at least one tab open
            if (tabControl.TabCount == 1)
            {
                // Instead of closing the last tab, reset it to a "New Tab" page
                ResetToNewTab(tabControl.TabPages[index]);
            }
            else
            {
                if (tabControl != null)
                {
                    var browser = tabControl.TabPages[index].Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
                    if (browser != null)
                    {
                        Console.WriteLine("First or Default tab was closed.");
                    }
                    tabControl.TabPages.RemoveAt(index);
                    UpdateNavigationControls(); // Update navigation controls after closing
                }
                
            }
        }
        
        private void ResetToNewTab(TabPage tabPage)
        {
            tabPage.Text = "IntNetViewer Home";
            tabPage.Controls.Clear();

            // Add a placeholder browser instance or message
            var placeholderLabel = new Label
            {
                Text = "Welcome! Open a new tab or type a URL to begin browsing.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tabPage.Controls.Add(placeholderLabel);
        }

        private void NewTabButton_Click(object sender, EventArgs e)
        {
            AddNewTab(homePage);
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

        // Asyncronous button to check for updates via https://api.github.com/repos/robloxboy1000/IntNetViewer/releases/latest
        private async void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await UpdateChecker.CheckForUpdates();
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

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            // check for updates automatically via https://api.github.com/repos/robloxboy1000/IntNetViewer/releases/latest
            await UpdateChecker.CheckForUpdates();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the settings form
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(); // Show as a modal dialog
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This is not reccomended. PLEASE use tabs instead of windows.
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show(); // Don't show as a dialog
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTab(homePage);
        }

        // This method calls Cef.Shutdown() when closed. Fix if possible. NOTE: Fixed
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the browser?", "Exit Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevent the application from closing
            }
            else
            {
                Cef.Shutdown();
            }
        }
    }
}
