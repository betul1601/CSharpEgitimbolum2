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
            product product= new product(); //boş bir product nesnesi oluşturduk
            product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
            product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
            product.UrunAdi = txtUrunAdi.Text;


            var islemsonucu=productDAL.Add(product);// add mettoduna product eklemesi için gönderdik
            if (islemsonucu>0)
            {
                dgvUrunler.DataSource = productDAL.GetAllDataTable();//DATA GRİD VİEW DA EKLENEN SON KAYDI DA GÖREBİLMEK İÇİN 
                MessageBox.Show("kayıt başarılı");

            }
            else MessageBox.Show("kayıt başarısız");


        }
    }
}
