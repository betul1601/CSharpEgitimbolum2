using System.Data.Entity;
using WindowsFormsAppEntityFrameWorkCodeFirst.Entities;


namespace WindowsFormsAppEntityFrameWorkCodeFirst.Data
{
    internal class DatabaseContext :DbContext //oluşturduğumuz databese sınıfına entity frameworkün DbContext sınıfından miras alıyoruz

    {
        //burada veritabanı tablolarını temsil edecek olan Dbset nesnelerimizi yazıyoruz

        public DbSet <Urun> urunler { get; set; } //entities klasörümüzdeki sınıflarımız için
        public DbSet<Kategori> kategoriler { get; set; }   // bu şekilde dbsetler tanımlamamız gerekli

        //Dbset lerimizi yazdıktan sonra proje içerisindeki App.config isimli dosyaya entity framework ün kullanacağı veritabanını tanımlayan bir connectiion string kodu yazmamız gerekiyor
        public DbSet<Marka> Markalar { get; set; }// bu dbset i eklemezsek veritabanı işlemleri yapamayız
        //bu aşamadan sonra projeye add new form diyerek markayönetim formu 
    }
}
