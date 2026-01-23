using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
namespace LatexApp0
{
    public partial class BillCombineControl : System.Windows.Forms.UserControl
    {
        string net_weight;
        string transportfee;
        string total_cost;
        string totalpay;
        string dry="0";
        public BillCombineControl()
        {
            InitializeComponent();
            CalculateOnLoadPage();

        }

        private void CalculateOnLoadPage()
        {
            string connString =
         "Server=localhost;" +
          "Database=latexapp;" +
         "User ID=root;" +
         "Password=131001;";
            string sql = "SELECT SUM(net_weight) AS totalweight,SUM(TransportFee) AS totalcar," +
                "SUM(cost) AS totalcost , SUM(TransportFee + cost) AS total_payment FROM latexapp.daily_data;";
            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        net_weight = reader["totalweight"].ToString();
                        transportfee= reader["totalcar"].ToString();
                        total_cost = reader["totalcost"].ToString();
                        totalpay = reader["total_payment"].ToString();
                        DisplayTotalBill(net_weight,transportfee,total_cost,totalpay);
                        
                    }
                }
            }
        }
        private void DisplayTotalBill(string netweight,string transportfee, string totalcost,string totalpay)
        {
            netweighttoday.Text = netweight;
            transportfeetxt.Text = transportfee;
            totalcosttxt.Text = totalcost;
            totalpaytoday.Text = totalpay;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveToConcludeData();
        }


        private void SaveToConcludeData()
        {
            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";

            string sql = @"
         INSERT INTO conclude_daily_data
            (`Date`, `netweight`, `totallatexcost`, `totaldrylatexcost`, `totalmoneyspent`)
         VALUES
            (@Date, @Net_weight, @Totallatex, @Totaldry, @Totalpaytoday)
            ON DUPLICATE KEY UPDATE
            netweight = VALUES(netweight),
            totallatexcost = VALUES(totallatexcost),
            totaldrylatexcost = VALUES(totaldrylatexcost),
            totalmoneyspent = VALUES(totalmoneyspent);";


            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Date", DateTime.Today);
                cmd.Parameters.AddWithValue("@Net_weight", net_weight);
                cmd.Parameters.AddWithValue("@Totallatex", total_cost);
                cmd.Parameters.AddWithValue("@Totaldry", dry);//still need to figure out if i should add more database for dry latex
                cmd.Parameters.AddWithValue("@Totalpaytoday", totalpay);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("บันทึกข้อมูลสำเร็จ!");
        }

    }
    
}
