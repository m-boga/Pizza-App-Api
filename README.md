# Pizza Sipariş Uygulaması

Türkiye genelinde binlerce şubesi bulunan yeni bir sipariş uygulaması geliştirildi. 
Uygulamada, müşteriye sipariş verebileceği şubeleri listelerken,en fazla 10 km uzaklıkta olan yalnızca en yakın 5 restoranı gösteriliyor.

## Teknolojiler

Bu projede aşağıdaki teknolojiler kullanıldı:

- C# (.NET Core 6.0)
- Entity Framework Core
- MsSQL

Haversine Formülü

Uygulamanın, kullanıcı konumuna en yakın 5 şubeyi belirleme işlemi sırasında Haversine formülü kullanılmaktadır. Haversine formülü, dünya üzerindeki iki nokta arasındaki mesafeyi hesaplar. Bu formül, kullanıcı konumu ile restoran şubelerinin konumları arasındaki mesafeyi belirlemek için kullanılır.
Haversine formülü aşağıdaki gibidir:

	    a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2)
	    c = 2 ⋅ atan2( √a, √(1−a) )
	    d = R ⋅ c


Burada:

	    φ1, φ2: iki noktanın enlem değerleri,
	    λ1, λ2: iki noktanın boylam değerleri,
	    R: Dünya'nın yarıçapı (ortalama olarak 6,371km),
	    Δφ = φ2 - φ1: enlem farkı,
	    Δλ = λ2 - λ1: boylam farkı.

Bu formül, RestaurantBranchRepository.cs dosyasındaki bir fonksiyonda kullanılmıştır ve bu fonksiyon, kullanıcının konumuna en fazla 10km uzaklıkta olan ve en yakın 5 şubeyi belirlemek için kullanılır. Haversine formülü sayesinde, uygulama düz bir çizgi üzerinde değil, Dünya'nın yüzeyinde gerçek bir mesafe hesaplaması yapar. Bu da sonuçların doğruluğunu artırır.


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
	
Response body
	
  
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

Örnek Sql Komutları

    INSERT INTO RestaurantBranches (Name, Latitude, Longitude) 
    VALUES 
    ('Kadıköy', 40.9903, 29.0205),
    ('Beşiktaş', 41.0428, 29.0077),
    ('Şişli', 41.0614, 28.9854),
    ('Üsküdar', 41.0249, 29.0175),
    ('Bakırköy', 40.9833, 28.8672),
    ('Avcılar', 40.9801, 28.7175),
    ('Bağcılar', 41.0357, 28.833),
    ('Beylikdüzü', 40.9926, 28.641),
    ('Maltepe', 40.9357, 29.1362),
    ('Ümraniye', 41.039, 29.1095),
    ('Ataşehir', 40.9847, 29.1067),
    ('Fatih', 41.0216, 28.9497),
    ('Zeytinburnu', 40.9881, 28.9036),
    ('Kağıthane', 41.0851, 28.9725),
    ('Sarıyer', 41.1664, 29.0503),
    ('Adalar', 40.8766, 29.091),
    ('Arnavutköy', 41.1848, 28.7389),
    ('Bahçelievler', 40.9991, 28.854),
    ('Başakşehir', 41.0975, 28.8062),
    ('Bayrampaşa', 41.0346, 28.9123),
    ('Beykoz', 41.1239, 29.1086),
    ('Beyoğlu', 41.0371, 28.977),
    ('Büyükçekmece', 41.0156, 28.5955),
    ('Çatalca', 41.1436, 28.4616),
    ('Çekmeköy', 41.0402, 29.1754),
    ('Esenler', 41.0333, 28.8909),
    ('Esenyurt', 41.0435, 28.6762),
    ('Eyüpsultan', 41.0462, 28.9253),
    ('Gaziosmanpaşa', 41.0575, 28.9158),
    ('Güngören', 40.9933, 28.8822),
    ('Kartal', 40.9126, 29.3111),
    ('Küçükçekmece', 40.9969, 28.7756),
    ('Pendik', 40.877, 29.2334),
    ('Sancaktepe', 41.0069, 29.2349),
    ('Silivri', 41.0732, 28.247),
    ('Sultanbeyli', 40.9681, 29.2588),
    ('Sultangazi', 41.1045, 28.8681),
    ('Şile', 41.1744, 29.6125),
    ('Tuzla', 40.8167, 29.3008);
