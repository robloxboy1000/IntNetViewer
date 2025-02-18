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
    public partial class HistoryForm : Form
    {
        private List<HistoryItem> historyList;
        public HistoryForm(List<HistoryItem> historyList)
        {
            InitializeComponent();
            this.historyList = historyList;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            foreach (var item in historyList)
            {
                listBoxHistory.Items.Add($"{item.VisitTime} - {item.Url}");
            }
        }
    }
}
