using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace IntNetViewer
{
    public class BrowserTab : DockContent
    {
        public ChromiumWebBrowser cefBrowser { get; private set; }
        public WebBrowser webBrowser { get; private set; } // For fallback if CEF is not available

        public BrowserTab(string url)
        {
            // Set DockContent properties
            this.Text = "New Tab";
            this.CloseButtonVisible = true;
            this.ShowIcon = true;
            this.Icon = Properties.Resources.IntNetViewerIcon;
            if (Program.noCef)
            {
                webBrowser = new WebBrowser
                {
                    Dock = DockStyle.Fill,
                    ScriptErrorsSuppressed = true,
                    AllowWebBrowserDrop = false
                };
                this.Controls.Add(webBrowser);
                webBrowser.DocumentTitleChanged += (sender, args) =>
                {
                    this.Invoke((MethodInvoker)(() => this.Text = webBrowser.DocumentTitle));
                };
                webBrowser.Navigate(url);
            }
            else
            {
                // Create and add the Chromium browser
                cefBrowser = new ChromiumWebBrowser(url)
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(cefBrowser);

                // Set tab title when page loads
                cefBrowser.TitleChanged += (sender, args) =>
                {
                    this.Invoke((MethodInvoker)(() => this.Text = args.Title));
                };
            }
                
        }
    }
}
