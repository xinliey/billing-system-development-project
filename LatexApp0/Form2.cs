using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatexApp0
{
    public partial class reportForm : Form
    {
        private MainReportPanel ReportTab;
        private BillCombineControl BillCombineTab;
        private AddNewcustomer AddCustomerTab;
        private SearchTabUserControl searchTab;
        public reportForm()
        {
            InitializeComponent();
            ReportTab = new MainReportPanel();
            BillCombineTab = new BillCombineControl();
            AddCustomerTab = new AddNewcustomer();
            searchTab = new SearchTabUserControl();
            LoadPage(ReportTab); //initialize tab
        }

        private void รวมบลToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(BillCombineTab);
        }
        private void รายงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(ReportTab);
        }

        private void เพมลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(AddCustomerTab);
        } 
        private void LoadPage(UserControl Page)
        {
            ReportPanel.Controls.Clear();
            Page.Dock = DockStyle.Fill;
            ReportPanel.Controls.Add(Page);
        }

        private void ขอมลลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(searchTab);
        }
    }
}
