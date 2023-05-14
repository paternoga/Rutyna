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
    public partial class muzyka : Form
    {
        public muzyka()
        {
            InitializeComponent();
        }

        String[] paths, files;
        private void button_pobierz_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; 
                paths = ofd.FileNames; 

                
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]); 
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {   
            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
        }
    }
}
