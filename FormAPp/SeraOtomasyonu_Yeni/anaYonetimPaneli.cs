using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SeraOtomasyonu_Yeni
{
    public partial class anaYonetimPaneli : Form
    {
        string filePath  = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\bitki.txt";
        string filePath1 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\durum1.txt";
        string filePath2 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\durum2.txt";
        string filePath3 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\durum3.txt";
        string filePath4 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\baslama.txt";
        string filePath5 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Veriables.txt";


        string cimlendiMi = "";
        string ciceklendiMi = "";
        string meyvelendiMi = "";

        string bitkiSecim = "";
        string line = "";
        string tarih = "";
        int i = 0;

        public anaYonetimPaneli()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.Write("w"); // Aç
                veriAcikKapali.BackColor = Color.Green;
                timer1.Start();
                
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void anaYonetimPaneli_Load(object sender, EventArgs e)
        {
            using (StreamReader reader01 = new StreamReader(filePath1))
            {
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    cimlendiMi = line;
                }
            }
            using (StreamReader reader01 = new StreamReader(filePath2))
            {
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    ciceklendiMi = line;
                }
            }
            using (StreamReader reader01 = new StreamReader(filePath3))
            {
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    meyvelendiMi = line;
                }
            }
            using (StreamReader reader01 = new StreamReader(filePath))
            {
                int i = 0;
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    bitkiSecim = line;
                }
            }
            using (StreamReader reader01 = new StreamReader(filePath4))
            {
                int i = 0;
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    tarih = line;
                }
            }

            if (bitkiSecim == "marul")  label14.Text = "Bitki : Marul";
            if (bitkiSecim == "gul")    label14.Text = "Bitki : Gül";
            if (bitkiSecim == "cilek")  label14.Text = "Bitki : Çilek";

            // Yetiştirmeye Başlanan tarih : 0000

            label33.Text = "Yetiştirmeye Başlanan tarih : " + tarih;

            if (cimlendiMi == "0") label9.Text = "Hayır"; else label9.Text = "Evet";
            if (ciceklendiMi == "0") label10.Text = "Hayır"; else label10.Text = "Evet";
            if (meyvelendiMi == "0") label11.Text = "Hayır"; else label11.Text = "Evet";

            // 
            // ComPort
            foreach (var seriPort in SerialPort.GetPortNames())
            {
                comboBoxPorts.Items.Add(seriPort);
            }
            comboBoxPorts.SelectedIndex = 0;
            buttonDisconnect.Enabled = false;
            //buttonSend.Enabled = false;
            // Seri Kapalı
            seriAcilKapali.BackColor = Color.Red;
            veriAcikKapali.BackColor = Color.Red;

        }
        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
            // button serial off
            if(serialPort1.IsOpen)
            {
                serialPort1.Write("x"); // kapa

                serialPort1.Close();
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                //buttonSend.Enabled = false;
                seriAcilKapali.BackColor = Color.Red;
                veriAcikKapali.BackColor = Color.Red;
            }
        }
        // Verilern alınması
        public delegate void veriGoster(string s);

        public void textBoxYaz(string s)
        {
            gelenBox.Text += s;
        }
        
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            string gelenVeri = serialPort1.ReadExisting();

            
            gelenBox.Invoke(new veriGoster(textBoxYaz), gelenVeri);

            
        }

        private void label34_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxPorts.Text;
            // SerialPortun konuştuğu dil ayarları
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.StopBits = StopBits.One; // bir tana stop bit olsun
            serialPort1.DataBits = 8;

            // try catch'in amacı: olmayan porta bağlanmaya çalışırsa!
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri Port Bağlantısı Yapılamadı\nHata : {ex.Message}", "Problem,", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (serialPort1.IsOpen)
            {
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                //buttonSend.Enabled = true;
            }

            if (serialPort1.IsOpen)
            {
                if (bitkiSecim == "marul") serialPort1.Write("m");
                else if (bitkiSecim == "gul") serialPort1.Write("g");
                else if (bitkiSecim == "cilek") serialPort1.Write("c");
                else if (bitkiSecim == "yok") serialPort1.Write("s");

                seriAcilKapali.BackColor = Color.Green;
            }

        }

        private void label25_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (bitkiEvetBox.Text == "EVET")
                {
                    bitkiSecim = "yok";

                    serialPort1.Write("s"); // pic i sıfırlar
                    serialPort1.Close();

                    using (StreamWriter write01 = new StreamWriter(filePath))
                    {
                        write01.WriteLine("yok");

                    }
                    using (StreamWriter write01 = new StreamWriter(filePath1))
                    {
                        write01.WriteLine("0");

                    }
                    using (StreamWriter write01 = new StreamWriter(filePath2))
                    {
                        write01.WriteLine("0");

                    }
                    using (StreamWriter write01 = new StreamWriter(filePath3))
                    {
                        write01.WriteLine("0");

                    }
                    using (StreamWriter write01 = new StreamWriter(filePath5))
                    {
                        write01.WriteLine("0");

                    }


                    bitkiSecim bSP = new bitkiSecim();
                    bSP.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Kutucuğa EVET yazmalısınız.");
                }
            }
            else { MessageBox.Show("Seri Porta Bağlanmalısın."); }
        }

        private void durum1Label_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                using (StreamWriter write01 = new StreamWriter(filePath1))
                {
                    if (durum1TextBox.Text == "0" || durum1TextBox.Text == "1")
                        write01.WriteLine(durum1TextBox.Text);

                }

                serialPort1.Write("t"); // durum1 == 0  yapar

                if (durum1TextBox.Text == "0")
                {
                    if (label10.Text == "Hayır")
                    {
                        label9.Text = "Hayır";
                        serialPort1.Write("t"); // durum1 == 0  yapar
                    }
                }
                else
                {

                    label9.Text = "Evet";
                    serialPort1.Write("y"); // durum1 == 1  yapar
                }
            }
            else { MessageBox.Show("Seri Port Kapalı"); }
        }

        private void durum2Label_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                using (StreamWriter write01 = new StreamWriter(filePath2))
                {

                    if (durum2TextBox.Text == "0" || durum2TextBox.Text == "1")
                        write01.WriteLine(durum2TextBox.Text);

                }
                if (durum2TextBox.Text == "0")
                {
                    if (label11.Text == "Hayır")
                    {
                        label10.Text = "Hayır";
                        serialPort1.Write("u"); 
                    }
                }
                else
                {
                    if (label9.Text == "Evet")
                    {
                        label10.Text = "Evet";
                        serialPort1.Write("i");
                    }
                }
            }
            else { MessageBox.Show("Seri Port Kapalı"); }
            
        }

        private void durum3Label_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                using (StreamWriter write01 = new StreamWriter(filePath3))
                {
                    if (durum3TextBox.Text == "0" || durum3TextBox.Text == "1")
                        write01.WriteLine(durum3TextBox.Text);

                }
                if (durum3TextBox.Text == "0")
                {
                    label11.Text = "Hayır";
                    serialPort1.Write("b");
                }
                else
                {
                    if (label10.Text == "Evet")
                    {
                        label11.Text = "Evet";
                        serialPort1.Write("n");
                    }

                }
            }
            else { MessageBox.Show("Seri Port Kapalı"); }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("x"); // kapa
                veriAcikKapali.BackColor = Color.Red;
                gelenBox.Clear();
                timer1.Stop();
            }
            else { MessageBox.Show("Seri Port Kapalı"); }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void anaYonetimPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if(i == 25)
            {
                i = 0;
                gelenBox.Clear();
            }
                
        }
    }
}
