using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;


namespace menu
{
    
    public partial class menu : Form
    {
        public static menu to;
        public Label lab_log;
        public menu() //konstruktor
        {
            InitializeComponent();
            RozwijanieMenu();

            logowanie log = new logowanie();
            log.Hide();

            to = this;
            lab_log = label_login;


            PanelGlowny();
            
        }

        FormaPrzeciągania formap = new FormaPrzeciągania();
        private void RozwijanieMenu()
        {
            if (this.panelMenu.Width > 200) //nierozwiniete
            {
                panelMenu.Width = 100;
                button_Menu.Visible = true;
                button_Menu.Width = 110;
                button_Menu.Height = 70;

                button_Menu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {   
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);

                }
            }
            else //rozwiniete
            {
                panelMenu.Width = 230;
                button_Menu.Visible = true;
                button_Menu.Width = 237;
                button_Menu.Height = 147;
                button_Menu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(20, 0, 0, 0);
                }
            }
        }
        public void PanelGlowny()
        {
            label_godzina.Text = DateTime.Now.ToString("t"); //godzina
            label_data.Text = DateTime.Now.ToString("d"); //data
        }
        private void button_Menu_Click(object sender, EventArgs e)
        {
            RozwijanieMenu();
        }

        private Form aktywnaforma = null;
        private void OtworzenieOkienka(Form malaForma) //otwieranie kategorii w okienku glownym (malym)
        {
            if (aktywnaforma != null)
                aktywnaforma.Close();
            aktywnaforma = malaForma;
            malaForma.TopLevel = false;
            malaForma.FormBorderStyle = FormBorderStyle.None;
            malaForma.Dock = DockStyle.Fill;
            panelGlowny.Controls.Add(malaForma);
            panelGlowny.Tag = malaForma;
            malaForma.BringToFront();
            malaForma.Show();
        }
        private void button_tdl_Click(object sender, EventArgs e)
        {
            OtworzenieOkienka(new tdl());
            menu menu = new menu();
            menu.Hide();
        }

        private void button_kalkulator_Click(object sender, EventArgs e)
        {
            OtworzenieOkienka(new kalkulator());
        }

        private void button_muzyka_Click(object sender, EventArgs e)
        {
            OtworzenieOkienka(new muzyka());
        }
    }
    public class FormaPrzeciągania
    {
        // forma przeciągania
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }

   
    
}
