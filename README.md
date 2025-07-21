<h1 align="center">🍽️ SignalR Restaurant Yönetim Paneli</h1>
<p align="center">
  👨‍🍳 Siparişler • 🪑 Masa Durumu • 📋 Menü Yönetimi • 🧾 Sepet İşlemleri • 🛎️ Rezervasyonlar • 📡 Gerçek Zamanlı İletişim
</p>
## 📌 Proje Hakkında

**SignalRRestaurant**, restoranlar için geliştirilen çok katmanlı bir web uygulamasıdır.  
Projede kullanıcıların masa durumu, menü, sepet işlemleri gibi tüm adımları gerçek zamanlı olarak yönetilebilir.  
Ayrıca admin paneli ile ürün, kategori, rezervasyon gibi işlemleri de kontrol edebilirsin.  

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

```plaintext
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
