using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
                "SELECT cd.Name,cd.employee,cd.Preferred_billing,cd.Transport_fee, " +
                "cd.unpaid, cd.remark,cpr.date,cpr.netweight,cpr.percentage, " +
                "cpr.remark1 AS percentage_remark " +
                " FROM latexapp.client_data cd " +
                "LEFT JOIN latexapp.client_percentage_record cpr " +
                "ON cd.Name = cpr.Name " +
                " AND cpr.date >= CURDATE() - INTERVAL 7 DAY "+
                "WHERE cd.Name = @Name  " +
                
                "ORDER BY cpr.date DESC;";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", SearchNameText.Text.Trim());

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    bool headerPrinted = false;

                    while (reader.Read())
                    {
                        if (!headerPrinted)
                        {
                            // Client info (same for every row)
                            string name = reader["Name"].ToString();
                            string employee = reader["employee"].ToString();
                            int transportFee = Convert.ToInt32(reader["Transport_fee"]);
                            string billing = reader["Preferred_billing"].ToString();
                            int? unpaidValue = ReadIntOrNull(reader, "unpaid");
                            string unpaidText = unpaidValue.HasValue ? unpaidValue.Value.ToString() : "ไม่มีข้อมูล";
                            string remark = ReadStringOrNoData(reader, "remark");

                            DisplayClientInfo(name, employee, transportFee, billing, unpaidText, remark);

                            headerPrinted = true;
                        }
                        string date = ReadDateOrNoData(reader, "date");
                        string netweight = ReadIntOrNull(reader, "netweight")?.ToString() ?? "-";
                        string percent = ReadIntOrNull(reader, "percentage")?.ToString() ?? "-";
                        string remark1 = ReadStringOrNoData(reader, "percentage_remark");

                        AppendPercentageRow(date, netweight, percent, remark1);
                    }
                }
            }

        }
        private void AppendPercentageRow(string date, string netweight, string percent, string remark)
        {
            searchreporttextbox.AppendText(
                $"{date.PadRight(18)}{netweight.PadRight(18)}{percent.PadRight(18)}{remark}\n"
            );
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
            sb.AppendLine($"เถ้าแก่  : {name}");
            sb.AppendLine($"ลูกน้อง  : {employee}");
            sb.AppendLine($"ค่ารถ   : {carfeetostring}");
            sb.AppendLine($"แบ่ง    : {billing}");
            sb.AppendLine($"ยอดค้าง  : {unpaid}");
            sb.AppendLine($"หมายเหตุ : {remark}");
            sb.AppendLine("----------------------------");
            sb.AppendLine("เปอร์เซ็นย้อนหลัง7วัน");
            sb.AppendLine("วันที่".PadRight(20) + "น้ำหนัก".PadRight(18)+ "เปอร์เซ็น".PadRight(18) + "หมายเหตุ");
            
         
            searchreporttextbox.Clear();
            searchreporttextbox.Text = sb.ToString();
        }

        private void SearchNameText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
