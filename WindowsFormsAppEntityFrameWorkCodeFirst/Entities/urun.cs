using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameWorkCodeFirst.Entities
{
    [Table("Urunler")] //veritabanı tablosunun ismi urunler olsun uruns olmasın
    public class urun
    {
        public int Id { get; set; }
        public decimal UrunFiyati { get; set; }
        public string UrunAdi { get; set; }
        public int StokMiktari { get; set; }

    }
}
