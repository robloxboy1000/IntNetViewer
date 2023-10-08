using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace IntNetViewerLegacy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowserLegacy.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowserLegacy.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowserLegacy.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowserLegacy.GoHome();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "inetcpl.cpl");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string WebPage = textBox1.Text.Trim();
            webBrowserLegacy.Navigate(WebPage);
        }
    }
}
