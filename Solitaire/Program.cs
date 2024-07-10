using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire
{
    static class Program
    {

        private static void showMainForm()
        {
            MainForm form = new MainForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Retry) showMainForm();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            showMainForm();
        }
    }
}
