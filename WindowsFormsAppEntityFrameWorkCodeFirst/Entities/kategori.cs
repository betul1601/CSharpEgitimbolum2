using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameWorkCodeFirst.Entities
{
    [Table("Kategoriler")] // bu attribute entity framework ün veritabanı tablosunu categories ismi yerine kategoriler ollarak oluşturmayı sağlar
  public class Kategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool UrunDurum { get; set; }
    }
}
