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

        }
        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnekle_Click_1(object sender, EventArgs e)
        {

        }
    }
}
