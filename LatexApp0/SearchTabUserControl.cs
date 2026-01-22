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
            string sql =
                "SELECT cd.Name, cd.employee,cd.Preferred_billing, cd.Transport_fee, cd.unpaid, cd.remark, " +
                "cpr.percentage1, cpr.`date`, cpr.remark1, cpr.precentage2, cpr.date2, cpr.remark2, " +
                "cpr.percentage3, cpr.date3, cpr.remark3 " +
                "FROM latexapp.client_data cd " +
                "LEFT JOIN latexapp.client_percentage_record cpr " +
                "ON cd.Name = cpr.Name " +
                "WHERE cd.Name = @Name;";

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

                        
                        int? percent1 = ReadIntOrNull(reader, "percentage1");
                        string pc1Text = percent1.HasValue ? percent1.Value.ToString() : "no data";
                        string date1 = reader["date"].ToString();
                        int? percent2 = ReadIntOrNull(reader, "precentage2");
                        string pc2Text = percent2.HasValue ? percent2.Value.ToString() : "no data";
                        string date2 = reader["date2"].ToString();
                        int? percent3 = ReadIntOrNull(reader, "precentage2");
                        string pc3Text = percent2.HasValue ? percent2.Value.ToString() : "no data";
                        string date3 = reader["date3"].ToString();
                        DisplayClientInfo(name, employee, transportFee, billing,unpaidText,remark,date1,pc1Text,date2,pc2Text,date3,pc3Text);
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
                ? "ไม่มี"
                : reader[columnName].ToString();
        }

        private int? ReadIntOrNull(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(reader[columnName]);
        }
        private void DisplayClientInfo(string name, string employee, int transportFee, string billing,string unpaid,string remark
            ,string date1, string pc1text,string date2,string pc2text,string date3 , string pc3text)
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
            sb.AppendLine($"เถ้าแก่  : {name}");
            sb.AppendLine($"ลูกน้อง  : {employee}");
            sb.AppendLine($"ค่ารถ   : {carfeetostring}");
            sb.AppendLine($"แบ่ง    : {billing}");
            sb.AppendLine($"ยอดค้าง  : {unpaid}");
            sb.AppendLine($"หมายเหตุ : {remark}");
            sb.AppendLine($"{date1}: {pc1text}");
            sb.AppendLine($"{date2}: {pc2text}");
            sb.AppendLine($"{date3}: {pc3text}");
            searchreporttextbox.Clear();
            searchreporttextbox.Text = sb.ToString();
        }
    }
}
