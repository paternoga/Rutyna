using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace menu
{

    public partial class kalkulator : Form
    {
        String operacja = "";
        bool czyoperacja = false;
        Double rezultat = 0;
        public kalkulator()
        {
            InitializeComponent();
        }

        private void KliknięcieCyfry(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if ((textBox_kalkulator.Text == "0") || (czyoperacja))
            {
                textBox_kalkulator.Clear();
            }



            czyoperacja = false;

            if (textBox_kalkulator.Text == ".") //przypadek z 0.0
            {
                if (!textBox_kalkulator.Text.Contains("."))
                {
                    textBox_kalkulator.Text = textBox_kalkulator.Text + button.Text;
                }
            }
            else
            {
                textBox_kalkulator.Text = textBox_kalkulator.Text + button.Text;
            }




        }

        private void KliknięcieOperacji(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (rezultat != 0)
            {
                
                button_wynik.PerformClick();
                operacja = button.Text;
                
                czyoperacja = true;
            }
            else
            {
              
                operacja = button.Text;
              
                czyoperacja = true;
                rezultat = Double.Parse(textBox_kalkulator.Text);
            }
        }

        private void KliknięcieWyniku(object sender, EventArgs e)
        {
            switch (operacja)
            {
                case "+":
                    {
                        textBox_kalkulator.Text = (rezultat + Double.Parse(textBox_kalkulator.Text)).ToString();
                        break;
                    }
                case "-":
                    {
                        textBox_kalkulator.Text = (rezultat - Double.Parse(textBox_kalkulator.Text)).ToString();
                        break;
                    }
                case "*":
                    {
                        textBox_kalkulator.Text = (rezultat * Double.Parse(textBox_kalkulator.Text)).ToString();
                        break;
                    }
                case "/":
                    {
                        textBox_kalkulator.Text = (rezultat / Double.Parse(textBox_kalkulator.Text)).ToString();
                        break;
                    }
                case "z":
                    {
                        textBox_kalkulator.Text = (rezultat.ToString());
                        break;
                    }
                default:
                    break;
            }
            rezultat = Double.Parse(textBox_kalkulator.Text);
            
            
            
        }

        private void KliknięcieCofnięcia(object sender, EventArgs e)
        {
            textBox_kalkulator.Text = "0";
            rezultat = 0;
        }

        private void KliknięcieCofnięciaWidocznego(object sender, EventArgs e)
        {
            textBox_kalkulator.Text = "0";

            if (textBox_kalkulator.Text == "0") //przypadek z 0
            {
                textBox_kalkulator.Text = string.Empty;
            }

        }
        private void PobranieKursowWalutNBP(object sender, EventArgs e) //pobieranie kursow walut z nbp api
        {
            
            string url = "https://api.nbp.pl/api/exchangerates/tables/a/?format=xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(url);
            XmlNodeList currencyList = xml.GetElementsByTagName("Rate");
            double eurRate = 0;
            for (int i =0; i < currencyList.Count; i++)
            {
                string currencyName = currencyList[i].ChildNodes[0].InnerText;
                string code = currencyList[i].ChildNodes[1].InnerText;
                double exchangeRate = Convert.ToDouble(currencyList[i].ChildNodes[2].InnerText, CultureInfo.InvariantCulture);

                if (code == "EUR")
                {
                    eurRate = exchangeRate;
                    break;
                }
            }
            textBox_kurs.Text = eurRate.ToString();

            double usdRate = 0;
            for (int i = 0; i < currencyList.Count; i++)
            {
                string currencyName = currencyList[i].ChildNodes[0].InnerText;
                string code = currencyList[i].ChildNodes[1].InnerText;
                double exchangeRate = Convert.ToDouble(currencyList[i].ChildNodes[2].InnerText, CultureInfo.InvariantCulture);

                if (code == "USD")
                {
                    usdRate = exchangeRate;
                    break;
                }
            }
            textBox_kurs2.Text = usdRate.ToString();
        }
        
        private void button_pobierz_Click(object sender, EventArgs e)
        {
            textBox_zl.Text = (rezultat.ToString());
            textBox_zl2.Text = (rezultat.ToString());
        }

        private void button_euro_Click(object sender, EventArgs e)
        {
            double wynik = 0;
            wynik = Double.Parse(textBox_zl.Text);
            textBox_wynik1.Text = (wynik * Double.Parse(textBox_kurs.Text)).ToString();
        }

        private void button_dolar_Click(object sender, EventArgs e)
        {
            double wynik = 0;
            wynik = Double.Parse(textBox_zl2.Text);
            textBox_wynik2.Text = (wynik * Double.Parse(textBox_kurs2.Text)).ToString();
        }

        private void button_metry_Click(object sender, EventArgs e)
        {
            double km = 0.001;
            double mile = 0.00062;
            textBox_kilometry.Text = (km * Double.Parse(textBox_metry.Text)).ToString();
            textBox_mile.Text = (mile * Double.Parse(textBox_metry.Text)).ToString();
        }

        private void button_temperatura_Click(object sender, EventArgs e)
        {
            double fahren = 33.8;
            double kelvin = 274.15;
            textBox_fahren.Text = (fahren * Double.Parse(textBox_celcjusz.Text)).ToString();
            textBox_kelvin.Text = (kelvin * Double.Parse(textBox_celcjusz.Text)).ToString();
        }

        private void button_WyczyscDane_Click(object sender, EventArgs e)
        {
            //foreach (var textBox in Controls.OfType<TextBox>())
            //{
            // textBox.Clear();
            // }
            textBox_kilometry.Clear();
            textBox_metry.Clear();
            textBox_mile.Clear();

            textBox_celcjusz.Clear();
            textBox_fahren.Clear();
            textBox_kelvin.Clear();
            
            textBox_zl.Clear();
            textBox_zl2.Clear();
            textBox_wynik1.Clear();
            textBox_wynik2.Clear();
        }
    }
}
