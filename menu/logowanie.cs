using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    public partial class logowanie : Form
    {
        
        public logowanie()
        {
            InitializeComponent();
            button_zaloguj.Visible= false;
            

        }
        private void textBox_Login_TextChanged(object sender, EventArgs e)
        {
            if(textBox_Login.Created)
            {
                button_zaloguj.Visible = true;
            }
            if(textBox_Login.Text == "")
            {
                button_zaloguj.Visible = false;
            }
        }

        private void button_zaloguj_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
            
            
            

            menu.to.lab_log.Text = textBox_Login.Text;
        }

        
    }
}
