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
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        UrunYonetimiAdonetEntities context = new UrunYonetimiAdonetEntities();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {

            dgvKategoriler.DataSource = context.kategoriler.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtkategoriAdi.Text))
            {
                MessageBox.Show("kategori adı boş geçilemez");
                return;
            }
            try
            {
                context.kategoriler.Add(
                    new kategoriler
                    {
                        KategoriAdi = txtkategoriAdi.Text,
                        Durum = cbDurum.Checked
                    }
                    );
                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.kategoriler.ToList();
                    MessageBox.Show("kayıt başarılı");
                }



            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu");
            }
        }
        private void dgvKategoriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
            var kayit = context.kategoriler.Find(secilenKayitId);
            txtkategoriAdi.Text = kayit.KategoriAdi;
            cbDurum.Checked = (bool)kayit.Durum;

            btnguncelle.Enabled = true;
            btnsil.Enabled = true;

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                var kayit = context.kategoriler.Find(secilenKayitId);

                kayit.KategoriAdi = Convert.ToString(txtkategoriAdi.Text);
                kayit.Durum = cbDurum.Checked;


                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Products.ToList();
                    MessageBox.Show("kayıt güncellendi");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata oluştu" + hata.Message);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                kategoriler kayit = context.kategoriler.Find(secilenKayitId);
                context.kategoriler.Remove(kayit);
                var sonuc = context.SaveChanges();


                if (sonuc > 0)

                {
                    dgvKategoriler.DataSource = context.Products.ToList();
                    MessageBox.Show("kayıt silindi");
                }
                else MessageBox.Show("kayıt silinemedi");

            }
            catch (Exception hata)
            {

                MessageBox.Show("hata oluştu" + hata.Message);
            }
        }
    }
    
}
