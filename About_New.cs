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
            this.label12.Text = Environment.OSVersion.VersionString;
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
