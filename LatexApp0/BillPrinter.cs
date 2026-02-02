using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LatexApp0
{
    public class BillPrinter
    {

        private readonly BillPrintModel _bill;

        public BillPrinter(BillPrintModel bill)
        {
            _bill = bill;
        }
    
        public void Preview()
        {
            PrintDocument doc = CreateDocument();
            
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 800,
                Height = 600
            };
            preview.ShowDialog();
        }

        public void Print()
        {
            PrintDocument doc = CreateDocument();
            // doc.PrinterSettings.PrinterName = "XP-58";//write the name of printer later 
          
doc.Print();
            
        } 
        private PrintDocument CreateDocument()
        {
            PrintDocument doc = new PrintDocument();
            if (_bill.employee != "0")
            {
                doc.PrintPage += PrintPage;
                return doc;
            }
            else
            {
                doc.PrintPage += SinglePrintPage;
                return doc;
            }
            
        }
        private void SinglePrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            //top left corner
            int topside = 60;
            int topup = 15;


            Font headerFont = new Font("Tahoma", 14, FontStyle.Bold);
            Font normalFont = new Font("Tahoma", 12);
            Font boldFont = new Font("Tahoma", 12, FontStyle.Bold);
            Font smallFont = new Font("Tahoma", 8);
            //component for first bill on the left
            int marginLeft = 15;
            int contentWidth = 350; //bill's width 
            int contentHeight = 250;
            int col1LabelX = marginLeft + 60;
            int col1ValueX = marginLeft + 220;

            int col2LabelX = marginLeft + 230;
            int col2ValueX = marginLeft + 370;
            int y = 30;
            int line = 30; //next line
            int sectino = 10;//smaller next line 

            //component for 2nd bill on the right
            int marginRight = 380;
            int z = 30;
          
            int col1LabelX2 = marginRight + 60;
            int col1ValueX2 = marginRight + 220;

            int col2LabelX2 = marginRight + 230;
            int col2ValueX2 = marginRight + 370;
            StringFormat rightAlign = new StringFormat
            {
                Alignment = StringAlignment.Far
            };
            g.DrawRectangle(Pens.Black, topside, topup, contentWidth, contentHeight);


            g.DrawString("ร้านเกษรคลองแงะ", headerFont, Brushes.Black, marginLeft + 130, y - 5);
            y += line;

            g.DrawLine(Pens.Black, marginLeft + 50, y, marginLeft + contentWidth + 40, y);
            y += sectino;


            g.DrawString($"{_bill.CustomerName} ", headerFont, Brushes.Black, marginLeft + 70, y);

            g.DrawString($"วันที่ {_bill.BillDate:dd-MM-yyyy} ",
                headerFont, Brushes.Black,
                marginLeft + contentWidth + 30, y, rightAlign);

            y += line;
            g.DrawLine(Pens.Black, marginLeft + 50, y, marginLeft + contentWidth + 40, y);
            y += sectino;

            // Row 1{_bill.TotalWeightและ {_bill.BucketWeight}
            g.DrawString("น้ำหนัก", normalFont, Brushes.Black, col1LabelX, y);
            g.DrawString($"{_bill.TotalWeight} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);

            g.DrawString("ถัง", normalFont, Brushes.Black, col2LabelX, y);
            g.DrawString($"{_bill.BucketWeight} kg", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

            y += line;

            // Row 2{_bill.Price:N0}
            g.DrawString("น้ำหนักสุทธิ", normalFont, Brushes.Black, col1LabelX, y);
            g.DrawString($"{_bill.NetWeight} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
            g.DrawString("เปอร์เซ็น", normalFont, Brushes.Black, col2LabelX, y);
            g.DrawString($"{_bill.Percentage} %", normalFont, Brushes.Black, col2ValueX, y, rightAlign);
            y += line;
            g.DrawString("แห้ง", normalFont, Brushes.Black, col1LabelX, y);
            g.DrawString($"{_bill.DryLatex} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
            g.DrawString("ราคา", normalFont, Brushes.Black, col2LabelX, y);
            g.DrawString($"{_bill.Price} บาท", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

            y += line;

            g.DrawString("เป็นเงิน", normalFont, Brushes.Black, col1LabelX, y);
            g.DrawString($"{_bill.total} บาท", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
            y += line;
            g.DrawLine(Pens.Black, marginLeft + 40, y, marginLeft + contentWidth + 35, y);
            y += sectino;
            SizeF textSize = g.MeasureString("1000 บาท", boldFont);
            float side = col1ValueX - 105; float up = 240;
            g.FillRectangle(
    Brushes.Pink,
    side - 3,
    up - 2,
    textSize.Width + 7,
    textSize.Height + 3
);
            g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col1LabelX, y - 3);
            if (_bill.TransportFee != "")
            {
                g.DrawString($"{_bill.boss}+{_bill.TransportFee}={_bill.TotalPayment}", normalFont, Brushes.Black, col1ValueX - 15, y, rightAlign);

            }
            else
            {
                g.DrawString($"{_bill.boss}", boldFont, Brushes.Black, col1ValueX - 15, y, rightAlign);
            }



        }
        private void PrintPage(object sender, PrintPageEventArgs e)
         {
             Graphics g = e.Graphics;
            //top left corner
            int  topside = 60;
            int topup = 15;


            Font headerFont = new Font("Tahoma", 14, FontStyle.Bold);
             Font normalFont = new Font("Tahoma", 12);
             Font boldFont = new Font("Tahoma", 12, FontStyle.Bold);
            Font smallFont = new Font("Tahoma", 8);
            //component for first bill on the left
            int marginLeft = 15;       
             int contentWidth = 350; //bill's width 
            int contentHeight = 250;
             int col1LabelX = marginLeft+ 60;
             int col1ValueX = marginLeft +  220;

             int col2LabelX = marginLeft + 230;
             int col2ValueX = marginLeft + 370;
             int y = 30;
             int line = 30; //next line
             int sectino = 10;//smaller next line 

            //component for 2nd bill on the right
            int marginRight = 380;
            int z = 30;
            int line2 = 30;
            int section = 10;
            int col1LabelX2 = marginRight + 60;
            int col1ValueX2 = marginRight + 220;

            int col2LabelX2 = marginRight+ 230;
            int col2ValueX2 = marginRight + 370;
            StringFormat rightAlign = new StringFormat
             {
                 Alignment = StringAlignment.Far
             };
            g.DrawRectangle(Pens.Black, topside,topup, contentWidth, contentHeight);
           

             g.DrawString("ร้านเกษรคลองแงะ", headerFont, Brushes.Black, marginLeft+130, y-5);
             y += line;

             g.DrawLine(Pens.Black, marginLeft+50, y, marginLeft + contentWidth+40, y);
             y += sectino;

       
             g.DrawString($"{_bill.CustomerName} ", headerFont, Brushes.Black, marginLeft+50, y);

             g.DrawString($"{_bill.BillDate:dd-MM-yyyy} ",
                 headerFont, Brushes.Black,
                 marginLeft + contentWidth+30, y, rightAlign);

             y += line;
             g.DrawLine(Pens.Black, marginLeft+50, y, marginLeft + contentWidth+40, y);
             y += sectino;

             // Row 1{_bill.TotalWeightและ {_bill.BucketWeight}
             g.DrawString("น้ำหนัก", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"{_bill.TotalWeight} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);

             g.DrawString("ถัง", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"{_bill.BucketWeight} kg", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

             y += line;

             // Row 2{_bill.Price:N0}
             g.DrawString("น้ำหนักสุทธิ", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"{_bill.NetWeight} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
             g.DrawString("เปอร์เซ็น", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"{_bill.Percentage} %", normalFont, Brushes.Black, col2ValueX, y, rightAlign);
             y += line;
             g.DrawString("แห้ง", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"{_bill.DryLatex} kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
             g.DrawString("ราคา", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"{_bill.Price} บาท", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

             y += line;

             g.DrawString("เป็นเงิน", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"{_bill.total} บาท",normalFont, Brushes.Black, col1ValueX, y, rightAlign);
            y += line;
            g.DrawLine(Pens.Black, marginLeft +40, y, marginLeft + contentWidth+35, y);
            y += sectino;
            SizeF textSize = g.MeasureString("1000 บาท", boldFont);
            float side = col1ValueX -105; float up=240;
            g.FillRectangle(
    Brushes.Pink,
    side - 3,
    up - 2,
    textSize.Width + 7,
    textSize.Height+3
);
            g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col1LabelX, y-3); 
            if (_bill.TransportFee != "")
            {
                g.DrawString($"{_bill.boss}+{_bill.TransportFee}={_bill.TotalPayment}", normalFont, Brushes.Black, col1ValueX - 15, y, rightAlign);

            }
            else
            {
                g.DrawString($"{_bill.boss}", boldFont, Brushes.Black, col1ValueX - 15, y, rightAlign);
            }
           
            
 g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col2LabelX, y-3);
            g.DrawString($"{_bill.employee}", boldFont, Brushes.Black, col2ValueX-15, y, rightAlign);

            


            //2nd bill 
            g.DrawRectangle(Pens.Black, topside + 360, topup, contentWidth, contentHeight);
            g.DrawString("ร้านเกษรคลองแงะ", headerFont, Brushes.Black,marginRight+130, z-5);
            z += line;
            g.DrawLine(Pens.Black, marginRight + 40, z, marginRight + contentWidth+35, z);
            z += section;
            // Name (left) {_bill.CustomerName}
            g.DrawString($"{_bill.CustomerName} ", headerFont, Brushes.Black, marginRight+50, z);

            
            
            // Date (right){_bill.BillDate:dd-MM-yyyy}
            g.DrawString($"วันที่ : {_bill.BillDate:dd-MM-yyyy} ",
                headerFont, Brushes.Black,
                marginRight + contentWidth + 30, z, rightAlign);

            z += line;
            g.DrawLine(Pens.Black, marginRight + 40, z, marginRight + contentWidth + 35, z);
            z += section;

            // Row 1{_bill.TotalWeightและ {_bill.BucketWeight}
            g.DrawString("น้ำหนัก", normalFont, Brushes.Black, col1LabelX2, z);
            g.DrawString($"{_bill.TotalWeight} kg", normalFont, Brushes.Black, col1ValueX2, z, rightAlign);

            g.DrawString("ถัง", normalFont, Brushes.Black, col2LabelX2, z);
            g.DrawString($"{_bill.BucketWeight} kg", normalFont, Brushes.Black, col2ValueX2, z, rightAlign);

            z += line2;

            // Row 2{_bill.Price:N0}
            g.DrawString("น้ำหนักสุทธิ", normalFont, Brushes.Black, col1LabelX2, z);
            g.DrawString($"{_bill.NetWeight} kg", normalFont, Brushes.Black, col1ValueX2, z, rightAlign);
            g.DrawString("เปอร์เซ็น", normalFont, Brushes.Black, col2LabelX2, z);
            g.DrawString($"{_bill.Percentage} %", normalFont, Brushes.Black, col2ValueX2, z, rightAlign);
            z += line2;
            g.DrawString("แห้ง", normalFont, Brushes.Black, col1LabelX2, z);
            g.DrawString($"{_bill.DryLatex} kg", normalFont, Brushes.Black, col1ValueX2, z, rightAlign);
            g.DrawString("ราคา", normalFont, Brushes.Black, col2LabelX2, z);
            g.DrawString($"{_bill.Price} บาท", normalFont, Brushes.Black, col2ValueX2, z, rightAlign);
             
            z += line2;

            g.DrawString("เป็นเงิน", normalFont, Brushes.Black, col1LabelX2, z);
            g.DrawString($"{_bill.total} บาท", normalFont, Brushes.Black, col1ValueX2, z, rightAlign);
         
            z += line2;
            g.DrawLine(Pens.Black, marginLeft + 40, z, marginRight+ contentWidth + 35, z);
            z += section;
            g.DrawString($"ลูกน้อง", boldFont, Brushes.Black, col1ValueX2 - 15, z, rightAlign);
            g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col2LabelX2, z-3);
            
            float side2 = col2ValueX2-95; float up2 = 240;
            g.FillRectangle(
    Brushes.Pink,
    side2 ,
    up2- 2,
    textSize.Width + 7,
    textSize.Height+3);
            g.DrawString($"{_bill.employee}", boldFont, Brushes.Black, col2ValueX2, z, rightAlign);
        }

        private void DrawRow(Graphics g, string label, string value, int x, ref int y, int lineHeight)
         {
             Font f = new Font("Tahoma", 10);
             g.DrawString(label, f, Brushes.Black, x, y);
             g.DrawString(value, f, Brushes.Black, x + 200, y);
             y += lineHeight;
         }
         

    }
}
