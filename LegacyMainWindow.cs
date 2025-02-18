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
    public partial class LegacyMainWindow : Form
    {
        private TabControl tabControl;
        public LegacyMainWindow()
        {
            InitializeComponent();
            InitTabControl();
        }
        private void InitTabControl()
        {
            // Create the TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.None,
                Location = new Point(0, 72),
                Size = new Size(784, 467),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            this.Controls.Add(tabControl);

            // Configure TabControl for OwnerDraw (for close buttons)
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += TabControl_DrawItem;
            tabControl.MouseUp += TabControl_MouseUp;

            // Add the first browser tab
            AddNewTab("http://example.com");
        }
        private void AddNewTab(string url)
        {
            // Create a new TabPage
            TabPage tabPage = new TabPage
            {
                Text = "New Tab",
                ToolTipText = "New Tab",
                Tag = url,
            };
            tabControl.TabPages.Add(tabPage);
            // Create a new WebBrowser
            WebBrowser webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScriptErrorsSuppressed = true,
            };
            webBrowser.Navigate(url);
            tabPage.Controls.Add(webBrowser);
            // Select the new tab
            tabControl.SelectedTab = tabPage;
        }
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            if (e.Index == tabControl.TabPages.Count - 1)
            {
                e.Graphics.FillRectangle(Brushes.White, tabRect);
                e.Graphics.DrawRectangle(Pens.Black, tabRect);
                e.Graphics.DrawString("+", tabControl.Font, Brushes.Black, tabRect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                });
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightGray, tabRect);
                e.Graphics.DrawRectangle(Pens.Black, tabRect);
                e.Graphics.DrawString(tabPage.Text, tabControl.Font, Brushes.Black, tabRect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                });
                Rectangle closeButtonRect = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 10, 10);
                e.Graphics.FillRectangle(Brushes.Red, closeButtonRect);
                e.Graphics.DrawString("x", tabControl.Font, Brushes.White, closeButtonRect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                });
            }
        }
        private void TabControl_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControl.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                Rectangle closeButtonRect = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 10, 10);
                if (closeButtonRect.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_New aboutForm = new About_New();
            aboutForm.ShowDialog();
        }

        private async void CheckForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await UpdateChecker.CheckForUpdates();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewTab("http://example.com");
        }

        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LegacyMainWindow mainWindow = new LegacyMainWindow();
            mainWindow.Show(); // Don't show as a dialog
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the settings form
            LegacySettingsForm settingsForm = new LegacySettingsForm();
            settingsForm.ShowDialog(); // Show as a modal dialog
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddNewTab("http://example.com");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NavigateToAddress();
        }
        private void NavigateToAddress()
        {
            var browser = GetCurrentBrowser();
            if (browser != null)
            {
                string url = addressTextBox.Text.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                browser.Navigate(url);
            }
        }
        private WebBrowser GetCurrentBrowser()
        {
            if (tabControl.SelectedTab != null)
            {
                if (tabControl.SelectedTab.Controls.Count > 0)
                {
                    return tabControl.SelectedTab.Controls[0] as WebBrowser;
                }
            }
            return null;
        }
    }
}
