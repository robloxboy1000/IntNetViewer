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
        private string configFilePath = "config.ini";
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
                    else if (line.StartsWith("JavaScriptEnabled"))
                    {
                        checkBoxJavaScriptEnabled.Checked = bool.Parse(line.Split('=')[1].Trim());
                    }
                    else if (line.StartsWith("UserAgent"))
                    {
                        textBoxUA.Text = line.Split('=')[1].Trim();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.WriteLine("[BrowserSettings]");
                writer.WriteLine($"HomePage = {textBoxHomePage.Text}");
                writer.WriteLine($"JavaScriptEnabled = {checkBoxJavaScriptEnabled.Checked}");
                writer.WriteLine(@"CachePath = C:\myapp\cache");
                writer.WriteLine($"UserAgent = {textBoxUA.Text}");
            }

            MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
