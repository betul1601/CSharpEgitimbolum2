using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;//VERİ TABANI İŞLEMLERİ İÇİN GEREKLİ
using System.Data.SqlClient;//ADONET KÜTÜPHANELERİ

namespace WindowsFormsAppAdonet
{
    internal class KategoriDal
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database=UrunYonetimiAdonet;integrated security=true");
        void ConnectionKontrol() //void = tek
        {
            if (connection.State == ConnectionState.Closed) //eğer yukarıda tanımladığımız veritabanı bağlantısı kapalıysa 
            {
                connection.Open();//bağlantıyı aç
            }
        }

        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); //bağlantıyı kontrol et
            DataTable dt = new DataTable();//boş bir datatable nesnesi oluştur
            SqlCommand command = new SqlCommand("select * from Kategoriler", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader);    //dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close();//veri okuyucuyu kapat
            command.Dispose();//sql komut nesensini kapat
            connection.Close();//veri tabanı bağlantısıın kapat
            return dt;// metodun çağıırldığı yere gönder

        }
        public int Add(kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Kategoriler (KategoriAdi,Durum) values (@KategoriAdi,@Durum)", connection);  //sql komutu olarak bu sefer insert komutu yaazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            
            int islemSonucu = command.ExecuteNonQuery();//executenonquery metodu geriye veritabanında etkilenen kayıt sayısını döner  
            command.Dispose();//sql komut nesnesini kapa
            connection.Close();//veritabanı nesnesini kapa
            return islemSonucu; // metodumuz geriye int döndüğü için işlem sonucu değişkenini geri dönüyoruz
        }

        public kategori Get(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select* from kategoriler where Id=" + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            kategori kategori = new kategori();

            while (reader.Read())
            {
                kategori.Id = Convert.ToInt32(reader["Id"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();    
                kategori.Durum = Convert.ToBoolean(reader["Durum"]);
              

            }
            reader.Close();//veri okuyucuyu kapat
            command.Dispose();//sql komut nesensini kapat
            connection.Close();//veri tabanı bağlantısıın kapat
            return kategori;
        }

        public int Update(kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Kategoriler set KategoriAdi=@KategoriAdi, Durum=@Durum where Id=@id", connection);  
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            command.Parameters.AddWithValue("@id", kategori.Id);

            int islemSonucu = command.ExecuteNonQuery();//executenonquery metodu geriye veritabanında etkilenen kayıt sayısını döner  
            command.Dispose();//sql komut nesnesini kapa
            connection.Close();//veritabanı nesnesini kapa
            return islemSonucu; // metodumuz geriye int döndüğü için işlem sonucu değişkenini geri dönüyoruz
        }
        public int Delete(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Delete from Kategoriler where Id= @UrunId", connection);
            command.Parameters.AddWithValue("@UrunId", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;
        }
    }
}
