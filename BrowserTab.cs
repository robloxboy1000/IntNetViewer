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
        public ChromiumWebBrowser Browser { get; private set; }

        public BrowserTab(string url)
        {
            // Set DockContent properties
            this.Text = "New Tab";
            this.CloseButtonVisible = true;
            this.ShowIcon = true;
            this.Icon = Properties.Resources.IntNetViewerIcon;
            // Create and add the Chromium browser
            Browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(Browser);

            // Set tab title when page loads
            Browser.TitleChanged += (sender, args) =>
            {
                this.Invoke((MethodInvoker)(() => this.Text = args.Title));
            };
        }
    }
}
