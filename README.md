MyPolyglotPersistenceProject
MyPolyglotPersistenceProject, SQL Server, MongoDB ve Redis'i kullanarak veri depolama ve yönetim için polyglot persistence kullanımını gösteren bir .NET web uygulamasıdır.

Özellikler
SQL Server: Yapılandırılmış veri depolama için ilişkisel veritabanı.
MongoDB: Esnek, belge yönelimli veri depolama için NoSQL veritabanı.
Redis: Anahtar-değer veri için hızlı erişim sağlayan bellek içi veri yapısı deposu.
Kurulum Talimatları
Depoyu Kopyalayın

bash
Kodu kopyala
git clone https://github.com/kullanıcıadınız/MyPolyglotPersistenceProject.git
cd MyPolyglotPersistenceProject
Bağlantı Dizelerini Yapılandırın

appsettings.json dosyasını veritabanı bağlantı detaylarınızla güncelleyin:

json
Kodu kopyala
{
  "ConnectionStrings": {
    "SqlServerConnection": "Server=.\\SQLEXPRESS;Database=test;User Id=sa;Password=sifreniz;TrustServerCertificate=True;Encrypt=True;",
    "MongoDbConnection": "mongodb://localhost:27017",
    "RedisConnection": "localhost:6379"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
Uygulamayı Çalıştırın

Visual Studio veya .NET CLI kullanarak uygulamayı derleyin ve çalıştırın:

bash
Kodu kopyala
dotnet build
dotnet run
Uygulamaya Erişin

Web tarayıcınızı açın ve https://localhost:5001 adresine giderek uygulamayı kullanın.

Kullanım
Veri Oluşturma

SQL Server: /YourEntity/CreateInSqlServer formu üzerinden veri gönderin.
MongoDB: /YourEntity/CreateInMongoDb formu üzerinden veri gönderin.
Redis: /YourEntity/CreateInRedis formu üzerinden veri gönderin.
Veri Okuma

SQL Server: /YourEntity/GetFromSqlServer adresinden verilere erişin.
MongoDB: /YourEntity/GetFromMongoDb adresinden verilere erişin.
Redis: /YourEntity/GetFromRedis/{id} adresinden verilere erişin.
Veri Güncelleme

SQL Server: /YourEntity/UpdateInSqlServer/{id} adresinden verileri güncelleyin.
MongoDB: /YourEntity/UpdateInMongoDb/{id} adresinden verileri güncelleyin.
Redis: /YourEntity/UpdateInRedis/{id} adresinden verileri güncelleyin.
Veri Silme

SQL Server: /YourEntity/DeleteFromSqlServer/{id} adresinden verileri silin.
MongoDB: /YourEntity/DeleteFromMongoDb/{id} adresinden verileri silin.
Redis: /YourEntity/DeleteFromRedis/{id} adresinden verileri silin.
Katkıda Bulunma
Katkılar memnuniyetle karşılanır! Herhangi bir değişikliği tartışmak için lütfen bir pull request oluşturun veya bir issue açın.

Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Detaylar için LICENSE dosyasına bakın.
