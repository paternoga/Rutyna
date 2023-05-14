using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            

            logowanie loginForm = new logowanie();
            loginForm.Width = 455;
            loginForm.Height = 480;
            
            
            Application.Run(loginForm);

            

        }
    }
}
