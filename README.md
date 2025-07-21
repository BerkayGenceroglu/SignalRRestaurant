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


