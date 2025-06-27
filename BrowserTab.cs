using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private Icon tabIcon = Icon.ExtractAssociatedIcon(Path.GetFullPath("./assets/IntImage.png"));

        public BrowserTab(string url, bool enableIE)
        {
            // Set DockContent properties
            this.Text = "New Tab";
            this.CloseButtonVisible = true;
            this.ShowIcon = true;
            if (tabIcon != null)
            {
                this.Icon = tabIcon;
            }
            else { 
                this.Icon = SystemIcons.Application; // Fallback icon if extraction fails
            }
            if (enableIE)
            {
                webBrowser = new WebBrowser
                {
                    Dock = DockStyle.Fill,
                    ScriptErrorsSuppressed = true,
                    AllowWebBrowserDrop = false,
                    Url = new Uri(url)
                };
                this.Controls.Add(webBrowser);
                webBrowser.DocumentTitleChanged += (sender, args) =>
                {
                    this.Invoke((MethodInvoker)(() => this.Text = webBrowser.DocumentTitle));
                };
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
