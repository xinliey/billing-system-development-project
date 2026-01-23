using MySql.Data.MySqlClient;
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
    public partial class RecordSearchUserControl : UserControl
    {
        public RecordSearchUserControl()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            SearchBillOnDate(selectedDate);

        }
        private void SearchBillOnDate(DateTime date)
        {
            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";

            string sql =
                "SELECT `Date`, netweight, totallatexcost, totaldrylatexcost, totalmoneyspent " +
                "FROM latexapp.conclude_daily_data " +
                "WHERE `Date` = @Date;";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Date", date);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string net_weight = reader["netweight"].ToString();
                        string totallatex = reader["totallatexcost"].ToString();
                        string totaldry= reader["totaldrylatexcost"].ToString();
                        string totalcost = reader["totalmoneyspent"].ToString();
                        DisplayOnReport(net_weight, totallatex,totaldry,totalcost);
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีข้อมูล");

                    }
                }
            }
        }
        private void DisplayOnReport(string net_weight, string latex, string dry, string cost)
        {
            netweightrecord.Text = net_weight;
            latexrecord.Text = latex;
            dryrecord.Text = dry;
            totalcostrecord.Text = cost;
        }
    }
}
