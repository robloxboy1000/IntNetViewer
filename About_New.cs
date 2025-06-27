using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public partial class About_New : Form
    {
        public About_New()
        {
            InitializeComponent();
            if (Program.noCef)
            {
                string ieVersion = GetIEVersion();
                this.label5.Text = "IE Version:";
                this.label6.Text = ieVersion;
            }
            else
            {
                this.label6.Text = Cef.CefSharpVersion.ToString();
            }
            this.label2.Text = "PixlPlaya5";
            this.label4.Text = AssemblyVersion;
            //this.label6.Text = Cef.CefSharpVersion.ToString();
            this.label8.Text = GetBuildDate();
            this.archLabel.Text = Environment.Is64BitProcess ? "x64" : "x86";
            this.label12.Text = $"{GetWindowsVersion()}\r\n{Environment.OSVersion.VersionString}";
            
        }

        public string GetIEVersion()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "mshtml.dll");
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            return $"{versionInfo.FileMajorPart}.{versionInfo.FileMinorPart}.{versionInfo.FileBuildPart}.{versionInfo.FilePrivatePart}";
        }

        public string GetWindowsVersion()
        {
            string version = "Unknown";
            string osArch = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            if (Environment.OSVersion.Version.Major == 10)
            {
                if (Environment.OSVersion.Version.Build == 19045)
                {
                    version = "Windows 10 22H2 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22000)
                {
                    version = "Windows 11 21H2 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22621)
                {
                    version = "Windows 11 22H2 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 22631)
                {
                    version = "Windows 11 23H2 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Build == 26100)
                {
                    version = "Windows 11 24H2 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
            }
            else if (Environment.OSVersion.Version.Major == 6)
            {
                if (Environment.OSVersion.Version.Minor == 3)
                {
                    version = "Windows 8.1 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 2)
                {
                    version = "Windows 8 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 1)
                {
                    version = "Windows 7 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 0)
                {
                    version = "Windows Vista " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
            }
            else if (Environment.OSVersion.Version.Major == 5)
            {
                if (Environment.OSVersion.Version.Minor == 1)
                {
                    version = "Windows XP " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
                }
                else if (Environment.OSVersion.Version.Minor == 0)
                {
                    version = "Windows 2000 " + osArch + $" (Build:{Environment.OSVersion.Version.Build})";
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
