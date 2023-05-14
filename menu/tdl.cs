using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    public partial class tdl : Form
    {
        public tdl()
        {
            InitializeComponent();
            
            this.Load += tdl_Load;
            menu menu = new menu();
            menu.Hide();
        }

        FormaPrzeciągania formap = new FormaPrzeciągania();

        public class FormaPrzeciągania
        {
            // forma przeciągania
            [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
            private extern static void ReleaseCapture();

            [DllImport("user32.DLL", EntryPoint = "SendMessage")]
            private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        }

        

       

        private void tdl_Load(object sender, EventArgs e)
        {
            string fileName = "dane.txt";

            if (File.Exists(fileName))
            {
                listBox1.Items.Clear();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                }


            }
            else
            {
                MessageBox.Show("Plik " + fileName + " nie istnieje.");
            }
        }

        private void button_dodaj_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }
        private void button_usun_Click(object sender, EventArgs e)
        {
            int l = listBox1.SelectedIndex;

            if (l >= 0)
            {
                listBox1.Items.RemoveAt(l);
            }
            else
            {
                MessageBox.Show("błąd");
            }
        }
        private void button_wyczysc_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }
        private void button_zapisz_Click(object sender, EventArgs e)
        {
            // Tworzenie nowego obiektu klasy SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Ustawienie domyślnego filtra dla plików
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // Wyświetlenie okna dialogowego i sprawdzenie, czy użytkownik wybrał plik
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobranie nazwy wybranego pliku
                string fileName = "dane.txt";

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (string item in listBox1.Items)
                    {
                        writer.WriteLine(item);
                    }
                }


            }

        }
        private void button_edytuj_Click(object sender, EventArgs e)
        {
            int l = listBox1.SelectedIndex;

            if (l >= 0)
            {
                listBox1.Items.RemoveAt(l);
                listBox1.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("błąd");
            }
        }
        private void button_dol_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy użytkownik wybrał element
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                return;
            }

            // Pobranie indeksu wybranego elementu
            int index = listBox1.SelectedIndex;

            // Usunięcie wybranego elementu z listy
            string item = listBox1.SelectedItem.ToString();
            listBox1.Items.RemoveAt(index);

            // Dodanie wybranego elementu na nową pozycję
            listBox1.Items.Insert(index + 1, item);

            // Ustawienie zaznaczenia na przesuniętym elemencie
            listBox1.SetSelected(index + 1, true);
        }
        private void button_gora_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy użytkownik wybrał element
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex == 0)
            {
                return;
            }

            // Pobranie indeksu wybranego elementu
            int index = listBox1.SelectedIndex;

            // Usunięcie wybranego elementu z listy
            string item = listBox1.SelectedItem.ToString();
            listBox1.Items.RemoveAt(index);

            // Dodanie wybranego elementu na nową pozycję
            listBox1.Items.Insert(index - 1, item);

            // Ustawienie zaznaczenia na przesuniętym elemencie
            listBox1.SetSelected(index - 1, true);
        }
    }


}
