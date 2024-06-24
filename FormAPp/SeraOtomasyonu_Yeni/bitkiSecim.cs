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
    public partial class bitkiSecim : Form
    {
        string filePath = @"C:\Users\Samet\OneDrive\Masaüstü\Sera\SeraOtomasyonu_Yeni\Users\bitki.txt";

        string bitkiSecim1 = "";
        public bitkiSecim()
        {
            InitializeComponent();
        }

        private void bitkiSecim_Load(object sender, EventArgs e)
        {
            bitkiSecim1 = "gul";
            textBox1.Text = "\r\n\r\nGül\r\n\r\nİç ve dış mekanları güzelleştirmek, daha yaşanabilir bir konuma getirmek için gül yetiştirebilirsiniz. Gül, bulunduğu ortamları renklendirir ve oksijen üretimini artırır. Eğer bitki yetiştirmeye karşı ilginiz varsa; siz de bu sayfada anlatılanlardan yola çıkarak bahçe içinde ya da saksıda gül yetiştirmek isteyebilirsiniz.\r\n\r\nDilediğiniz saksıda gül çeşitleri temin ederek, evde renk renk büyüyen bir gül bahçesini oluşturabilirsiniz. Gül bahçenizin en iyi şekilde canlı kalması için bu satırlardaki bilgileri öğrenebilirsiniz.\r\n\r\nEvlerinizde bir renk cümbüşü yaşamak için saksıda gül bakımı bilgilerinize çok ihtiyacınız olacak";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gulbox_Click(object sender, EventArgs e)
        {
            gulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\gül_black.png");
            marulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\marul_white.png");
            cilekBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\cilek_white.png");
            bitkiSecim1 = "gul";
            textBox1.Text = "\r\n\r\nGül\r\n\r\nİç ve dış mekanları güzelleştirmek, daha yaşanabilir bir konuma getirmek için gül yetiştirebilirsiniz. Gül, bulunduğu ortamları renklendirir ve oksijen üretimini artırır. Eğer bitki yetiştirmeye karşı ilginiz varsa; siz de bu sayfada anlatılanlardan yola çıkarak bahçe içinde ya da saksıda gül yetiştirmek isteyebilirsiniz.\r\n\r\nDilediğiniz saksıda gül çeşitleri temin ederek, evde renk renk büyüyen bir gül bahçesini oluşturabilirsiniz. Gül bahçenizin en iyi şekilde canlı kalması için bu satırlardaki bilgileri öğrenebilirsiniz.\r\n\r\nEvlerinizde bir renk cümbüşü yaşamak için saksıda gül bakımı bilgilerinize çok ihtiyacınız olacak";
        }

        private void marulBox_Click(object sender, EventArgs e)
        {
            marulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\marul_black.png");
            gulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\gül_white.png");
            cilekBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\cilek_white.png");
            bitkiSecim1 = "marul";
            textBox1.Text = "\r\n\r\nMarul\r\n\r\nSalataların vazgeçilmezlerinden biri sayılan, lezzetli ve çıtır çıtır oluşuyla her damak zevkine hitap eden marul, bitki yetiştiriciliği ile uğraşan kişilerin de gözdesidir. Özellikle de küçük, sarkık biçimli yapraklara ve iştah kabartan, hafif bir tada sahip olan marul türlerinin, gün geçtikçe daha fazla insanın ilgisini çekiyor olmasına şaşmamak gerekir! Birbirinden cazip çok sayıda türü olan bu şahane bitkinin sıcak havalara dayanıklı oluşu da onu bahçede yetiştirmek için harika bir seçenek haline getirir.";
        }

        private void cilekBox_Click(object sender, EventArgs e)
        {
            marulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\marul_white.png");
            gulBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\gül_white.png");
            cilekBox.Load(@"C:\\Users\\Samet\\OneDrive\\Masaüstü\\Sera\\Tasarım\\SetUpPages\cilek_black.png");
            bitkiSecim1 = "cilek";
            textBox1.Text = "Çilekler tezgahlardaki yerini aldı, fiyatı da bir nebze de olsa uygun hale geldi.\r\n\r\nAncak ne yazık ki o iri iri çilekleri yerken içinizi kemiren bir şüphe hep oldu, biliyoruz. \"Acaba şu an gerçekte ne yiyorum\" diye düşünmeden edemediniz. Çocukluğunuzdaki gibi tarlalardan toplanıp gelmiş minik ama lezzetli çiçekleri yerken yaşadığınız mutluluğu bir türlü yakalayamadınız, tahmin edebiliyoruz.\r\n\r\n\"Bu çilek nasıl olur da bu kadar büyük olur\" dediniz, \"bu şekerli tat nereden geliyor böyle\" diye düşünüp durdunuz belki. Haklısınız da.\r\n\r\nÇeşitli kimyasallarla, hormonlarla dev gibi bir hale gelen, organik diye alsanız da hep bir kuşku duyduğunuz o çilekler yerine evinizde, saksı içinde kendi çileğinizi kendiniz yapmaya ne dersiniz?\r\n\r\nBiliyoruz, el değmemiş, kimyasal bulaşmamış tohum ya da fide bulmak da bir hayli zor ama sağlığınız için en azından nasıl yetiştirildiğini bildiğiniz, ellerinizle büyüttüğünüz minik ve lezzetli çilekler yemek elinizde.\r\n\r\nKendi çileğini kendi yetiştiren birinden en doğalından fideler de buldunuz mu, değmeyin keyfinize. ";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            using (StreamWriter write01 = new StreamWriter(filePath))
            {
                write01.WriteLine(bitkiSecim1);

            }
            if (bitkiSecim1 == "cilek" || bitkiSecim1 == "gul" || bitkiSecim1 == "marul")
            {
                bitkiEkim bEP = new bitkiEkim();
                bEP.Show();  // form2 göster diyoruz
                this.Hide();
            }
        }

        private void bitkiSecim_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
