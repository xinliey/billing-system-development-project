using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatexApp0
{
    public partial class Latexprintbilluser : UserControl
    {
        

       // int index;
        int price;
        float total;
        public Latexprintbilluser()
        {
            var names = new AutoCompleteStringCollection
            {//input sql list here 
        "Alice",
        "Bob",
        "Charlie",
        "David",
        "Eve"
            };
            InitializeComponent();
            nameforbill.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameforbill.AutoCompleteSource = AutoCompleteSource.CustomSource;

            nameforbill.AutoCompleteCustomSource = names;
        }
     
        private void latexweight_TextChanged(object sender, EventArgs e)
        {
            TextChangeRecalculation();
            
           
        }
        private void bucketweight_TextChanged(object sender, EventArgs e)
        {
            TextChangeRecalculation();
        }  
        private void percentforbill_TextChanged(object sender, EventArgs e)
        {
            
            TextChangeRecalculation();
        }
           private void save_latex_btn_Click(object sender, EventArgs e)
        {
            SaveBillIntoDB(); //this one for percentage record
        }  
        private void save_latex_print_btn_Click(object sender, EventArgs e)
        {
            SaveBillIntoDB(); //this one for printing actual bill 
        }
        private void TextChangeRecalculation()
        {
           
           float latex_weight = 0f;
            float bucket_weight = 0f;
            float latex_percent = 0f;
            float net_weight = 0f;
            float latex_afterdry = 0f;
            float.TryParse(latexweight.Text, out latex_weight); //for UI better use TryParse instead of parse
            float.TryParse(bucketweight.Text, out bucket_weight);
            float.TryParse(percentforbill.Text, out latex_percent);
            net_weight= (latex_weight - bucket_weight);
            netweightforbill.Text = net_weight.ToString("0.##");

            if (latex_percent != 0f)
            {
                latex_afterdry = (float)Math.Round(
                net_weight * (latex_percent / 100f),1, MidpointRounding.AwayFromZero);

                latexafterdry.Text = latex_afterdry.ToString("0.0");

                DecidePrice(latex_percent);

                total = latex_afterdry * price;
                totalforbill.Text = total.ToString("0");
                DividingBill();
            }
        }
        private void DecidePrice(float percent)
        {

            var prices = AppState.Instance.PercentPrices;

            if (prices.Count == 0)
            {
                MessageBox.Show("Price list not initialized");
                return;
            }

            int index;

            if (percent < 20) index = 0;
            else if (percent < 25) index = 1;
            else if (percent < 30) index = 2;
            else if (percent < 33) index = 3;
            else if (percent < 36) index = 4;
            else if (percent < 38) index = 5;
            else if (percent < 40) index = 6;
            else if (percent < 41) index = 7;
            else if (percent < 42) index = 8;
            else index = 9;
            //MessageBox.Show($"index is {index}");
            //index = Math.Min(index, prices.Count - 1);
            price = prices[index];
            priceforbill.Text = price.ToString();

        }
        private void DividingBill()
        { float boss;
            //use case for 60_40 , we will connect to database later

            boss = (float)Math.Round(
               total * (0.6f), 0, MidpointRounding.AwayFromZero);
            float employee = total - boss;
            bossdivisionforbill.Text = boss.ToString("0");
            employeedivisionforbill.Text = employee.ToString("0");
        }
        private void SaveBillIntoDB()
        {
            //after pressing save button , the panel will be refreshed 
            //more convenient for user to move to next bill 
            latexweight.Clear();
            bucketweight.Clear();
            percentforbill.Clear();
        }

        private void nameforbill_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
