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
    public partial class StandaloneDLFormLoader : Form
    {
        public StandaloneDLFormLoader()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StandaloneDLForm form = new StandaloneDLForm(textBox1.Text.Trim(), textBox2.Text.Trim());
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
