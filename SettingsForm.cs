using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IntNetViewer
{
    public partial class SettingsForm : Form
    {
        private readonly string configFilePath = "config.cfg";
        private string[] themeSettings = new string[2];

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    if (line.StartsWith("HomePage"))
                    {
                        textBoxHomePage.Text = line.Split('=')[1].Trim();
                    }
                    else if (line.StartsWith("UserAgent"))
                    {
                        textBoxUA.Text = line.Split('=')[1].Trim();
                    }
                    else if (line.StartsWith("DarkMode"))
                    {
                        checkBoxDarkMode.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("EnableHomeButton"))
                    {
                        checkBoxHome.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("WarnOnExit"))
                    {
                        checkBoxWarn.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("GPUAcceleration"))
                    {
                        checkBoxGPUAccel.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("ShowFPSCounter"))
                    {
                        checkBoxShowFPS.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("AllowCustomTheme"))
                    {
                        chkBxAllowCustomTheme.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("BackgroundColor"))
                    {
                        txtBxBGColor.Text = line.Split('=')[1].Trim();
                    }
                    else if (line.StartsWith("ForegroundColor"))
                    {
                        txtBxFGColor.Text = line.Split('=')[1].Trim();
                    }
                    else if (line.StartsWith("EnableProxy"))
                    {
                        chkBxEnableProxy.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("Host"))
                    {
                        cbBxHost.Text = line.Split('=')[1].Trim().Split(':')[0];
                        txtBxProxy.Text = line.Split('=')[1].Trim().Split(':')[1];
                    }
                    else if (line.StartsWith("Port"))
                    {
                        txtBxProxyPort.Text = line.Split('=')[1].Trim();
                    }
                    else if (line.StartsWith("UseAppDataAsCache"))
                    {
                        chkBxUseAppDataAsCache.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("CachePath"))
                    {
                        // Do nothing, as we are not using this setting in the UI
                    }

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.WriteLine("[BrowserSettings]");
                writer.WriteLine($"HomePage = {textBoxHomePage.Text}");
                writer.WriteLine($@"CachePath = ./cache/");
                writer.WriteLine($"UserAgent = {textBoxUA.Text}");
                writer.WriteLine($"GPUAcceleration = {checkBoxGPUAccel.Checked}");
                writer.WriteLine($"ShowFPSCounter = {checkBoxShowFPS.Checked}");
                writer.WriteLine($"UseAppDataAsCache = {chkBxUseAppDataAsCache.Checked}");
                writer.WriteLine("[General]");
                writer.WriteLine($"DarkMode = {checkBoxDarkMode.Checked}");
                writer.WriteLine($"EnableHomeButton = {checkBoxHome.Checked}");
                writer.WriteLine($"WarnOnExit = {checkBoxWarn.Checked}");
                writer.WriteLine("[Theme]");
                writer.WriteLine($"AllowCustomTheme = {chkBxAllowCustomTheme.Checked}");
                if (chkBxAllowCustomTheme.Checked == false)
                {
                    writer.WriteLine($"BackgroundColor = SystemColors.Control");
                    writer.WriteLine($"ForegroundColor = SystemColors.ControlText");
                }
                else
                {
                    writer.WriteLine($"BackgroundColor = {txtBxBGColor.Text}");
                    writer.WriteLine($"ForegroundColor = {txtBxFGColor.Text}");
                }
                
                writer.WriteLine("[Proxy]");
                writer.WriteLine($"EnableProxy = {chkBxEnableProxy.Checked}");
                writer.WriteLine($"Host = {cbBxHost.Text}://{txtBxProxy.Text}");
                writer.WriteLine($"Port = {txtBxProxyPort.Text}");
            }

            MessageBox.Show("Settings saved successfully!\r\nYou must restart IntNetViewer for settings to take effect.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void chkBxEnableProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxEnableProxy.Checked)
            {
                cbBxHost.Enabled = true;
                txtBxProxy.Enabled = true;
                txtBxProxyPort.Enabled = true;
            }
            else
            {
                cbBxHost.Enabled = false;
                txtBxProxy.Enabled = false;
                txtBxProxyPort.Enabled = false;
            }
        }

        private void chkBxAllowCustomTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxAllowCustomTheme.Checked)
            {
                txtBxBGColor.Enabled = true;
                txtBxFGColor.Enabled = true;
            }
            else
            {
                txtBxBGColor.Enabled = false;
                txtBxFGColor.Enabled = false;
            }
        }



        private void chkBxUseAppDataAsCache_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
