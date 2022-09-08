using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameWorkCodeFirst.Data;
using WindowsFormsAppEntityFrameWorkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameWorkCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DatabaseContext context= new DatabaseContext(); //Ef code first ü kullaanabilmek için DatabaseConntext sınıfımı<zdan bu şekilde bir nesne oluşturmalıyız
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource=context.urunler.ToList(); //context nesenmizin üzerindeki urunler isimli dbset üzerinden veritabanındaki kayıtları listeliyoruz
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                context.urunler.Add(
                    new urun
                    {
                       UrunAdi=txtUrunAdi.Text, 
                       UrunFiyati=Convert.ToDecimal(txtUrunFiyati.Text),
                       StokMiktari=Convert.ToInt32(txtStokMiktari.Text)
                       
                    }
                    );
                var sonuc =context.SaveChanges();
                if (sonuc>0)
                {
                    dgvUrunler.DataSource=context.urunler.ToList();
                    MessageBox.Show("kayıt başarılı");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("hata oluştu" +hata.Message);
            }
        }
    }
}
