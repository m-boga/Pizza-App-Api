# Pizza Sipariş Uygulaması

Pizza için Türkiye genelinde binlerce şubesi bulunan yeni bir sipariş uygulaması geliştirildi. 
Uygulamada, müşteriye sipariş verebileceği şubeleri listelerken,en fazla 10km uzaklıkta olan yalnızca en yakın 5 restoranı gösteriliyor.

## Teknolojiler

Bu projede aşağıdaki teknolojiler kullanıldı:

- C# (.NET Core 6.0)
- Entity Framework Core
- MsSQL

## Proje Yapısı

Bu proje aşağıdaki klasör yapısına sahiptir:

- PizzaApp: Ana klasör. Projenin tüm dosyalarını içerir.

  - Controllers: Controller dosyalarını içerir.
    - RestaurantBranchesController.cs: RestaurantBranches endpoint'lerini içeren controller.

  - Models: Model dosyalarını içerir.
    - RestaurantBranch.cs: RestaurantBranch modelini tanımlar.
    - IRestaurantBranchRepository.cs: IRestaurantBranchRepository interface'ini tanımlar.

  - Data: Veritabanı erişimini ve veritabanı ile ilgili işlemleri içerir.
    - PizzaAppContext.cs: Veritabanı bağlantılarını tanımlar.
    - RestaurantBranchRepository.cs: RestaurantBranchRepository sınıfını tanımlar.

  - appsettings.json: Veritabanı Bağlantısını içerir.
  - Program.cs: Ana program dosyası.

- README.md: Proje hakkında bilgi verir.

## Senaryo

Kullanıcı, Infoset's Pizza'nın uygulamasını kullanarak en yakın şubeleri bulmak istiyor.

- Kullanıcı, lokasyonunu girer: (latitude), (longitude).
- Kullanıcının konumu API'ye gönderilir.
- API, kullanıcının konumuna en fazla 10km uzaklıkta olan en yakın 5 şubeyi belirler.
- API, bu şubeleri bir listeye dökerek kullanıcıya geri döndürür. Bu liste, şubenin id, name, latitude, ve longitude bilgilerini içerir.

Örnek : 41.0614 (Latitude), 28.9854 (Longitude).


    Örnek : 41.0614 (Latitude), 28.9854 (Longitude).
          [
            {
              "id": 3,
              "name": "Şişli",
              "latitude": 41.0614,
              "longitude": 28.9854
            },
            {
              "id": 2,
              "name": "Beşiktaş",
              "latitude": 41.0428,
              "longitude": 29.0077
            },
            {
              "id": 22,
              "name": "Beyoğlu",
              "latitude": 41.0371,
              "longitude": 28.977
            },
            {
              "id": 14,
              "name": "Kağıthane",
              "latitude": 41.0851,
              "longitude": 28.9725
            },
            {
              "id": 4,
              "name": "Üsküdar",
              "latitude": 41.0249,
              "longitude": 29.0175
            }
          ]

Çalıştırma

Projeyi çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

    Terminalde, projenin bulunduğu klasöre gidin.
    dotnet run komutunu çalıştırın.

Veritabanı Ayarları

Projeyi başka bir bilgisayarda çalıştırmak için aşağıdaki adımları izleyin:

-    SQL Server Management Studio (SSMS) veya başka bir SQL sunucu yönetim aracını kullanarak yeni makinada SQL Server'ı açın.
-    appsettings.json dosyasında "PizzaAppDb" bağlantı dizesini bulun.
-    MUHAMMET-WIND\\SQLEXPRESS yerine, yeni makinenin SQL Server adını girin.

