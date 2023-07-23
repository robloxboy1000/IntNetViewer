using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace IntNetViewer
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.ProgressChanged += webBrowser1_ProgressChanged;
            webBrowser1.Navigated += webBrowser1_Navigated;
            timerHideProgressBar.Tick += timerHideProgressBar_Tick;
            // Navigate to the initial page when the form loads
            webBrowser1.Navigate("http://frogfind.com");
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
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        
        
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Update the URL text box with the current page's URL
            textbox.Text = webBrowser1.Url.ToString();
            
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
            // Show the progress bar when a new page starts loading
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0; // Reset the progress bar value to 0
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
    }
}
