using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LatexApp0
{
    public partial class Latexprintbilluser : UserControl
    {

        string Transportfee;
        string bill;
        int? unpaid;
        string unpaidText;
        string remarkText;
        float divide;
        // int index;
        int price;
        float total;
        bool CarFeePay;
        int netweight;
        public Latexprintbilluser()
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
            nameforbill.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameforbill.AutoCompleteSource = AutoCompleteSource.CustomSource;

            nameforbill.AutoCompleteCustomSource = names;
        }

        private void latexweight_TextChanged(object sender, EventArgs e)
        {
            TextChangeRecalculation();


        }
        private void bucketweight_TextChanged(object sender, EventArgs e)
        {
            TextChangeRecalculation();
        }
        private void percentforbill_TextChanged(object sender, EventArgs e)
        {

            TextChangeRecalculation();
        }
        private void save_latex_btn_Click(object sender, EventArgs e)
        {
            SaveBillIntoDB(); //this one for percentage record
        }
        private void save_latex_print_btn_Click(object sender, EventArgs e)
        {
            SaveBillIntoDB(); ;
            PrintBill(); //this one for printing actual bill 
        }
        private void TextChangeRecalculation()
        {

            float latex_weight = 0f;
            float bucket_weight = 0f;
            float latex_percent = 0f;
            float net_weight = 0f;
            float latex_afterdry = 0f;
            float.TryParse(latexweight.Text, out latex_weight); //for UI better use TryParse instead of parse
            float.TryParse(bucketweight.Text, out bucket_weight);
            float.TryParse(percentforbill.Text, out latex_percent);
            net_weight = (latex_weight - bucket_weight);
            netweightforbill.Text = net_weight.ToString("0.##");
            netweight = (int)net_weight;
            if (latex_percent != 0f)
            {
                latex_afterdry = (float)Math.Round(
                net_weight * (latex_percent / 100f), 1, MidpointRounding.AwayFromZero);

                latexafterdry.Text = latex_afterdry.ToString("0.0");

                DecidePrice(latex_percent);

                total = latex_afterdry * price;
                totalforbill.Text = total.ToString("0");
                if (CarFeePay == true)
                {
                    carfeetextbx.Text = ((int)latex_afterdry).ToString();
                }


                DividingBill();
            }
        }
        private void DecidePrice(float percent)
        {

            var prices = AppState.Instance.PercentPrices;

            if (prices.Count == 0)
            {
                MessageBox.Show("Price list not initialized");
                return;
            }

            int index;

            if (percent < 20) index = 0;
            else if (percent < 25) index = 1;
            else if (percent < 30) index = 2;
            else if (percent < 33) index = 3;
            else if (percent < 36) index = 4;
            else if (percent < 38) index = 5;
            else if (percent < 40) index = 6;
            else if (percent < 41) index = 7;
            else if (percent < 42) index = 8;
            else index = 9;
            //MessageBox.Show($"index is {index}");
            //index = Math.Min(index, prices.Count - 1);
            price = prices[index];
            priceforbill.Text = price.ToString();

        }
        private void DividingBill()
        {
            float boss;
            //use case for 60_40 , we will connect to database later

            boss = (float)Math.Round(
               total * (divide), 0, MidpointRounding.AwayFromZero);
            float employee = total - boss;
            bossdivisionforbill.Text = boss.ToString("0");
            employeedivisionforbill.Text = employee.ToString("0");


        }
        private void PrintBill()
        {
            var printbill = new BillPrintModel
            {
                BillDate = DateTime.Now,
                CustomerName = nameforbill.Text,
                TotalWeight = latexweight.Text,
                BucketWeight = bucketweight.Text,
                NetWeight = netweightforbill.Text,
                Percentage = percentforbill.Text,
                DryLatex = latexafterdry.Text,
                Price = priceforbill.Text,
                TotalPayment = totalforbill.Text


            };

            if (bill == "100") //for no devision bill
            {
                var printer = BillPrinterFactory.Create(printbill);
                printer.Preview();//preview first dont print yet 
            }
            else
            {
                MessageBox.Show("under development for bill division");
            }



        }

        private void SaveBillIntoDB()
        {
            string finalremark = "";

            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                finalremark = richTextBox1.Text; 
                UpdateUnpaidRemark();
            }

            if (!string.IsNullOrEmpty(remarktextbox.Text))
            {
                finalremark += remarktextbox.Text;
            }
            if (string.IsNullOrWhiteSpace(nameforbill.Text) ||
                string.IsNullOrWhiteSpace(percentforbill.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อและเปอร์เซ็นต์ก่อนบันทึก");
                return; // stop here
            }
            //after pressing save button , the panel will be refreshed 
            //more convenient for user to move to next bill
            
            string connString =
               "Server=localhost;" +
               "Database=latexapp;" +
               "User ID=root;" +
               "Password=131001;";
            string sql = @"INSERT INTO latexapp.client_percentage_record (Name, date, netweight, percentage)
            VALUES (@Name, @Date, @Netw, @Percent)
            AS new ON DUPLICATE KEY UPDATE netweight  = new.netweight, percentage = new.percentage;";
            string sql1 = @"INSERT INTO latexapp.client_percentage_record (Name, date, netweight, percentage,remark1)
            VALUES (@Name, @Date, @Netw, @Percent,@remark1)
            AS new ON DUPLICATE KEY UPDATE netweight  = new.netweight, percentage = new.percentage ,remark1 = new.remark1;;";
            string sql2 = "UPDATE client_data SET remark = @RemarkData " +
                "WHERE Name = @Name; ";


            using (var conn = new MySqlConnection(connString))
                if (finalremark!="")//if one of the remark is not null , update remark in record
                {
                    using (var cmd = new MySqlCommand(sql1, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@Name", nameforbill.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today);
                        cmd.Parameters.AddWithValue("@Netw", netweight);

                        cmd.Parameters.AddWithValue("@Percent", percentforbill.Text);
                        cmd.Parameters.AddWithValue("@remark1", finalremark);

                         
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                else //if null , leave the remark in record the same way no chage 
                {
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nameforbill.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today);
                        cmd.Parameters.AddWithValue("@Netw", netweight);

                        cmd.Parameters.AddWithValue("@Percent", percentforbill.Text);
                        


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            if (finalremark != "") //if remark is not empty , update client data too
            {
                
                using (var conn = new MySqlConnection(connString))
                using (var cmd = new MySqlCommand(sql2, conn))
                {
                    remarkbilltextbx.Clear();
                    cmd.Parameters.AddWithValue("@Name", nameforbill.Text);
                    cmd.Parameters.AddWithValue("@RemarkData", finalremark);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
          
      
            MessageBox.Show("บันทึกข้อมูลสำเร็จ!");


            latexweight.Clear();
            bucketweight.Clear();
            percentforbill.Clear();
            nameforbill.Clear();
            remarktextbox.Clear();
            remarkbilltextbx.Clear();
            percentrecorddisplay.Clear();


        }


        private void nameforbill_TextChanged(object sender, EventArgs e)
        {

            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";
            string sql = "SELECT Transport_fee,Preferred_billing,unpaid" +
                " FROM latexapp.client_data where Name=@Name;";
            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", nameforbill.Text.Trim());

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Transportfee = reader["Transport_fee"].ToString();
                        bill = reader["Preferred_billing"].ToString();
                        unpaid = ReadIntOrNull(reader, "unpaid");
                        unpaidText = unpaid.HasValue ? unpaid.Value.ToString() : "ไม่มี";


                    }

                }
                if (unpaidText == "ไม่มี")
                {
                    remarkbilltextbx.Clear();

                }
                else
                {
                    remarkbill.Visible = true;
                    remarkbilltextbx.Visible = true;
                    remarkbilltextbx.Clear();
                    remarkbilltextbx.AppendText($"ยอดค้าง : {unpaidText},\n");
                }
                if (remarkText == "-")
                {
                    remarkbill.Visible = false;
                    remarkbilltextbx.Visible = false;
                }
                else
                {
                    remarkbill.Visible = true;
                    remarkbilltextbx.Visible = true;
                    remarkbilltextbx.Clear();
                    remarkbilltextbx.AppendText($"{remarkText}\n");
                }

                DefineDvd(bill);
                DisplayRecord(nameforbill.Text);
                if (Transportfee == "1")
                {
                    CarFeePay = true;
                    carfeetext.Visible = true;
                    carfeetextbx.Visible = true;
                }
                else
                {
                    CarFeePay = false;

                    carfeetext.Visible = false;
                    carfeetextbx.Visible = false;
                }

            }

        }
        private void DisplayRecord(String name)
        {
            string connString =
               "Server=localhost;" +
               "Database=latexapp;" +
               "User ID=root;" +
               "Password=131001;";
            string sql = "SELECT date_format(date,\"%d/%m\") AS dateRecord , netweight, percentage, remark1" +
                " FROM latexapp.client_percentage_record" +
                " WHERE Name=@Name;";
            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name.Trim());

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = reader["dateRecord"].ToString();
                        string net_weight = reader["netweight"].ToString();
                        string percent = reader["percentage"].ToString();
                        string remark = ReadStringOrNoData(reader, "remark1");
                        PutToTextRecord(date, net_weight, percent, remark);
                    }
                }

            }

        }
        private void PutToTextRecord(string date, string weight, string percent, string remark)
        {
            //percentrecorddisplay.Clear(); 
            percentrecorddisplay.AppendText($"{date}\t|  {weight}/{percent}%  {remark}\n");

        }
        private void DefineDvd(string bill)
        {
            if (bill == "60_40")
            {
                bossdivisionforbill.Visible = true;
                bossdvdtext.Visible = true;

                employeedivisionforbill.Visible = true;
                employeedvdtext.Visible = true;
                bossdvd.Text = "60%";
                emplydvd.Text = "40%";
                divide = 0.6f;
            }
            else if (bill == "50_50")
            {
                bossdivisionforbill.Visible = true;
                bossdvdtext.Visible = true;

                employeedivisionforbill.Visible = true;
                employeedvdtext.Visible = true;
                bossdvd.Text = "50%";
                emplydvd.Text = "50%";
                divide = 0.5f;
            }
            else if (bill == "100")
            {
                bossdvd.Text = "";
                emplydvd.Text = "";
                divide = 1f;
                bossdivisionforbill.Visible = false;
                bossdvdtext.Visible = false;

                employeedivisionforbill.Visible = false;
                employeedvdtext.Visible = false;
            }

        }
        private int? ReadIntOrNull(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(reader[columnName]);
        }
        private string ReadStringOrNoData(MySqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                ? "-"
                : reader[columnName].ToString();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            RichTextBox tb = sender as RichTextBox;

            // Allow control keys (Backspace, Delete)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-"))
                return;

            // Block everything else
            e.Handled = true;
            

        }
        private void UpdateUnpaidRemark()
        {
            int number = int.Parse(richTextBox1.Text);
            string connString =
                "Server=localhost;" +
                "Database=latexapp;" +
                "User ID=root;" +
                "Password=131001;";
            string sql = "UPDATE latexapp.client_data " +
"SET unpaid = COALESCE(unpaid, 0) + @updateUnpaid " +
" WHERE Name = @Name; ";

            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                MessageBox.Show("trying to update unpaid");
                cmd.Parameters.AddWithValue("@Name", nameforbill.Text);
                cmd.Parameters.AddWithValue("@updateUnpaid",number);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
