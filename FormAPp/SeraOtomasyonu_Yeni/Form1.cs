using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeraOtomasyonu_Yeni
{
    public partial class logPanel : Form
    {

        int i;
        string line;
        string filePath = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Kullanicilar_kullanici.txt";
        string filePath2 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Kullanicilar_sifre.txt";
        string filePath3 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Veriables.txt";


        string[] kullaniciIsim = new string[20];
        string[] kullaniciSifre = new string[20];
        bool kullaniciDogruluk = false;
        bool sifreDogruluk = false;
        string veriable = "";

        public logPanel()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < kullaniciIsim.Length; i++)
            {
                if (textBox1.Text == kullaniciIsim[i])
                {
                    kullaniciDogruluk = true;
                }
                if (textBox2.Text == kullaniciSifre[i])
                {
                    sifreDogruluk = true;
                }

            }
            if (kullaniciDogruluk == true && sifreDogruluk == true)
            {
                if (veriable == "0")
                {
                    bitkiSecim cPP = new bitkiSecim();
                    cPP.Show();
                    this.Hide();
                }
                else if (veriable == "1")
                {
                    anaYonetimPaneli ayp = new anaYonetimPaneli();
                    ayp.Show();
                    this.Hide();
                }
                     
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void logPanel_Load(object sender, EventArgs e)
        {
            using (StreamReader reader01 = new StreamReader(filePath))
            {
                int i = 0;
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    kullaniciIsim[i] = line;
                    i++;

                }
            }
            i = 0;
            using (StreamReader reader02 = new StreamReader(filePath2))
            {
                while (true)
                {
                    line = reader02.ReadLine();
                    if (line == null) break;
                    kullaniciSifre[i] = line;
                    i++;
                }
            }
            using (StreamReader reader02 = new StreamReader(filePath3))
            {
                while (true)
                {
                    line = reader02.ReadLine();
                    if (line == null) break;
                    veriable = line;
                    
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox2.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            kulllaniciYonetimPaneli cPP = new kulllaniciYonetimPaneli();
            cPP.Show();
            this.Hide();
        }
    }
}
