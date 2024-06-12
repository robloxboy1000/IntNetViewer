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

namespace IntNetViewer
{
    public partial class About_New : Form
    {
        public About_New()
        {
            InitializeComponent();
            this.label2.Text = String.Format("Version {0}", AssemblyVersion);
        }
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
