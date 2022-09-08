using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdonet
{
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }
        KategoriDal kategoriDal = new KategoriDal();
        private SqlConnection connection;

        public object Connection { get; private set; }
        public object KategoriDAL { get; private set; }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvKategoriler.CurrentRow.Cells[0].Value.ToString();
            var kategori = kategoriDal.Get(id);//kategori dal içine yazdığımız get metoduna seçili satırdan aldığımız id değerini yolladık o da bize bu id ye ait kategori bilgileriin veritabanından çekip getirecek
            txtkategoriAdi.Text = kategori.KategoriAdi;//ön yüzdeki  txtkategoriadi adli textboxda veritabanından gelen  aktegorinin kategori adi bilgisini yükledik
            cbDurum.Checked=kategori.Durum; // aynı şekilde ön yüzdeki cbdurum isimli checkbox ın değerini 

            btnguncelle.Enabled = true;//satır seçildiğinde güncelle butonunu aktif et
            btnsil.Enabled = true;  
        }

        private void kategoriler_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = kategoriDal.GetAllDataTable();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                int sonuc = kategoriDal.Add(new kategori { KategoriAdi=txtkategoriAdi.Text,Durum=cbDurum.Checked});
                if (sonuc>0)
                {
                    MessageBox.Show("kayıt başarılı");
                    dgvKategoriler.DataSource = kategoriDal.GetAllDataTable();
                }
                else
                    MessageBox.Show("kayıt başarısız");
            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu");
            }

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int sonuc = kategoriDal.Update (new kategori { KategoriAdi = txtkategoriAdi.Text, 
                    Durum = cbDurum.Checked, 
                    Id = (int)dgvKategoriler.CurrentRow.Cells[0].Value });
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = kategoriDal.GetAllDataTable();
                    MessageBox.Show("kayıt başarılı");
                   
                }
                else
                    MessageBox.Show("kayıt başarısız");
            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu");
            }


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                var islemsonucu = kategoriDal.Delete(dgvKategoriler.CurrentRow.Cells[0].Value.ToString());
                if (islemsonucu > 0)
                {
                    dgvKategoriler.DataSource = kategoriDal.GetAllDataTable();
                    MessageBox.Show("silme başarılı");

                }
                else MessageBox.Show("silme başarısız");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

      

        private void ConnectionKontrol()
        {
            throw new NotImplementedException();
        }
    }
}
