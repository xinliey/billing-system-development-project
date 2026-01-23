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
    public partial class MainReportPanel : System.Windows.Forms.UserControl
    {
        int InitPrice;
        public int[] PercentPrices => new int[]// alow acess from other tab
    {
        int.Parse(percentbox1.Text),
        int.Parse(percentbox2.Text),
        int.Parse(percentbox3.Text),
        int.Parse(percentbox4.Text),
        int.Parse(percentbox5.Text),
        int.Parse(percentbox6.Text),
        int.Parse(percentbox7.Text)
    };
        public MainReportPanel()
        {
            InitializeComponent();
        }
        private void initialprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys and number only 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void initialprice_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(initialprice.Text, out int value))
            {
                InitPrice = value;
                UpdatePrice();
            }
            else
            {
                InitPrice = 0; // or keep previous value
            }
        }
        private void UpdatePrice()
        {
            percentbox1.Text = InitPrice.ToString();
            percentbox2.Text = (InitPrice + 1).ToString();
            percentbox3.Text = (InitPrice + 2).ToString();
            percentbox4.Text = (InitPrice + 3).ToString();
            percentbox5.Text = (InitPrice + 4).ToString();
            percentbox6.Text = (InitPrice + 5).ToString();
            percentbox7.Text = (InitPrice + 6).ToString();
            percentbox8.Text = (InitPrice + 7).ToString();
            percentbox9.Text = (InitPrice + 8).ToString();
            percentbox10.Text = (InitPrice + 9).ToString();
        }
    }
}
