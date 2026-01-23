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
    public partial class SearchTabUserControl : System.Windows.Forms.UserControl
    {

        public Button SearchButton => button1;
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
                        string unpaidText = unpaidValue.HasValue ? unpaidValue.Value.ToString() : "ไม่มีข้อมูล";

                        string remark = ReadStringOrNoData(reader, "remark");


                        int? percent1 = ReadIntOrNull(reader, "percentage1");
                        string pc1Text = percent1.HasValue ? percent1.Value.ToString() : "ไม่มีข้อมูล";
                        string remark1 = ReadStringOrNoData(reader, "remark1");
                        string date1 = ReadDateOrNoData(reader, "date"); 
                        int? percent2 = ReadIntOrNull(reader, "precentage2");
                        string pc2Text = percent2.HasValue ? percent2.Value.ToString() : "ไม่มีข้อมูล";
                        string date2 = ReadDateOrNoData(reader, "date2");
                        string remark2 = ReadStringOrNoData(reader, "remark2");
                        int? percent3 = ReadIntOrNull(reader, "percentage3");
                        string pc3Text = percent3.HasValue ? percent3.Value.ToString() : "ไม่มีข้อมูล";
                        string date3 = ReadDateOrNoData(reader, "date3");
                        string remark3 = ReadStringOrNoData(reader, "remark3");

                        DisplayClientInfo(name, employee, transportFee, billing, unpaidText, remark, date1, pc1Text,remark1, date2, pc2Text,remark2, date3, pc3Text,remark3);
                    }
                    else
                    {
                        searchreporttextbox.Clear();
                        searchreporttextbox.Text = "ไม่มีข้อมูล";
                    }
                }
            }

        }
        private string ReadDateOrNoData(MySqlDataReader reader, string columnName)
        {
            if (reader[columnName] == DBNull.Value)
                return "ไม่มีข้อมูล";

            return Convert.ToDateTime(reader[columnName]).ToString("yyyy/M/d");
        }
        private string ReadStringOrNoData(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? "-"
                : reader[columnName].ToString();
        }

        private int? ReadIntOrNull(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(reader[columnName]);
        }
        private void DisplayClientInfo(string name, string employee, int transportFee, string billing,string unpaid,string remark
            ,string date1, string pc1text,string remark1,string date2,string pc2text, string remark2,string date3 , string pc3text, string remark3)
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
            sb.AppendLine("----------------------------");
            sb.AppendLine("เปอร์เซ็นย้อนหลัง3งัน");
            sb.AppendLine("วันที่".PadRight(20) + "เปอร์เซ็น".PadRight(18) + "หมายเหตุ");
            sb.AppendLine(
                date1.PadRight(16) +
                pc1text.PadRight(18) +
                remark1
            );
            sb.AppendLine(
                date2.PadRight(16) +
                pc2text.PadRight(18) +
                remark2
            );
            sb.AppendLine(
                date3.PadRight(16) +
                pc3text.PadRight(18) +
                remark3
            );
            searchreporttextbox.Clear();
            searchreporttextbox.Text = sb.ToString();
        }
    }
}
