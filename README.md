<h1 align="center">🍔 SignalR Tabanlı Gerçek Zamanlı Restoran Yönetim Sistemi</h1>

<p align="center">
  Modern restoranların dijital ihtiyaçlarına çözüm sunan, ASP.NET Core MVC ve SignalR teknolojileriyle geliştirilmiş kapsamlı bir yönetim paneli
</p>

--- 

## 🧾 Proje Tanıtımı

**SignalRRestaurant**, restoranlar için geliştirilmiş, çok katmanlı ve modüler yapıya sahip bir **web tabanlı yönetim sistemidir**.  
Bu proje sayesinde restoran çalışanları ve yöneticileri;

- Gerçek zamanlı masa doluluk durumlarını izleyebilir,
- Müşteri siparişlerini hızlıca alabilir ve takip edebilir,
- Ürün, kategori ve kampanyaları kolayca yönetebilir,
- Rezervasyonları ve müşteri geri bildirimlerini değerlendirebilir,
- Ve tüm bu işlemleri sade, modern ve kullanıcı dostu bir arayüz üzerinden gerçekleştirebilir.

Proje, hem **müşteri deneyimini artırmayı** hem de **restoran operasyonlarını dijitalleştirerek hızlandırmayı** hedeflemektedir.  
Gerçek zamanlı iletişim için **SignalR teknolojisi**, veri erişimi ve API tüketimi için **ASP.NET Core Web API** ve arka planda veri yönetimi için **Entity Framework Core** tercih edilmiştir.

Bu sistem, geliştiriciler için SignalR, API entegrasyonu, DTO kullanımı, ViewComponent, AJAX ve çok katmanlı mimari gibi gelişmiş teknikleri bir arada sunar.  
Ayrıca geliştirilmeye açık olup, AI ile toksik yorum filtreleme gibi yenilikçi özellikleri de desteklemeye uygundur.

---


---
## 🚀 Kullanılan Teknolojiler

| Katman         | Teknolojiler                                                                                                                                   |
|----------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| Backend        | `ASP.NET Core MVC`, `ASP.NET Core Web API`, `Entity Framework Core`, `AutoMapper`, `SignalR`, `Dependency Injection`                          |
| Frontend       | `HTML`, `CSS`, `Bootstrap`, `JavaScript`, `jQuery`, `AJAX`, `SweetAlert2`                                                                     |
| Database       | `MS SQL Server`, `Code First`, `Migration`                                                                                                    |
| Veri Taşıma    | `DTO (Data Transfer Object)`, `Newtonsoft.Json`, `HttpClientFactory`, `ViewComponent`, `TempData`, `Partial View`, `API Tüketimi (Consume)`   |
| Gerçek Zamanlı | `SignalR`, `Hub`, `Client Method Invocation`  

## 🧱 Proje Mimarisi
<pre> ```
SignalRRestaurant/
│
├── SignalRWebUI           → MVC Uygulama Katmanı (UI)
│   ├── Controllers
│   ├── Views
│   ├── Dtos
│   ├── Services (API ile iletişim)
│   └── SignalR (Hub sınıfları)
│
├── SignalRApi             → Web API Katmanı
│   ├── Controllers
│   ├── Entity Layer
│   ├── Data Access Layer (EF Core)
│   └── Business Layer (Manager & Service Interfaces)
│
└── SignalR.DtoLayer       → API <-> UI veri taşıma sınıfları (DTO)
``` </pre>

## 🖥️ Ekran Görüntüleri
### Üye Ol (Register)
Bu ekran, yeni kullanıcıların sisteme kayıt olmak için gerekli bilgileri (Ad, Soyad, Kullanıcı Adı, E-posta ve Şifre) girdiği kayıt formunu göstermektedir. Kullanıcılar, bilgileri girdikten sonra "Kayıt Ol" butonuna tıklayarak üyelik işlemlerini tamamlayabilirler. Zaten hesabı olan kullanıcılar için "Giriş Yap" linki de mevcuttur.

<img width="1920" height="916" alt="image" src="https://github.com/user-attachments/assets/c93fd7cd-14b7-4133-8a1e-b315a82a5613" />

### Giriş Yap (Log in)
Bu ekran, mevcut kullanıcıların sisteme kullanıcı adı ve şifreleriyle güvenli bir şekilde giriş yapmasını sağlayan oturum açma formudur. Henüz hesabı olmayan kullanıcılar için "Kayıt Ol!" seçeneği de mevcuttur.

<img width="1920" height="914" alt="image" src="https://github.com/user-attachments/assets/14ee9947-df2e-4f73-b146-491ef43c2109" />
### Anasayfa

Web sitesinin ana sayfasında yer alan bu tanıtım bannerı, öne çıkan lezzetleri (örneğin "Lezzetli Makarnalar"," Eşsiz Hamburgerler","Sıcacık ve Doyurucu Menü Seçenekleri") büyük ve çekici görsellerle vurgular. Üst menü navigasyonu da bu alanda konumlandırılmıştır.

<img width="1920" height="914" alt="image" src="https://github.com/user-attachments/assets/db697a0e-4d21-4c87-bb28-1c6be2350c95" />
Bu ekran, hamburger ve pizza gibi çeşitli menü öğelerini ve özel indirim kampanyalarını sergiler. Kullanıcılar, kategorilere göre filtreleyerek ürünleri keşfedebilir ve detaylarını görüntüleyebilirler.

<img width="1920" height="922" alt="image" src="https://github.com/user-attachments/assets/87706c12-a8e0-4507-b8b2-a50f0b99233b" />
İşletmenin "Lezzetin Mimarlarıyız" felsefesini anlatan bu bölüm, marka hikayesini, yemek yapımına olan tutkusunu ve misafirlerine sunduğu eşsiz deneyimi detaylandırır.

<img width="1906" height="911" alt="image" src="https://github.com/user-attachments/assets/dbb37ca2-f7e9-4a8d-8a00-352f3fa1388a" />
Ana menüye ek olarak sunulan yan ürünler, makarnalar ve salatalar gibi çeşitli lezzetlerin listelendiği bu ekran, her bir ürünün görselini, adını ve fiyatını gösterir.

<img width="1894" height="850" alt="image" src="https://github.com/user-attachments/assets/dd0599a3-949e-4287-abf1-ff0423b4afec" />
Bu sayfa, kullanıcıların işletmeyle doğrudan iletişime geçebilmesi için bir mesaj gönderme formu sunar. Ayrıca, işletmenin fiziksel konumunu gösteren interaktif bir harita da bu alanda yer alır

<img width="1892" height="717" alt="image" src="https://github.com/user-attachments/assets/3243db2e-2d41-4833-be73-8ecbdc25da54" />
Bu bölümde, müşterilerin işletmenin lezzetleri ve hizmetleri hakkındaki yorumları ve geri bildirimleri sunulur. Kullanıcıların olumlu deneyimleri, kaydırılabilir bir arayüzde gösterilir.
Web sitesinin en altında bulunan bu bölüm, işletmenin iletişim bilgilerini (konum, telefon, e-posta), sosyal medya bağlantılarını, kısa bir tanıtım metnini ve çalışma saatlerini özetler.

<img width="1920" height="923" alt="image" src="https://github.com/user-attachments/assets/9962bfb6-3ded-44a3-b42c-38ccfc3abe15" />


