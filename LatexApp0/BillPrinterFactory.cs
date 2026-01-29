using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatexApp0
{
    public class BillPrinterFactory//this class exist to prevent printing different bill at the same time from crashing
        //using instance type will lead the new bill to overwrite the old bill 
        //so this will create completely new bill to not intervine with existed one
    {
        public static BillPrinter Create(BillPrintModel bill)
        {
            return new BillPrinter(bill);
        }
    }
}
