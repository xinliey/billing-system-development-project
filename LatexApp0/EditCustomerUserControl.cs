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
    public partial class EditCustomerUserControl : UserControl
    {
        public EditCustomerUserControl()
        {
            InitializeComponent();
            GetUserList();
        }
        private void GetUserList()
        {
            var names = new AutoCompleteStringCollection();

            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";
            string sql = "SELECT Name" +
                " FROM latexapp.client_data" +
                "; ";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["Name"] != DBNull.Value)
                        {
                            names.Add(reader["Name"].ToString());
                        }

                    }

                }
            }
           
            CustomerBossSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CustomerBossSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

           CustomerBossSearch.AutoCompleteCustomSource = names;
        }

        private void CustomerBossSearch_TextChanged(object sender, EventArgs e)
        {
            string connString =
         "Server=localhost;" +
          "Database=latexapp;" +
         "User ID=root;" +
         "Password=131001;";
            string sql =
                "SELECT Name,employee,Preferred_billing,Transport_fee, " +
                " remark" +
                " FROM latexapp.client_data " +
                "WHERE Name = @Name;  ";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", CustomerBossSearch.Text.Trim());

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {


                    if (reader.Read())
                    {// Client info (same for every row)
                       
                        string employee = reader["employee"].ToString();
                        int transportFee = Convert.ToInt32(reader["Transport_fee"]);
                        string billing = reader["Preferred_billing"].ToString();
                        
                        string remark = ReadStringOrNoData(reader, "remark");

                        DisplayClientInfo(employee, transportFee, billing, remark);

                    }
                }
            }
        }
        private void DisplayClientInfo(string employee, int transport , string billing, string remark )
        {
            EditEmployee.Text = employee;
            if (transport == 1)
            {
                CarFee.Checked = true;
            }
            else
            {
                CarFee.Checked = false;
            }
            preferred_payment.Text = billing;
            customerremark.Text = remark;
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

        private void NewCustomerSaveBtn_Click(object sender, EventArgs e)
        {
            string connString =
               "Server=localhost;" +
               "Database=latexapp;" +
               "User ID=root;" +
               "Password=131001;";
            string sql = @"
INSERT INTO latexapp.client_data
    (Name, employee, Transport_fee, Preferred_billing, remark)
VALUES
    (@Name, @employee, @Transport_fee,@Preferred_billing,  @remark)
AS new
ON DUPLICATE KEY UPDATE
    employee = new.employee,
    Transport_fee = new.Transport_fee,
    Preferred_billing = new.Preferred_billing,
    
    remark = new.remark;
";

            string name = CustomerBossSearch.Text.Trim();
            string employee = EditEmployee.Text.Trim();
            int transportFee = CarFee.Checked ? 1 : 0;
            string preferredBilling = preferred_payment.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Customer name is required.");
                return;
            }

          
                using (var conn = new MySqlConnection(connString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Employee", employee);
                    cmd.Parameters.AddWithValue("@Transport_Fee", transportFee);
                    cmd.Parameters.AddWithValue("@Preferred_Billing", preferredBilling);
                if (customerremark.Text != null)
                {
                    cmd.Parameters.AddWithValue("@remark", customerremark.Text);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@remark","-");
                }
                
                conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("แก้ไขช้อมูลสำเร็จ!");
                }
            
        }
    }
}
