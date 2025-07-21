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

---
### 🏠 Anasayfa

Web sitesinin ana sayfasında, öne çıkan lezzetler dikkat çekici başlıklarla tanıtılır:  
**“Lezzetli Makarnalar”**, **“Eşsiz Hamburgerler”**, **“Sıcacık ve Doyurucu Menü Seçenekleri”**.  
Üst menü navigasyonu da bu alanda konumlandırılmıştır.

<img width="1920" height="914" alt="Anasayfa Banner" src="https://github.com/user-attachments/assets/db697a0e-4d21-4c87-bb28-1c6be2350c95" />

---

## 🍕 Menü ve Kampanyalar

Bu bölümde hamburger, pizza gibi çeşitli menüler ile özel indirim kampanyaları gösterilir.  
Kullanıcılar kategorilere göre filtreleme yapabilir ve ürünlerin detaylarını inceleyebilir.
> 🔖 Bu sayfa, **2 indirim** ve **9 ürün** gösterilecek şekilde özel olarak yapılandırılmıştır.

<img width="1920" height="922" alt="Menü Sayfası" src="https://github.com/user-attachments/assets/87706c12-a8e0-4507-b8b2-a50f0b99233b" />

---
## 🥗 Yan Ürünler & Menü Detayları

Bu sayfa, işletmenin hikayesini ve lezzet tutkusunu anlatır.  
Markanın felsefesi, sunulan deneyim ve vizyon detaylandırılmıştır.

<img width="1906" height="911" alt="Hakkımızda" src="https://github.com/user-attachments/assets/dbb37ca2-f7e9-4a8d-8a00-352f3fa1388a" />

---

## 🧑‍🍳 Hakkımızda - Lezzetin Mimarlarıyız

Makarnalar, salatalar ve diğer yan ürünler görselleri, isimleri ve fiyatlarıyla listelenir.  
Her ürün kendi kartı içinde şık şekilde sunulmuştur.

<img width="1894" height="850" alt="Yan Ürünler" src="https://github.com/user-attachments/assets/dd0599a3-949e-4287-abf1-ff0423b4afec" />

---

## 📬 İletişim Sayfası

Kullanıcılar bu bölümden işletmeye mesaj gönderebilir.  
Ayrıca fiziksel konum, etkileşimli harita üzerinde gösterilir.

<img width="1892" height="717" alt="İletişim" src="https://github.com/user-attachments/assets/3243db2e-2d41-4833-be73-8ecbdc25da54" />

---

## 💬 Müşteri Yorumları & Footer

Kullanıcı yorumları yatay kaydırılabilir bir arayüzle sunulur.  
En altta işletmenin tüm iletişim bilgileri ve sosyal medya bağlantıları yer alır.

<img width="1920" height="923" alt="Footer ve Yorumlar" src="https://github.com/user-attachments/assets/9962bfb6-3ded-44a3-b42c-38ccfc3abe15" />

### 🍔 Menu Sayfası

Bu bölüm, projenin geniş ve çeşitli menü sayfasını farklı kategorilere göre ayrılmış olarak göstermektedir. Kullanıcılar, üst kısımdaki filtreleme seçeneklerini kullanarak (Hamburger, Patates, Makarna, Salata, Tatlı, İçecek gibi) ürünleri kolayca kategorize edebilir ve sadece istedikleri türdeki menü öğelerini görüntüleyebilirler. Her bir ürünün görseli, açıklaması ve fiyatı sunulurken, kullanıcılar keşfettikleri lezzetleri kolayca inceleyebilir ve sipariş verebilirler.

<img width="800" height="800" alt="image" src="https://github.com/user-attachments/assets/70c3fbb3-41c1-4994-93a6-0732575b7816" />
<img width="800" height="800" alt="image" src="https://github.com/user-attachments/assets/96b32ec4-75ab-4cad-8fd7-f5b8ad683044" />
<img width="800" height="800" alt="image" src="https://github.com/user-attachments/assets/ef99992a-e58e-49bc-93aa-324748b6e15d" />


