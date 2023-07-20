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
        

        private ProgressBar progressBar;
        
        public Form1()
        {
            InitializeComponent();

            // Create and set up the progress bar
            progressBar = new ProgressBar();
            progressBar1.Visible = false;
            progressBar1.Width = 200;     // Adjust the width according to your layout
            progressBar1.Location = new Point(10, this.ClientSize.Height - progressBar.Height - 10);
            this.Controls.Add(progressBar);
            // Subscribe to the necessary events
            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.ProgressChanged += webBrowser1_ProgressChanged;
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
            webBrowser1.Navigate(textbox.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Show the progress bar when a new page starts loading
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            
        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress > 0)
            {
                // Calculate and set the progress value between 0 and 100
                int progress = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                Console.WriteLine($"Progress: {progress}%");
                progressBar1.Value = progress;
            }
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // Update the URL text box with the current page's URL
            textbox.Text = webBrowser1.Url.ToString();

            progressBar.Visible = false;
        }

        
    }
}
