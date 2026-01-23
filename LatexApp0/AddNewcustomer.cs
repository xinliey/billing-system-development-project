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
using MySql.Data.MySqlClient;

namespace LatexApp0
{

    public partial class AddNewcustomer : System.Windows.Forms.UserControl
    {
        /*cmd for sql : INSERT INTO `latexapp`.`client_data` 
         * (`Name`, `employee`, `Transport_fee`,`Preferred_billing`) VALUES ('', '', '0','60_40');*/
        public AddNewcustomer()
        {
            InitializeComponent();
        }

        private void NewCustomerSaveBtn_Click(object sender, EventArgs e)
        {
            SaveCustomer();

        }
        private void TestConnection()
        {
            string connString =
            "Server=localhost;" +
             "Database=latexapp;" +
            "User ID=root;" +
            "Password=131001;";

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                MessageBox.Show("Connected!");
            }
        }

        private void SaveCustomer()
        {
            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";

            string sql = @"
        INSERT INTO client_data
        (Name, employee, Transport_fee, Preferred_billing)
        VALUES
        (@Name, @Employee, @TransportFee, @PreferredBilling);
    ";

            string name = NewCustomerBoss.Text.Trim();
            string employee = NewEmployee.Text.Trim();
            int transportFee = CarFee.Checked ? 1 : 0;
            string preferredBilling = preferred_payment.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Customer name is required.");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Employee", employee);
                    cmd.Parameters.AddWithValue("@TransportFee", transportFee);
                    cmd.Parameters.AddWithValue("@PreferredBilling", preferredBilling);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer saved successfully!");
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show(
                    "This customer already exists.\nPlease use a different name.",
                    "Duplicate Customer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            NewCustomerBoss.Clear();
            NewEmployee.Clear();
            CarFee.Checked = false;
            preferred_payment.SelectedItem = "100";
        }
    }
}
