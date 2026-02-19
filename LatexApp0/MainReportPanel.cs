using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LatexApp0
{
    public partial class MainReportPanel : System.Windows.Forms.UserControl
    {
        int InitPrice;
       
        public MainReportPanel()
        {
            InitializeComponent();
            reportdatadisplay();
            
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
            var prices = AppState.Instance.PercentPrices;
            prices.Clear();
            for (int i = 0; i < 10; i++)
            {
                prices.Add(InitPrice + i);
            }

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

        private void reportdatadisplay()
        {
            reportremark.AppendText("เข้ารอบวันนี้\n\n");
            string connString =
        "Server=localhost;" +
         "Database=latexapp;" +
        "User ID=root;" +
        "Password=131001;";
            string sql =
        "SELECT Name\n"+
        "FROM(\n"+
        "SELECT dd.Name,COUNT(*) AS streak_len\n" +
        "FROM( SELECT Name ,date," +
        "DATE_SUB(date, INTERVAL ROW_NUMBER() OVER(PARTITION BY Name ORDER BY date) DAY) AS grp\n" +
        "FROM latexapp.daily_data\n" +
        ") dd\n" +
        "JOIN latexapp.client_data cd\n" +
        "ON cd.name = dd.Name\n" +
        "WHERE cd.bigcustomer = 1\n" +
        "GROUP BY dd.Name, grp\n" +
        ") t\n" +
        "WHERE streak_len >= 2;";


            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
               

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {// Client info (same for every row)

                        string name = reader["Name"].ToString();
                        

                        DisplayRestDay(name);

                    }
                }
            }
        }
        private void DisplayRestDay(string name)
        {
           reportremark.AppendText($"{name}\n");
        }
    }
    
}
