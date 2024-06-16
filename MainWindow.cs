/// IntNetViewer - MainWindow.cs


using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.Policy;


namespace IntNetViewer
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The main program window.
        /// </summary>
        private string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\";
        public static MainWindow Instance;
        private DateTime startTime;
        private CustomDownloadHandler downloadHandler;
        private string version = Application.ProductVersion;
        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            Init();
            InitializeChromium();
        }
        private void InitializeChromium()
        {
            downloadHandler = new CustomDownloadHandler(progressToolStripMenuItem1, labelDLSpeed, labelRXBytes, labelTBytes, labelDLURL, this, idToolStripMenuItem);
            chromiumWebBrowser1.DownloadHandler = downloadHandler;
            chromiumWebBrowser1.RequestHandler = new CustomRequestHandler();
            chromiumWebBrowser1.LifeSpanHandler = new CustomLifeSpanHandler(OpenNewTab);
            chromiumWebBrowser1.MenuHandler = new CustomContextMenuHandler();
            CefSettings cefSettings = new CefSettings();
            cefSettings.UserAgent = IntNetConfig.UserAgent;
            cefSettings.CachePath = IntNetConfig.CachePath;
            cefSettings.RootCachePath = IntNetConfig.CachePath;
            cefSettings.RegisterScheme(new CefCustomScheme()
            {
                SchemeName = "intnetviewer",
                SchemeHandlerFactory = new SchemeHandlerFactory()
            });
            Cef.Initialize(cefSettings);
            this.Controls.Add(chromiumWebBrowser1);
            chromiumWebBrowser1.Load("https://google.com");
        }
        private void Init()
        {
            back.Enabled = false;
            forward.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
        }
        private void OpenNewTab(string url)
        {
            this.Invoke(new Action(() =>
            {
                var newForm = new NewTabForm(url);
                newForm.Show();
            }));
        }
        
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
                        MessageBox.Show("An update is available. Please visit the download page to get the latest version.",
                            "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You are using the latest version of the web browser.",
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
            string currentVersion = "v3.3";
            return latestVersion.CompareTo(currentVersion) > 0;
        }
        
        
        private void back_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanGoBack)
            {
                chromiumWebBrowser1.Back();
            }
        }
        private void forward_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanGoForward)
            {
                chromiumWebBrowser1.Forward();
            }
        }
        private void refresh_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
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
        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = urlTextBox.Text;
                chromiumWebBrowser1.Load(url);
                back.Enabled = chromiumWebBrowser1.CanGoBack;
                forward.Enabled = chromiumWebBrowser1.CanGoForward;
                if (url.Contains("vargfren"))
                {
                    chromiumWebBrowser1.Stop();
                    chromiumWebBrowser1.Load("intnetviewer://assets/vargfren.html");
                }
            }
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
            chromiumWebBrowser1.Load(url);
            back.Enabled = chromiumWebBrowser1.CanGoBack;
            forward.Enabled = chromiumWebBrowser1.CanGoForward;
            if (url.Contains("vargfren"))
            {
                chromiumWebBrowser1.Stop();
                chromiumWebBrowser1.Load("intnetviewer://assets/vargfren.html");
            }
        }
        
        
        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://google.com");
        }
        private void wttrinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://wttr.in");
        }
        private void frogfindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("http://frogfind.com");
        }
        private void cNNLiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("http://lite.cnn.com/en");
        }
        private void riiConnect24BookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("http://bookmark.rc24.xyz");
        }
        private void wiiNetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("http://wiinet.xyz");
        }
        private void viewSourceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chromiumWebBrowser1.ViewSource();
        }
        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chromiumWebBrowser1.ShowDevTools();
        }
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Redo();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.SelectAll();
        }
        private void aboutCEFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("chrome://version");
        }
        private void testSchemeHandlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("intnetviewer://assets/test.html");
        }
        private void returnExcecutablePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"{appPath}");
        }
        
        
        private void saveToHardDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sourceFolderPath = SelectSourceFolder();
            if (string.IsNullOrEmpty(sourceFolderPath))
            {
                return;
            }
            string destinationFilePath = SelectDestinationFile();
            if (string.IsNullOrEmpty(destinationFilePath))
            {
                return;
            }
            string destinationFolderPath = Path.GetDirectoryName(destinationFilePath);
            CopyDirectory(sourceFolderPath, destinationFolderPath);
            MessageBox.Show("Folder copied successfully!");
        }
        private string SelectSourceFolder()
        {
            return appPath;
        }
        private string SelectDestinationFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "SelectFolder";
                saveFileDialog.Filter = "Folder Selection|*.folder";
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.InitialDirectory = @"C:\Program Files\robloxboy1000\IntNetViewer\";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }
        private void CopyDirectory(string sourceDir, string destDir)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir);
            }
        }
        

        private void chromiumWebBrowser1_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                back.Enabled = chromiumWebBrowser1.CanGoBack;
                forward.Enabled = chromiumWebBrowser1.CanGoForward;
            }));
        }
        private void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading)
            {
                this.Invoke(new Action(() =>
                {
                    label5.Visible = true;
                }));
            }
            if (!e.IsLoading)
            {
                this.Invoke(new Action(() =>
                {
                    label5.Visible = false;
                }));
            }
        }
        private void chromiumWebBrowser1_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            lblHoverLink.Text = e.Value;
        }
        private void chromiumWebBrowser1_LoadError(object sender, LoadErrorEventArgs e)
        {
            
            if (e.ErrorText == "ERR_ABORTED")
            {
                return;
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"CEF encountered an error.\r\nError: {e.ErrorText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
                chromiumWebBrowser1.Stop();
            }
        }  
        private void chromiumWebBrowser1_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Text = e.Title + " - IntNetViewer";
            });
        }

        private void urlTextBox_Enter(object sender, EventArgs e)
        {
            label1.Text = "Go to:";
        }
        private void urlTextBox_Leave(object sender, EventArgs e)
        {
            label1.Text = "Netsite:";
        }
        private void chromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            urlTextBox.Invoke(new Action(() =>
            {
                urlTextBox.Text = e.Address;
            }));
        }

        private void MainWindow_Leave(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_Enter(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            timer1.Start();
            
        }
        // "wasted time"
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Calculate the elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Update the label with the elapsed time
            toolStripStatusLabel2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CancelDLDialog dialog = new CancelDLDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected value from the dialog
                    int selectedValue = dialog.SelectedValue;

                    // Use the selected value as needed
                    downloadHandler.CancelDownload(selectedValue);
                }
            }
        }

        private void chromiumWebBrowser1_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                consoleOutput.AppendText($"Line: {e.Line}, Source: {e.Source}, Message: {e.Message}{Environment.NewLine}");
                consoleOutput.ScrollToCaret();
            }));
        }

        private void showLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                back.Enabled = chromiumWebBrowser1.CanGoBack;
                forward.Enabled = chromiumWebBrowser1.CanGoForward;
            }));
        }

        private void returnVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(version.ToString());
        }
    }
}

