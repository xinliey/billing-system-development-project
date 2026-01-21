using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatexApp0
{

    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            Form1 form1 = new Form1();
            reportForm form2 = new reportForm();

            form1.StartPosition = FormStartPosition.Manual;
            form1.Bounds = new Rectangle(
                screen.Left,
                screen.Top,
                screen.Width / 2,
                screen.Height
            );
            form2.StartPosition = FormStartPosition.Manual;
            form2.Bounds = new Rectangle(
                screen.Left + screen.Width / 2,
                screen.Top,
                screen.Width / 2,
                screen.Height
            ); 
            form1.Show();
            form2.Show();

            Application.Run();
        }
    }
}
