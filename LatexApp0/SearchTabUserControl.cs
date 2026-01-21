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
    public partial class SearchTabUserControl : UserControl
    {
        public SearchTabUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString =
           "Server=localhost;" +
            "Database=latexapp;" +
           "User ID=root;" +
           "Password=131001;";

            string sql = "SELECT * FROM client_data WHERE Name = @Name";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", SearchNameText.Text.Trim());

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string employee = reader["employee"].ToString();
                        int transportFee = Convert.ToInt32(reader["Transport_fee"]);
                        string billing = reader["Preferred_billing"].ToString();
                        int? unpaidValue = ReadIntOrNull(reader, "unpaid");
                        string unpaidText = unpaidValue.HasValue ? unpaidValue.Value.ToString() : "no data";

                        string remark = ReadStringOrNoData(reader, "remark");
                        DisplayClientInfo(name, employee, transportFee, billing,unpaidText,remark);
                    }
                    else
                    {
                        searchreporttextbox.Clear();
                        searchreporttextbox.Text = "ไม่พบข้อมูล";
                    }
                }
            }
        }
        private string ReadStringOrNoData(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? "no data"
                : reader[columnName].ToString();
        }

        private int? ReadIntOrNull(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(reader[columnName]);
        }
        private void DisplayClientInfo(string name, string employee, int transportFee, string billing,string unpaid,string remark)
        {
            var sb = new StringBuilder();
            string carfeetostring;
            if (transportFee == 0)
            {
                carfeetostring = "ไม่บวก";
            }
            else
            {
                carfeetostring = "บวก";
            }
            sb.AppendLine("ข้อมูลลูกค้า");
            sb.AppendLine("----------------------------");
            sb.AppendLine($"เถ้าแก่              : {name}");
            sb.AppendLine($"ลูกน้อง              : {employee}");
            sb.AppendLine($"ค่ารถ               : {carfeetostring}");
            sb.AppendLine($"แบ่ง                : {billing}");
            sb.AppendLine($"ยอดค้าง             : {unpaid}");
            sb.AppendLine($"หมายเหตุ            : {remark}");
            searchreporttextbox.Clear();
            searchreporttextbox.Text = sb.ToString();
        }
    }
}
