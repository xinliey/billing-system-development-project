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
    public partial class Form1 : Form
    {
        private Latexprintbilluser latexprint;
        public Form1()
        {
            InitializeComponent();

                     
            latexprint = new Latexprintbilluser();

            LoadPage(latexprint);
        }

      
        private void latexprintbill_Click(object sender, EventArgs e)
        {
            LoadPage(latexprint);
        }
        private void LoadPage(System.Windows.Forms.UserControl Page)
        {
            billprintpanel.Controls.Clear();
            Page.Dock = DockStyle.Fill;
            billprintpanel.Controls.Add(Page);
        }

    }
}
