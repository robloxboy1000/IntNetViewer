using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace IntNetViewer
{
    public partial class IntNetTabbed : Form
    {
        public IntNetTabbed()
        {
            InitializeComponent();
           
        }
        private void InitializeTab(string initialUrl)
        {
            // Create a new tab page and add it to the tab control
            TabPage newTabPage = new TabPage("New Tab");
            tabControl1.TabPages.Add(newTabPage);

            // Create a new ChromiumWebBrowser control for the tab
            ChromiumWebBrowser newBrowser = new ChromiumWebBrowser("about:blank"); // Load a blank page initially
            newBrowser.Dock = DockStyle.Fill; // Fill the tab page with the browser control
            newTabPage.Controls.Add(newBrowser);

            // Set the newly created tab as the selected tab
            tabControl1.SelectedTab = newTabPage;

            // Subscribe to the LoadingStateChanged event
            newBrowser.LoadingStateChanged += NewBrowser_LoadingStateChanged;
        }

        private void IntNetTabbed_Load(object sender, EventArgs e)
        {
            InitializeTab("https://www.example.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back in the selected tab
            if (tabControl1.SelectedTab.Controls.Count > 0 &&
                tabControl1.SelectedTab.Controls[0] is ChromiumWebBrowser browser)
            {
                if (browser.CanGoBack)
                {
                    browser.Back();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate forward in the selected tab
            if (tabControl1.SelectedTab.Controls.Count > 0 &&
                tabControl1.SelectedTab.Controls[0] is ChromiumWebBrowser browser)
            {
                if (browser.CanGoForward)
                {
                    browser.Forward();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Navigate to the home page (e.g., your predefined homepage)
            if (tabControl1.SelectedTab.Controls.Count > 0 &&
                tabControl1.SelectedTab.Controls[0] is ChromiumWebBrowser browser)
            {
                browser.Load("https://google.com");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Navigate to the entered URL
                if (tabControl1.SelectedTab.Controls.Count > 0 &&
                    tabControl1.SelectedTab.Controls[0] is ChromiumWebBrowser browser)
                {
                    browser.Load(textBox1.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new tab page and add it to the tab control
            TabPage newTabPage = new TabPage("New Tab");
            tabControl1.TabPages.Add(newTabPage);

            // Create a new ChromiumWebBrowser control for the tab
            ChromiumWebBrowser newBrowser = new ChromiumWebBrowser("about:blank"); // Load a blank page initially
            newBrowser.Dock = DockStyle.Fill; // Fill the tab page with the browser control
            newTabPage.Controls.Add(newBrowser);

            // Set the newly created tab as the selected tab
            tabControl1.SelectedTab = newTabPage;
        }
        private async void NewBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            if (!e.IsLoading)
            {
                Invoke(new Action(() =>
                {
                    // Update the URL box with the current URL
                    textBox1.Text = browser.Address;
                }));
                // Execute JavaScript code to get the page title
                var frame = browser.GetMainFrame();
                if (frame != null)
                {
                    var title = await frame.EvaluateScriptAsync("document.title", TimeSpan.FromSeconds(1).ToString());

                    // Update the tab name based on the loaded page's title or URL
                    if (!string.IsNullOrEmpty(title.ToString()))
                    {
                        Invoke(new Action(() =>
                        {
                            // If the page title is available, use it as the tab name
                            tabControl1.SelectedTab.Text = title.ToString();
                        }));
                    }
                    else
                    {
                        // If the page title is unavailable, use the URL as the tab name
                        Invoke(new Action(() => { tabControl1.SelectedTab.Text = browser.Address; }));
                    }
                }
            }
        }
    }
}
