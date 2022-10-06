using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameWorkDbFirst
{
    public partial class Centerscreen : Form
    {
        public Centerscreen()
        {
            InitializeComponent();
        }
        //Entity Frame Work
        /*
         * Entity Framework ORM(Object RelationL Mapping) araçlarından biridir. Veri tabanı CRUD işlemlerini Sql sorgusu yazmadan Ling dili ile hazır metotları kullanarak yapabilmemizi sağlar
         * Entity Framework ile 4 farklı yöntem kullanarak proje geliştirebiliriz
         * 
         * Model First(model oluşturup bu modele göre db oluşturarak)
         * Database first(Var olan veritabanını kullanma)
         * Code first(önce entity classlarını oluşturup sonra veritabanını oluşturarak)
         * code first(var olan veritabanını kullanarak entity classlarını  oluşturarak)
         * */

        //entity framework projelere dahili olarak ado.net gibi gelmez
        //sonradan projelere sağ tıklayıp açılan menüden nuget package manageri açıp  buradan browse menüsüne tıklayıp arama çubuğundan entityframework yazarak paketi bulup install diyerek açılan pencerede accept e basıp yüklememiz gerekir 

        UrunYonetimiAdonetEntities context= new UrunYonetimiAdonetEntities();//entity framework ile veritabanı crud işlemlerini yapabilmek için bu sınıftan bir nesne tanımlıyoruz
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource=context.Products.ToList(); //Ef ile contex nesensi üzerindeki products dbset ine ulaşıp veritabanındaki ürünleri listeledik 
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Products.Add(new Products
                {
                    StokMiktari = Convert.ToInt32 (txtStokMiktari.Text),
                    UrunAdi=txtUrunAdi.Text,
                    UrunFiyati=Convert.ToDecimal(txtUrunFiyati.Text)
                });//yukarıda dbset üzerine yeni bir ürün kaydı ekledik 
                   dgvUrunler.DataSource=context.Products.ToList();
                context.SaveChanges();//burada ise context üzerinde yapılan değişikilği veritabanına kaydettik.
                MessageBox.Show("kayıt başarılı");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu");
               
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var kayit = context.Products.Find(secilenKayitId);//entity framework find metodu kendisine parametreyle gönderilen id ile eşleşen kaydı veritabanından getirir.
            
            txtUrunAdi.Text = kayit.UrunAdi; 
            txtStokMiktari.Text=kayit.StokMiktari.ToString();
            txtUrunFiyati.Text=kayit.UrunFiyati.ToString();

            btnGuncelle.Enabled = true;
            btnsil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var kayit = context.Products.Find(secilenKayitId);

                kayit.UrunAdi = txtUrunAdi.Text;
                kayit.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                kayit.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("kayıt güncellendi");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata oluştu" +hata.Message);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
               Products kayit = context.Products.Find(secilenKayitId);
                context.Products.Remove(kayit);//context üzerindeki products tablosundan kayıt içindeki ürünü silinecek olarak işaretledik
                var sonuc = context.SaveChanges();//context üzerindeki değişiklikleri (yani burada silme işlemi anlamında )veri tabanına işle
                //entity frameworkde tracking ednilen bir kavram var ve bu trackiing ef context üzerindeki değişiklikleri izler, takip eder ,savechanges i çalıştırdığımızda db ye işler 


                if (sonuc > 0) //context .savechanges () metodu geriye veritabanında etkilenen kayıat sayısını bize int olarak döndürür sonuc değişkenine bu değer, int olark atadık ve if ile bu değer 0 dan büyük müdiye kontrol ettik eğer silme işilemi başaşrılı ise sonuc değeri 1 olacaktır başarısız olursa 0 olacaktır.
                {
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("kayıt silindi");
                }
                else MessageBox.Show("kayıt silinemedi");


            }
            catch (Exception hata)
            {

                MessageBox.Show("hata oluştu"+ hata.Message);
            }
        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
