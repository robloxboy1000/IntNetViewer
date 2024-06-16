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
    public partial class CancelDLDialog : Form
    {
        public CancelDLDialog()
        {
            InitializeComponent();
        }

        public int SelectedValue
        {
            get { return (int)numericUpDown1.Value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
