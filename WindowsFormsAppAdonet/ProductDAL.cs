using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;//VERİ TABANI İŞLEMLERİ İÇİN GEREKLİ
using System.Data.SqlClient;//ADONET KÜTÜPHANELERİ

namespace WindowsFormsAppAdonet
{
    internal class ProductDAL
    {
        SqlConnection connection= new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database=UrunYonetimiAdonet;integrated security=true"); //Sqlconnection veri tabanına bağlanmak için kullandığımız adonet sınıfıdır .parametre olarak kendisine verrilen bilgilerdeki veritabanına bağlanır

        void ConnectionKontrol() //void = tek
        {
            if (connection.State == ConnectionState.Closed) //eğer yukarıda tanımladığımız veritabanı bağlantısı kapalıysa 
            {
                connection.Open();//bağlantıyı aç
            }
           
           
        }
        public List<product> GetAll() //bu metodun geri dönüş değeri list<product> yaani ürün listesidir.
        {
            ConnectionKontrol();    //metot çalıştığı anda bağlantıyı kontrol et
            List<product> UrunListesi = new List<product>();//geriye döndüreceğimiz List<product> nesnesi oluşturduk
            SqlCommand command = new SqlCommand("select *from Products",connection); //Sqlcommand sql komutlarını çekebileceğimiz adonet sınıfıdır.tırnaklar içerisine sql komutumuzu ,sonraki parametrede de bu komutun çalıştırılacağı connection nesnesini belirtiyoruz

            SqlDataReader reader = command.ExecuteReader();// Sqldatareader sql veri okuyucu sınıfıdır bu sınıfa üstteki command nesnesini executereader metoduyla çalıştırmasını söyledik

            while (reader.Read()) //reader db de okuyacak kayıt bulduğu süreece 
            {
                product product = new product() //döngü her döndüğünde  içi boş yeni bir ürün oluşturuyoruz 

                {
                    //aşağıda veritabanından gelen verilerle ürün bilgilerini dolduruyoruz 
                    Id = Convert.ToInt32(reader["Id"]),

                    UrunAdi = reader["UrunAdi"].ToString(), 
                    StokMiktari=Convert.ToInt32(reader["StokMiktari"]),

                    UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])

                };

                UrunListesi.Add(product); //içi doldurulan product nesnesini yukarıda oluşturduğumuz products listesine ekliyoruz
            }
             reader.Close();//vweri okuyucuyı kapa
            command.Dispose();//
            connection.Close(); 
            return UrunListesi;
        }

        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); //bağlantıyı kontrol et
            DataTable dt = new DataTable();//boş bir datatable nesnesi oluştur
            SqlCommand command = new SqlCommand("select*from Products",connection);
            SqlDataReader reader=command.ExecuteReader();   
            dt.Load(reader);    //dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close();//veri okuyucuyu kapat
            command.Dispose();//sql komut nesensini kapat
            connection.Close();//veri tabanı bağlantısıın kapat
            return dt;// metodun çağıırldığı yere gönder

        }

        public int Add(product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Products (UrunAdi,UrunFiyati,StokMiktari) values (@UrunAdi,@UrunFiyati,@Stok)", connection);  //sql komutu olarak bu sefer insert komutu yaazdık
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari);
            int islemSonucu=command.ExecuteNonQuery();//executenonquery metodu geriye veritabanında etkilenen kayıt sayısını döner  
            command.Dispose();//sql komut nesnesini kapa
            connection.Close();//veritabanı nesnesini kapa
            return islemSonucu; // metodumuz geriye int döndüğü için işlem sonucu değişkenini geri dönüyoruz
        }
    }
}
