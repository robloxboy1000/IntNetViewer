using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CefSharp;
using CefSharp.WinForms;

namespace IntNetViewer
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

            

            // Create and configure the ChromiumWebBrowser control

            chromiumWebBrowser1.Dock = DockStyle.None;

            // Add the ChromiumWebBrowser control to the form
            Controls.Add(chromiumWebBrowser1);

            

            // Navigate to the initial page when the form loads
            chromiumWebBrowser1.Load("https://robloxboy1000.neocities.org/");
        }
        
        
        
        private void back_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanGoBack)
            chromiumWebBrowser1.Back();
        }
        private void forward_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.CanGoForward)
            chromiumWebBrowser1.Forward();
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
    }
}
