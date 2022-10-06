using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameWorkCodeFirst.Entities
{
    [Table("Markalar")] //veritabanında adı markalar olsun istiyoruz
    public class Marka //projemizdeki entities klasörüne sağ tıklayıp add class ile bu classı ekledikten sonra property tanımlıyoruz
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        //property leri tanımladıktan sonra bu sınıfın veritabanı işlemlerini yapabilmek için databasecontext classına marka classını dbset olarak eklememiz gerekir
    }
}
