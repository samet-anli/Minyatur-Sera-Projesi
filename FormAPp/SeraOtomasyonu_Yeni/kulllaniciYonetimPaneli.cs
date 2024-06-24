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
    public partial class kulllaniciYonetimPaneli : Form
    {

        bool dogruMu = true;
        string line;

        string filePath = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Kullanicilar_kullanici.txt";
        string filePath2 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Kullanicilar_sifre.txt";
        string filePath3 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\SilinenKullanicilar_kullanici.txt";
        string filePath4 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\SilinenKullanicilar_sifre.txt";


        public kulllaniciYonetimPaneli()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kulllaniciYonetimPaneli_Load(object sender, EventArgs e)
        {
            using (StreamReader reader01 = new StreamReader(filePath))
            {
                while (true)
                {
                    line = reader01.ReadLine();
                    if (line == null) break;

                    listBox1.Items.Add(line);
                }
            }
            using (StreamReader reader02 = new StreamReader(filePath2))
            {
                while (true)
                {
                    line = reader02.ReadLine();
                    if (line == null) break;

                    listBox3.Items.Add(line);
                }
            }
            using (StreamReader reader03 = new StreamReader(filePath3))
            {
                while (true)
                {
                    line = reader03.ReadLine();
                    if (line == null) break;

                    listBox2.Items.Add(line);
                }
            }
            using (StreamReader reader04 = new StreamReader(filePath4))
            {
                while (true)
                {
                    line = reader04.ReadLine();
                    if (line == null) break;

                    listBox4.Items.Add(line);
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            string x = "";


            if (textBox1.Text.Length < 4)
            {
                x += "\nkullanicı adınız 4 karakterden büyük olmalıdır.";
                //MessageBox.Show("kullanicı adınız 4 karakterden büyük olmalıdır.");
                dogruMu = false;
            }
            if (textBox2.Text.Length < 4)
            {
                x += "\nŞifreniz 4 karakterden büyük olamlıdır.";
                //MessageBox.Show("Şifreniz 4 karakterden büyük olamlıdır.");
                dogruMu = false;
            }
            if (textBox2.Text.Length != textBox3.Text.Length)
            {

                x += "\nŞifreniz aynı değil.";
                //MessageBox.Show("Şifreniz aynı değil.");
                dogruMu = false;
            }

            if (dogruMu == false) MessageBox.Show(x);

            if (dogruMu == true)
            {

                listBox1.Items.Add(textBox1.Text);
                listBox3.Items.Add(textBox2.Text);
                textBox2.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            int sec = listBox1.SelectedIndex;
            listBox2.Items.Add(listBox1.Items[sec]);
            listBox1.Items.RemoveAt(sec);


            listBox4.Items.Add(listBox3.Items[sec]);
            listBox3.Items.RemoveAt(sec);

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            using (StreamWriter write01 = new StreamWriter(filePath)) // kullanici ad
            {
                foreach (var item in listBox1.Items)
                {
                    write01.WriteLine(item);
                }

            }
            using (StreamWriter write02 = new StreamWriter(filePath2)) // kullanici sifre
            {
                foreach (var item in listBox3.Items)
                {
                    write02.WriteLine(item);
                }
            }
            using (StreamWriter write03 = new StreamWriter(filePath3)) //  silinen kullanici
            {
                foreach (var item in listBox2.Items)
                {
                    write03.WriteLine(item);
                }

            }
            using (StreamWriter write04 = new StreamWriter(filePath4)) // silinen kullanici sifre
            {
                foreach (var item in listBox4.Items)
                {
                    write04.WriteLine(item);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            logPanel lP1 = new logPanel();
            lP1.Show();  // form2 göster diyoruz
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

            // kullanciyi Geri Al.
            int sec = listBox2.SelectedIndex;
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.RemoveAt(sec);


            listBox3.Items.Add(listBox4.Items[sec]);
            listBox4.Items.RemoveAt(sec);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox4.Items.Clear();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kulllaniciYonetimPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
