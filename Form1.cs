using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace UwUNetViewer
{
    public partial class Form1 : Form
    {
        
        private Image gifAnimation;
        private Image gifStillFrame;
        

        public Form1()
        {
            InitializeComponent();
            // UwU Update
            this.BackColor = Color.FromArgb(255, 0, 188);
            // Load the GIF animation and still frame images
            gifAnimation = Properties.Resources.maxwellcat;
            gifStillFrame = Properties.Resources.maxwell;

            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.ProgressChanged += webBrowser1_ProgressChanged;
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            timerHideProgressBar.Tick += timerHideProgressBar_Tick;
            // Subscribe to the PictureBox's click event
            pictureBoxLoading.Click += pictureBoxLoading_Click;
            
            // Navigate to the initial page when the form loads
            webBrowser1.Navigate("http://robloxboy1000.infinityfreeapp.com/sites/intnetviewer/index.html");
        }
        

        
        


        private void back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void go_Click(object sender, EventArgs e)
        {
            string secretWord = "hampdance"; // Change this to your desired secret word
            string userInput = textbox.Text.ToLower(); // Convert the input to lowercase for case-insensitive comparison

            if (userInput.Contains(secretWord))
            {
                webBrowser1.Navigate("http://web.archive.org/web/19991128125537/http://www.geocities.com/Heartland/Bluffs/4157/hampdance.html");
            }
            else
            {
                webBrowser1.Navigate(textbox.Text);
            }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }
        
        
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Update the URL text box with the current page's URL
            textbox.Text = webBrowser1.Url.ToString();
            // Get the title of the web page
            string pageTitle = webBrowser1.DocumentTitle;

            // Get the current URL
            string currentUrl = e.Url.ToString();

            // Update the ToolStripStatusLabel with the web page title or the current URL
            if (!string.IsNullOrEmpty(pageTitle))
            {
                toolStripStatusLabel1.Text = pageTitle;
            }
            else
            {
                toolStripStatusLabel1.Text = currentUrl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var searchDialog = new SearchDialog())
            {
                if (searchDialog.ShowDialog() == DialogResult.OK)
                {
                    string searchQuery = searchDialog.SearchQuery;
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                    {
                        // Replace "https://www.google.com/search?q=" with the search engine URL
                        string searchUrl = "http://www.frogfind.com/?q=" + Uri.EscapeDataString(searchQuery);
                        webBrowser1.Navigate(searchUrl);
                    }
                }
            }
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Start the animation when the page starts loading
            pictureBoxLoading.Image = gifAnimation;
            // Show the progress bar when a new page starts loading
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0; // Reset the progress bar value to 0
            
            // Get the host name from the URL
            string hostName = new Uri(e.Url.ToString()).Host;

            try
            {
                // Try to resolve the host name to an IP address
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                // Check if the host entry contains any IP addresses
                if (hostEntry.AddressList.Length == 0)
                {
                    // Show a warning to the user using a MessageBox
                    MessageBox.Show("Unable to resolve IP address for the website's domain name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Cancel the navigation
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur during DNS resolution
                MessageBox.Show("Error resolving IP address: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancel the navigation
            }
        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress > 0)
            {
                // Calculate the progress percentage
                int progress = (int)(e.CurrentProgress * 100 / e.MaximumProgress);

                // Update the value of the progress bar
                toolStripProgressBar1.Value = progress;

                // If the page has finished loading, hide the progress bar
                if (progress >= 100)
                {
                    timerHideProgressBar.Start();
                }
            }
        }
        private void timerHideProgressBar_Tick(object sender, EventArgs e)
        {
            // Stop the Timer
            timerHideProgressBar.Stop();

            // Hide the progress bar after the delay
            toolStripProgressBar1.Visible = false;

            // Reset the progress bar value to 0
            toolStripProgressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the file filter to only show HTML files
                openFileDialog.Filter = "HTML Files|*.html|All Files|*.*";

                // Show the OpenFileDialog and check if the user clicked the OK button
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected HTML file path
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Read the contents of the HTML file
                        string htmlContent = System.IO.File.ReadAllText(filePath);

                        // Navigate the WebBrowser control to the selected HTML content
                        webBrowser1.DocumentText = htmlContent;
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that might occur while reading the file
                        MessageBox.Show("Error loading the HTML file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Show the still frame when the page loading is complete
            pictureBoxLoading.Image = gifStillFrame;
        }
        private void pictureBoxLoading_Click(object sender, EventArgs e)
        {
            // Navigate the WebBrowser control to the product page URL
            string productPageUrl = "http://robloxboy1000.infinityfreeapp.com/sites/intnetviewer/index.html";
            webBrowser1.Navigate(productPageUrl);
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://robloxboy1000.infinityfreeapp.com/sites/intnetviewer/index.html");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
