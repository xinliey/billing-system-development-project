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
            doc.PrinterSettings.PrinterName = "XP-58";//write the name of printer later 
            doc.Print();
        } 
        private PrintDocument CreateDocument()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += PrintPage;
            return doc;
        }
        float CmToPx(Graphics g, float cm)
        {
            return cm * g.DpiX / 2.54f;
        }
        
         private void PrintPage(object sender, PrintPageEventArgs e)
         {
             Graphics g = e.Graphics;
            //top left corner
            int  topside = 60;
            int topup = 30;


            Font headerFont = new Font("Tahoma", 14, FontStyle.Bold);
             Font normalFont = new Font("Tahoma", 12);
             Font boldFont = new Font("Tahoma", 12, FontStyle.Bold);
            Font smallFont = new Font("Tahoma", 8);
            int marginLeft = 20;       
             int contentWidth = 360; //bill's width 
            int contentHeight = 250;
             int col1LabelX = marginLeft+ 60;
             int col1ValueX = marginLeft +  220;

             int col2LabelX = marginLeft + 230;
             int col2ValueX = marginLeft + 370;

             StringFormat rightAlign = new StringFormat
             {
                 Alignment = StringAlignment.Far
             };
            g.DrawRectangle(Pens.Black, topside,topup, contentWidth, contentHeight);
                int y = 30;
             int line = 30;
            int sectino = 10;
             g.DrawString("ร้านเกษรคลองแงะ", headerFont, Brushes.Black, marginLeft+130, y);
             y += line;

             g.DrawLine(Pens.Black, marginLeft+60, y, marginLeft + contentWidth, y);
             y += sectino;

             // Name (left) {_bill.CustomerName}
             g.DrawString($"ชื่อ : หนึ่งยางเช่า", headerFont, Brushes.Black, marginLeft+50, y);

             // Date (right){_bill.BillDate:dd-MM-yyyy}
             g.DrawString($"วันที่ : 29/1/2026 ",
                 headerFont, Brushes.Black,
                 marginLeft + contentWidth+30, y, rightAlign);

             y += line;
             g.DrawLine(Pens.Black, marginLeft+40, y, marginLeft + contentWidth+35, y);
             y += sectino;

             // Row 1{_bill.TotalWeightและ {_bill.BucketWeight}
             g.DrawString("น้ำหนัก", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"120 kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);

             g.DrawString("ถัง", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"12 kg", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

             y += line;

             // Row 2{_bill.Price:N0}
             g.DrawString("น้ำหนักสุทธิ", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"108 kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
             g.DrawString("เปอร์เซ็น", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"36 %", normalFont, Brushes.Black, col2ValueX, y, rightAlign);
             y += line;
             g.DrawString("แห้ง", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"22.2 kg", normalFont, Brushes.Black, col1ValueX, y, rightAlign);
             g.DrawString("ราคา", normalFont, Brushes.Black, col2LabelX, y);
             g.DrawString($"2014 บาท", normalFont, Brushes.Black, col2ValueX, y, rightAlign);

             y += line;

             g.DrawString("เป็นเงิน", normalFont, Brushes.Black, col1LabelX, y);
             g.DrawString($"2000 บาท",normalFont, Brushes.Black, col1ValueX, y, rightAlign);
            y += line;
            g.DrawLine(Pens.Black, marginLeft +40, y, marginLeft + contentWidth+35, y);
            y += sectino;
            SizeF textSize = g.MeasureString("1000 บาท", boldFont);
            float side = col1ValueX -100; float up=240;
            g.FillRectangle(
    Brushes.Yellow,
    side - 3,
    up - 2,
    textSize.Width + 6,
    textSize.Height
);
            g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col1LabelX, y); 
            g.DrawString($"1000 บาท", boldFont, Brushes.Black, col1ValueX-15, y, rightAlign);
            g.DrawString("แบ่ง\n50", smallFont, Brushes.Black, col2LabelX, y);
            g.DrawString($"1000 บาท", boldFont, Brushes.Black, col2ValueX, y, rightAlign);


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
