using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public partial class CefTabControl : UserControl
    {
        private TabControl tabControl;
        public CefTabControl()
        {
            InitializeComponent();
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            this.Controls.Add(tabControl);

            // Add an initial tab
            AddNewTab();
        }
        public void AddNewTab(string url = "https://www.google.com")
        {
            var tabPage = new TabPage("New Tab");
            var browser = new CefSharp.WinForms.ChromiumWebBrowser(url);
            browser.Dock = DockStyle.Fill;
            tabPage.Controls.Add(browser);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }
    }
}
