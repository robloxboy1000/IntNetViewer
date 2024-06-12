using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;
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
    public partial class NewTabForm : Form
    {
        
        public NewTabForm(string initialUrl)
        {
            InitializeComponent();
            InitializeChromium(initialUrl);
        }
        private void InitializeChromium(string initialUrl)
        {
            
            Browser.LifeSpanHandler = new CustomLifeSpanHandler(OpenNewTab);
            Browser.LoadUrl(initialUrl);
            this.Controls.Add(Browser);
        }
        private void OpenNewTab(string url)
        {
            Invoke(new Action(() =>
            {
                var newForm = new NewTabForm(url);
                newForm.Show();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.Back();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.Forward();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Browser.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Browser.LoadUrl(textBox1.Text);
        }

        private void Browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                textBox1.Invoke(new Action(() =>
                {
                    textBox1.Text = e.Url;
                }));
            }
        }
    }
}
