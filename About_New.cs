using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using System.IO;

namespace IntNetViewer
{
    public partial class About_New : Form
    {
        public About_New()
        {
            InitializeComponent();
            this.label2.Text = "PixlPlaya5";
            this.label4.Text = AssemblyVersion;
            this.label6.Text = Cef.CefSharpVersion.ToString();
            this.label8.Text = GetBuildDate();
            this.archLabel.Text = Environment.Is64BitProcess ? "x64" : "x86";
            this.label12.Text = GetWindowsVersion();
        }

        public string GetWindowsVersion()
        {
            string version = "Unknown";
            if (Environment.OSVersion.Version.Major == 10)
            {
                if (Environment.OSVersion.Version.Build == 19045)
                {
                    version = "Windows 10 22H2" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22000)
                {
                    version = "Windows 11 21H2" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22621)
                {
                    version = "Windows 11 22H2" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22631)
                {
                    version = "Windows 11 23H2" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 26100)
                {
                    version = "Windows 11 24H2" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
            }
            else if (Environment.OSVersion.Version.Major == 6)
            {
                if (Environment.OSVersion.Version.Minor == 3)
                {
                    version = "Windows 8.1" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 2)
                {
                    version = "Windows 8" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 1)
                {
                    version = "Windows 7" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 0)
                {
                    version = "Windows Vista" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
            }
            else if (Environment.OSVersion.Version.Major == 5)
            {
                if (Environment.OSVersion.Version.Minor == 1)
                {
                    version = "Windows XP" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 0)
                {
                    version = "Windows 2000" + $" (Build:{Environment.OSVersion.Version.Build})";
                }
            }
            return version;
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public static string GetBuildDate()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var filePath = assembly.Location;
            var buildDate = File.GetLastWriteTime(filePath);
            return buildDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
