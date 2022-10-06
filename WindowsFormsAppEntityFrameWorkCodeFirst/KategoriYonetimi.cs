using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppAdonet;
using WindowsFormsAppEntityFrameWorkCodeFirst.Data;
using WindowsFormsAppEntityFrameWorkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameWorkCodeFirst
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }

        DatabaseContext context = new DatabaseContext();
        

        private void KategoriYonetimi_Load_1(object sender, EventArgs e)
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
                Kategori kategori  = new Kategori()
                {
                    Adi = txtkategoriAdi.Text,
                    UrunDurum = cbDurum.Checked
                };
                context.kategoriler.Add(kategori);
                context.SaveChanges();
                dgvKategoriler.DataSource = context.kategoriler.ToList();

                MessageBox.Show("kayıt başarılı");
          

            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtkategoriAdi.Text = dgvKategoriler.CurrentRow.Cells[1].Value.ToString();
                cbDurum.Checked =Convert.ToBoolean(dgvKategoriler.CurrentRow.Cells[2].Value);
                btnguncelle.Enabled = true;
                btnsil.Enabled = true;

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
                int id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                Kategori kategori = context.kategoriler.FirstOrDefault(k=> k.Id== id); //firstorgefultmetodu kendisine gönderilen soruya ait  kaydı veritabanından bulur
                kategori.Adi = txtkategoriAdi.Text;
                kategori.UrunDurum=cbDurum.Checked;
                context.SaveChanges();
                dgvKategoriler.DataSource = context.kategoriler.ToList();
                MessageBox.Show("kayıt başarılı");

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
                int id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);
                Kategori kategori = context.kategoriler.SingleOrDefault(k => k.Id == id);
                //singleordefault metodu veritabanındaki bir kaydı getirmek için kullanılır eğer şarta uyan 1 den fazla kayıt bulunursa  hata verir
                context.kategoriler.Remove(kategori);
                var islemsonuc = context.SaveChanges();
                if (islemsonuc>0)
                {
                    dgvKategoriler.DataSource=context.kategoriler.ToList();
                    MessageBox.Show("kayıt sildi");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu");
            }
           
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.kategoriler.Where(k => k.Adi.Contains(txtara.Text)).ToList();

        }
    }
}
