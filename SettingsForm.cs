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
                writer.WriteLine("[General]");
                writer.WriteLine($"DarkMode = {checkBoxDarkMode.Checked}");
                writer.WriteLine($"EnableHomeButton = {checkBoxHome.Checked}");
                writer.WriteLine($"WarnOnExit = {checkBoxWarn.Checked}");
            }

            MessageBox.Show("Settings saved successfully!\r\nYou must restart IntNetViewer for settings to take effect.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
