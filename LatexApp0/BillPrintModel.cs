using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatexApp0
{
    public class BillPrintModel
    {//for no division customer 
       
            public string CustomerName { get; set; }
            public DateTime BillDate { get; set; }
            public string TotalWeight { get; set; }
            public string BucketWeight { get; set; }
            public string NetWeight { get; set; }
            public string Percentage { get; set; }
            public string DryLatex { get; set; }
            
            public string Price { get; set; }
            public string TransportFee { get; set; }
            
            public string TotalPayment { get; set; }
        

    }
}
