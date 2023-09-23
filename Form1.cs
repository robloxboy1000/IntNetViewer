using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace IntNetViewer
{
    public partial class Form1 : Form
    {
        private Timer loadingTimer;
        private float rotationAngle;


        public Form1()
        {
            InitializeComponent();
            InitializeLoadingAnimation();
            // subscribed stuff
            webBrowser1.Navigating += webBrowser1_Navigating;
            webBrowser1.ProgressChanged += webBrowser1_ProgressChanged;
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            timerHideProgressBar.Tick += timerHideProgressBar_Tick;
            // Subscribe to the PictureBox's click event
            pictureBoxLoading.Click += pictureBoxLoading_Click;
            // Navigate to the initial page when the form loads
            webBrowser1.Navigate("http://robloxboy1000.6te.net/");
        }
        private void InitializeLoadingAnimation()
        {
            loadingTimer = new Timer();
            loadingTimer.Interval = 50; // Adjust the interval as needed for animation speed
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
        }
        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            rotationAngle += 10; // Adjust the rotation speed as needed
            pictureBoxLoading.Image = RotateImage(Properties.Resources.CircleImage, rotationAngle);
        }
        private Image RotateImage(Image image, float angle)
        {
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(image.Width / 2, image.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-image.Width / 2, -image.Height / 2);
                g.DrawImage(image, Point.Empty);
            }
            return rotatedImage;
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
        // Navigation Start + "Easter Eggs"
        private void go_Click(object sender, EventArgs e)
        {
            string protocolcustom1 = "intnetviewer://hampdance";
            string protocolcustom2 = "intnetviewer://example";

            string userInput = textbox.Text.ToLower(); // Convert the input to lowercase for case-insensitive comparison

            if (userInput.Contains(protocolcustom1))
            {
                webBrowser1.Navigate("http://web.archive.org/web/19991128125537/http://www.geocities.com/Heartland/Bluffs/4157/hampdance.html");
            }
            if (userInput.Contains(protocolcustom2))
            {
                webBrowser1.Navigate("http://example.com");
            }
            else
            {
                webBrowser1.Navigate(textbox.Text);
            }
            
        }
        // Web browser finished navigation
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
        // Search button
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
        // web browser currently navigating
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Start the animation when the page starts loading
            pictureBoxLoading.Visible = true;
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
        // timer for hiding progress bar
        private void timerHideProgressBar_Tick(object sender, EventArgs e)
        {
            // Stop the Timer
            timerHideProgressBar.Stop();

            // Hide the progress bar after the delay
            toolStripProgressBar1.Visible = false;

            // Reset the progress bar value to 0
            toolStripProgressBar1.Value = 0;
        }
        // Open file
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

        // Print
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        // Web browser completed document
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Show the still frame when the page loading is complete
            pictureBoxLoading.Visible = false;
        }
        // Picture button
        private void pictureBoxLoading_Click(object sender, EventArgs e)
        {
            // Navigate the WebBrowser control to the product page URL
            string productPageUrl = "http://robloxboy1000.6te.net";
            webBrowser1.Navigate(productPageUrl);
        }
       
        // Home
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://robloxboy1000.6te.net");
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.ExecCommand("Cut", false, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.ExecCommand("Paste", false, null);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("document.execCommand", new object[] { "undo", false, null });
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("document.execCommand", new object[] { "redo", false, null });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }
        private void ShowFeatureNotImplementedMessage()
        {
            MessageBox.Show("This feature is not yet implemented. It will be available in future updates.",
                            "Feature Not Implemented",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveWebPage(saveFileDialog.FileName);
                    }
                }
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveWebPage(saveFileDialog.FileName);
                    }
                }
            
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void SaveWebPage(string filePath)
        {
            string htmlContent = webBrowser1.DocumentText;
            File.WriteAllText(filePath, htmlContent);
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
                string searchUrl = "http://frogfind.com/?q=" + Uri.EscapeDataString(searchTerm);

                // Load the search URL in the web browser control
                webBrowser1.Navigate(searchUrl);
            }
        }
    }
}
