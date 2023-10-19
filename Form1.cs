using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
// Sonic Says: don't be a fool, smoking isnt cool.
namespace IntNetViewer
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
            // Add search engine options to the ComboBox
            searchEngineComboBox.Items.Add("Google");
            searchEngineComboBox.Items.Add("Bing");
            searchEngineComboBox.Items.Add("DuckDuckGo");
            searchEngineComboBox.Items.Add("FrogFind!");
            searchEngineComboBox.Items.Add("Yahoo!");
            searchEngineComboBox.Items.Add("Ecosia");

            // Set a default search engine
            searchEngineComboBox.SelectedIndex = 0; // Google

            

          
            // Create and configure the ChromiumWebBrowser control

            chromiumWebBrowser1.Dock = DockStyle.None;

            // Add the ChromiumWebBrowser control to the form
            Controls.Add(chromiumWebBrowser1);

            back.Enabled = false;
            forward.Enabled = false;

            // Navigate to the initial page when the form loads
            chromiumWebBrowser1.Load("https://robloxboy1000.neocities.org/");
        }
        // test comment with
        // multiple lines
        

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
        
        // Home
        private void button4_Click(object sender, EventArgs e)
        {
           chromiumWebBrowser1.Load("https://robloxboy1000.neocities.org");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newBrowser = new Form1();
            newBrowser.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text;

            // Check if the search term is not empty
            if (!string.IsNullOrEmpty(searchTerm))
            {
 
                // Construct the search URL (e.g., using a search engine like Google)
                string searchUrl = "https://google.com/search?q=" + Uri.EscapeDataString(searchTerm);

                // Load the search URL in the web browser control
                chromiumWebBrowser1.Load(searchUrl);
            }
        }

        private void textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = urlTextBox.Text;
                chromiumWebBrowser1.Load(url);
            }
        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            // Update the navigation buttons when the page loads
            this.Invoke((MethodInvoker)delegate
            {
                back.Enabled = chromiumWebBrowser1.CanGoBack;
                forward.Enabled = chromiumWebBrowser1.CanGoForward;
            });
            // Check if the loaded frame is the main frame
            if (e.Frame.IsMain)
            {
                // Use Control.Invoke to update the URL text box on the UI thread
                urlTextBox.Invoke((MethodInvoker)delegate
                {
                    urlTextBox.Text = e.Url;
                });
            }

        }

        private void searchEngineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSearchEngine = searchEngineComboBox.SelectedItem.ToString();

            // Use the selected search engine to build the search query URL
            string searchQuery = searchTextBox.Text; // Get the user's search query
            string searchUrl = GetSearchEngineUrl(selectedSearchEngine, searchQuery);

            // Navigate to the search query URL
            chromiumWebBrowser1.Load(searchUrl);
        }
        private string GetSearchEngineUrl(string searchEngine, string query)
        {
            switch (searchEngine)
            {
                case "Google":
                    return "https://www.google.com/search?q=" + Uri.EscapeDataString(query);
                case "Bing":
                    return "https://www.bing.com/search?q=" + Uri.EscapeDataString(query);
                case "DuckDuckGo":
                    return "https://duckduckgo.com/?q=" + Uri.EscapeDataString(query);
                case "FrogFind!":
                    return "http://frogfind.com/?q=" + Uri.EscapeDataString(query);
                case "Yahoo!":
                    return "https://search.yahoo.com/search?p=" + Uri.EscapeDataString(query);
                case "Ecosia":
                    return "https://www.ecosia.org/search?q=" + Uri.EscapeDataString(query);
                default:
                    return "https://www.google.com/search?q=" + Uri.EscapeDataString(query);
            }
        }

        private void devsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to the application's executable file
                string appPath = @"C:\Program Files (x86)\robloxboy1000\IntNetViewer\AudioGroove.exe";

                // Start the application
                Process.Start(appPath);
            }
            catch (Exception ex)
            {
                // Handle any potential exceptions
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void chromiumWebBrowser1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                // Execute JavaScript code to get the webpage's title
                const string script1 = "document.title;";
                var result = await chromiumWebBrowser1.EvaluateScriptAsync(script1);

                if (result.Success && !string.IsNullOrEmpty(result.Result.ToString()))
                {
                    this.Invoke(new Action(() =>
                    {
                        // Set the form's title to the webpage's title
                        this.Text = "IntNetViewer - " + result.Result.ToString();
                    }));
                }

                // Execute JavaScript code to get the favicon URL
                const string script = "document.querySelector(\"link[rel*='icon']\").getAttribute('href');";
                var faviconUrl = await chromiumWebBrowser1.EvaluateScriptAsync(script);

                if (faviconUrl.Success && !string.IsNullOrEmpty(faviconUrl.Result.ToString()))
                {
                    // Convert the favicon URL to an absolute URL
                    string absoluteFaviconUrl = ConvertToAbsoluteUrl(chromiumWebBrowser1.Address, faviconUrl.Result.ToString());

                    // Load the favicon image from the absolute URL
                    Image favicon = await LoadFaviconAsync(absoluteFaviconUrl);

                    if (favicon != null)
                    {
                        this.Invoke(new Action(() =>
                        {
                            pictureBoxFavicon.Image = favicon;
                        }));
                        
                    }
                }

                string url = e.Browser.MainFrame.Url;

                // Check if the URL starts with "https://" to determine if it's secure
                bool isSecure = url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

                // Update the label text based on whether the website is secure or not
                if (isSecure)
                {
                    this.Invoke(new Action(() =>
                    {
                       labelSecurity.Text = "Secure (https)";
                    }));
                    
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        labelSecurity.Text = "Not Secure (http)";
                    }));
                    
                }
            }
        }
        private string ConvertToAbsoluteUrl(string baseUrl, string relativeUrl)
        {
            try
            {
                Uri baseUri = new Uri(baseUrl);
                Uri absoluteUri = new Uri(baseUri, relativeUrl);
                return absoluteUri.AbsoluteUri;
            }
            catch (UriFormatException)
            {
                return string.Empty;
            }
        }
        private async Task<Image> LoadFaviconAsync(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors related to loading the favicon
                Console.WriteLine("Error loading favicon: " + ex.Message);
            }

            return null;
        }
    }
}
