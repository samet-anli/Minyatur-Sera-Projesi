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
    public partial class bitkiEkim : Form
    {
        string filePath = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\Veriables.txt";
        string filePath1 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\bitki.txt";
        string filePath2 = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\baslama.txt";

        string bitkiSecim = "";
        string line = "";
        DateTime tarih = DateTime.Now;
        public bitkiEkim()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            bitkiSecim bs = new bitkiSecim();
            bs.Show();
            this.Hide();
        }

        private void bitkiEkim_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bitkiEkim_Load(object sender, EventArgs e)
        {
            using (StreamReader reader01 = new StreamReader(filePath1))
            {
                int i = 0;
                while (true)
                {

                    line = reader01.ReadLine();
                    if (line == null) break;
                    bitkiSecim = line;
                }
            }
            if (bitkiSecim == "gul")
            {
                textBox1.Text = "\r\nGül nasıl Ekilir ? \r\nSaksıda gül yetiştirmek için gerekli olacak malzemeler:\r\n\r\nGeniş toprak saksı\r\nSu spreyi\r\nBudanmış köklü gül fidesi\r\nHumuslu toprak\r\nGül fidesini yeni bir saksıda büyütmek için izlemeniz gereken adımlar:\r\n\r\nEvinizi renklendirmek için gül yetiştirmek istediğinizde, öncelikle budanmış ve çiçeklerinden arınmış taze bir gül fidesi bulmasınız.\r\nÖncelikle temin edilen saksının içini temizleyin. Eğer çöp ya da herhangi bir artık varsa yok edin.\r\nŞimdi mineralli ve humuslu bitki toprağını saksının tabanına dökün. Bu aşamada toprağı sıkıştırmayın. Gevşek kalmalıdır.\r\nSpreyle toprağa su sıkın ve budanmış gül fidesini toprağın tam ortasına dikin.\r\nTaze fidenin toprakta dik durması için kök kısmına spreyle su sıkıp sabitleyin.\r\nFidenin çevresini bir miktar toprakla kapatın ve yeniden su püskürtün.\r\nSaksıda gül fidesini yetiştirmenin ilk adımını attınız.\r\nŞimdi saksıyı Seranın içine koyabilrsiniz.";
            }
            else if (bitkiSecim == "marul")
            {
                textBox1.Text = "\r\n\rMarul Tohumu Nasıl Ekilir?\r\n\r\nMarul tohumu ekimi için önce toprağın havalandırılması ve gübrelenmesi işlemi sonrasında ekim yapılacak yerin ıslatılarak toprağın tohum öncesi nemlenmesi sağlanmalıdır.\r\nEkim işleminde toprağa tohumlar dökülür.\r\nTohum üstüne çok az toprak koyulur ve üzerine su takviyesi yapılır.\r\nMarul enine ve boyuna gelişim gösterir. Sera içinde yetiştirme işleminde de tohumdan ekime yer açılarak seyreltme ve sulamaya da dikkat edilmesi önemlidir.\r\nBunun yanı sıra serada bakımda özellikle kış ayları için ekstra gübreleme işlemine yer verilerek gelişimin daha sağlıklı ve bitkinin daha lezzetli olması da sağlanabilir.\r\nMarul ekimi yapacağınız zaman tohumları açık arazide çimlendirecekseniz eğer toprağı işleyiniz. İşlenmiş toprağa marul tohumlarını yerleştiriniz ve üstünü ince elenmiş toprakla 1 cm arasında kapatınız.\r\n\rAyrıca verimli ve lezzetli marul elde etmek için seyrek ekim ve sulamanın da düzgün olması önemlidir.";
            }
            else if (bitkiSecim == "cilek")
            {
                textBox1.Text = "\r\n\rÇilek yetiştirmek için, ilk yapmanız gereken doğal fide veya tohum bulmaktır. Bunun için güvenilir çiçekçilerden ya da tarımla uğraşan kişilerden çilek fidesi alabilirsiniz. Ayrıca saksıda yetiştirilebilen çilek çeşitlerini öğrenmeniz gerekiyor. Çünkü her çilek saksıda yetiştirmek için uygun değildir. Saksıda yetiştirmeye elverişli olan çeşitler Osmanlı, yediveren ve dağ çileğidir. Yani tohumu alırken hangi çilek çeşidini seçtiğinize dikkat edin.\r\n\rSaksı Seçimi: Çilek yetiştirirken dikkat edilecek noktalardan biri de saksı seçimidir. Çilek yetiştirmek için uygun saksı derinliği 20-25 santimetredir. Bu yüzden genellikle uzun ve sar saksılar tercih ediliyor. Ancak dilerseniz yuvarlak saksıları da kullanabilirsiniz.\r\n\rToprak Seçimi: Çilek yetiştirmek için, organik maddeler bakımından zengin toprak seçilmelidir. Bir diğer adıyla 'torflu toprak'. İlk ekim işlemi için mutlaka torflu toprak kullanın. Bitki meyve vermeye başladıktan sonra toprağı gübreyle zenginleştirin. Bu sayede daha verimli çilekler yetiştirebilirsiniz.\r\n\rÇilek yetiştirmek için fideler genellikle Mart-Eylül ayları arasında ekilir. Ancak fidelerin kökleri saksılıysa ve uygun koşullar sağlandığıysa dört mevsim ekim işlemi yapılabilir. Çilek fidesini ekmek için öncelikle saksıyı torflu toprakla doldurun. Fideleri köklerine zarar vermeden toprağa yerleştirin. Kenarlarından hafifçe toprakla örtün ve ilk sulama işlemini yapın. Saksının büyüklüğüne göre 1 adet saksıya 1-3 arası çilek fidesi ekebilirsiniz.\r\n\rSaksıyıda seraya yerleştirebilirsiniz.  ";
            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            using (StreamWriter write01 = new StreamWriter(filePath))
            {
                write01.WriteLine("1");

            }
            anaYonetimPaneli cP = new anaYonetimPaneli();
            cP.Show();
            this.Hide();
            using (StreamWriter write01 = new StreamWriter(filePath2))
            {
                
                write01.WriteLine(tarih.ToString());

            }
            
        }
    }
}
