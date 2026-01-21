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

    public partial class AddNewcustomer : UserControl
    {
     
        public AddNewcustomer()
        {
            InitializeComponent();
        }

        private void NewCustomerSaveBtn_Click(object sender, EventArgs e)
        {
            TestConnection();

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
    }
}
