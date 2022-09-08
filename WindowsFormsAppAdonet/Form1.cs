using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdonet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDAL productDAL = new ProductDAL();   //veri  tabanı işlemlerinin olduğu sınıfı tanımladık

        private void Form1_Load(object sender, EventArgs e)
        {
           // dgvUrunler.DataSource = productDAL.GetAll();//form ön yüzdeki dgvurunler nesnesine productdal içindeki getall metoduyla ürünleri yükledik

            dgvUrunler.DataSource = productDAL.GetAllDataTable();
        }

        private void btnekle_Click(object sender, EventArgs e)
       
        
        {
            try
            {
                product product = new product(); //boş bir product nesnesi oluşturduk
                product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
                product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                product.UrunAdi = txtUrunAdi.Text;
                var islemsonucu = productDAL.Add(product);// add mettoduna product eklemesi için gönderdik
                if (islemsonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable();//DATA GRİD VİEW DA EKLENEN SON KAYDI DA GÖREBİLMEK İÇİN 
                    MessageBox.Show("kayıt başarılı");

                }
                else MessageBox.Show("kayıt başarısız");

            }
            catch(Exception hata)
            {
                // MessageBox.Show("hata oluştu!\n eçersiz değer girdiniz!");
                MessageBox.Show(hata.Message);
            }

        }

        private void dgvUrunler_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            /*
            txtStokMiktari.Text = dgvUrunler.CurrentRow.Cells[3].Value.ToString();
            txtUrunAdi.Text = dgvUrunler.CurrentRow.Cells[1].Value.ToString();
            txtUrunFiyati.Text = dgvUrunler.CurrentRow.Cells[2].Value.ToString();
            */
            string id = dgvUrunler.CurrentRow.Cells[0].Value.ToString();
            product product=productDAL.GetProduct(id);
            txtStokMiktari.Text = product.StokMiktari.ToString();
            txtUrunFiyati.Text = product.UrunFiyati.ToString();
            txtUrunAdi.Text = product.UrunAdi.ToString();
            btnGuncelle.Enabled = true;//listeden kayıt seçildiğinde güncelle butonunu aktif et
            btnsil.Enabled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                
                product product = new product(); //boş bir product nesnesi oluşturduk
                product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
                product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                product.UrunAdi = txtUrunAdi.Text;
                product.Id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);  

                var islemsonucu = productDAL.Update(product);// add mettoduna product eklemesi için gönderdik
                if (islemsonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable();//DATA GRİD VİEW DA EKLENEN SON KAYDI DA GÖREBİLMEK İÇİN 
                    MessageBox.Show("kayıt başarılı");

                }
                else MessageBox.Show("kayıt başarısız");

            }
            catch (Exception hata)
            {
                // MessageBox.Show("hata oluştu!\n eçersiz değer girdiniz!");
                MessageBox.Show(hata.Message);
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                var islemsonucu = productDAL.Delete(dgvUrunler.CurrentRow.Cells[0].Value.ToString());
                if (islemsonucu > 0)
                {
                    dgvUrunler.DataSource = productDAL.GetAllDataTable();
                    MessageBox.Show("silme başarılı");

                }
                else MessageBox.Show("silme başarısız");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        //ekleme işleminden sonraki işlemlerimiz gridview dan kayıt seçip seçilen kaydın bilgilerini textboxlara doldurmak Bunun için gridview ın events(olaylar) kısmında cell click olayını etkinleştirmemiz lazım gride sağ tık yapıp properties e tıklayıp açılan pencereden şimşek ikonuna tıklayıp oradan secc clickkutucuğuna mouse ile çift tıklayarak bu olayı aktifleştirebiliyoruz.

    }
}
