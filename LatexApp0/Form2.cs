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
        private RecordSearchUserControl billsearch;
        public reportForm()
        {
            InitializeComponent();
            ReportTab = new MainReportPanel();
            BillCombineTab = new BillCombineControl();
            AddCustomerTab = new AddNewcustomer();
            searchTab = new SearchTabUserControl();
            billsearch = new RecordSearchUserControl();

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
        private void LoadPage(System.Windows.Forms.UserControl Page)
        {
            ReportPanel.Controls.Clear();
            Page.Dock = DockStyle.Fill;
            ReportPanel.Controls.Add(Page);
        }

        private void ขอมลลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(searchTab);
            this.AcceptButton = searchTab.SearchButton;
        }

        private void initialprice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ประวตบลToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPage(billsearch);
        }
    }
}
