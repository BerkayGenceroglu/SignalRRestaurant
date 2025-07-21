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
## 👤 Kullanıcı Girişi ve Üyelik

### 📝 Üye Ol (Register)

Bu ekran, yeni kullanıcıların sisteme kayıt olması için gerekli form alanlarını içerir.  
Kullanıcılar aşağıdaki bilgileri doldurarak üyelik işlemlerini tamamlayabilir:

- Ad  
- Soyad  
- Kullanıcı Adı  
- E-posta  
- Şifre  

Kayıt işlemi tamamlandıktan sonra kullanıcılar sisteme giriş yapabilir.  
Zaten hesabı olan kullanıcılar için sayfanın altında **“Giriş Yap”** linki mevcuttur.

<img width="1920" height="916" alt="Üye Ol Sayfası" src="https://github.com/user-attachments/assets/c93fd7cd-14b7-4133-8a1e-b315a82a5613" />

---

### 🔐 Giriş Yap (Log In)

Bu ekran, mevcut kullanıcıların sisteme kullanıcı adı ve şifre ile güvenli bir şekilde giriş yapmasını sağlar.  
Giriş formu, sade ve kullanıcı dostudur.  
Henüz hesabı olmayan kullanıcılar için alt kısımda **“Kayıt Ol!”** seçeneği sunulmuştur.

<img width="1920" height="914" alt="Giriş Sayfası" src="https://github.com/user-attachments/assets/14ee9947-df2e-4f73-b146-491ef43c2109" />


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

## 🍔 Menü Sayfası

Bu bölüm, projenin geniş ve çeşitli menü sayfasını farklı kategorilere göre ayrılmış olarak göstermektedir.  
Kullanıcılar, üst kısımdaki filtreleme seçeneklerini kullanarak **Hamburger, Patates, Makarna, Salata, Tatlı, İçecek** gibi ürünleri kolayca filtreleyebilir.

Her bir ürün kartında:
- Ürün görseli
- Açıklama
- Fiyat bilgisi

sunularak kullanıcıların lezzetleri keşfetmesi ve siparişe yönelmesi sağlanır.

<img width="800" height="800" alt="Menu Ekranı 1" src="https://github.com/user-attachments/assets/70c3fbb3-41c1-4994-93a6-0732575b7816" />
<img width="800" height="800" alt="Menu Ekranı 2" src="https://github.com/user-attachments/assets/96b32ec4-75ab-4cad-8fd7-f5b8ad683044" />
<img width="800" height="800" alt="Menu Ekranı 3" src="https://github.com/user-attachments/assets/ef99992a-e58e-49bc-93aa-324748b6e15d" />

---

## ✅ Menü Sipariş Onayı

Bu ekran, kullanıcı bir ürün seçip **siparişe** veya **sepete** eklediğinde gösterilen başarı mesajını temsil eder.

Örneğin:
- "Steak Burger" seçildiğinde, kullanıcıya pop-up yoluyla **"Ürün sepete eklendi"** onayı sunulur.
- Bu işlem, genellikle önceden belirlenmiş bir masaya ait sipariş kapsamında gerçekleşir.

**Amaç:** Kullanıcının seçtiği ürünün siparişe başarıyla eklendiğini açıkça teyit etmektir.

<img width="1918" height="922" alt="Sipariş Onayı 1" src="https://github.com/user-attachments/assets/08cc535f-da70-488d-9ef1-a59326f0bcda" />
<img width="1920" height="916" alt="Sipariş Onayı 2" src="https://github.com/user-attachments/assets/bf1d131a-8f20-487e-9863-c9b69ce2917d" />

## 📍 Masa Bilgileri ve Rezervasyon

Bu ekran, işletmenin mevcut tüm masalarının durumunu (**boş** veya **dolu**) detaylı bir şekilde gösterir.  
Masalar aşağıdaki gibi farklı alanlara ayrılmıştır:

- Salon  
- Bahçe  
- Teras  
- Üst Kat  

Kullanıcılar ya da işletme personeli, bu ekran üzerinden:
- Rezervasyon yapılabilecek uygun masaları kolayca tespit edebilir.
- Oturum açılmış masaları görüntüleyebilir.
- Hızlı seçim yaparak masa planlamasını yönetebilir.

Ayrıca Kullanıcı Bir Dolu bir masanın kasa kısmına tıklandığında, o masaya ait **toplam sepet tutarı** ve **hesap detayları** sağ alt kısımda gösterilir.  
Bu özellik sayesinde, masa bazlı hesap takibi kolayca yapılabilir
<img width="1920" height="921" alt="Masa Bilgileri ve Rezervasyon" src="https://github.com/user-attachments/assets/ba006e45-85f4-4da1-914b-02eaa0a1b80e" />
<img width="1917" height="863" alt="image" src="https://github.com/user-attachments/assets/94d69f73-1eb2-4dc4-9a64-3524be9b9213" />

## 🛒 Sepetim / Sipariş Özeti

Bu ekran, kullanıcıların seçtiği tüm ürünlerin toplandığı alışveriş sepetini gösterir.  
Sepet, kullanıcının seçtiği veya rezerve ettiği masaya özel tutulur.

Sepette listelenen bilgiler:  
- Ürün Adı  
- Adet  
- Fiyat  
- Toplam Tutar  

Kullanıcılar, istedikleri ürünleri sepetten kolayca çıkarabilirler.

Sağ tarafta ise:  
- Sipariş özeti (Ürün Tutarı, KDV, Genel Toplam)  
- Kupon kodu uygulama alanı  

bulunur.

Kullanıcılar, siparişlerini gözden geçirdikten sonra **“Siparişi Tamamla”** butonuna tıklayarak ödeme aşamasına geçebilirler.

<img width="1920" height="979" alt="Sepetim / Sipariş Özeti" src="https://github.com/user-attachments/assets/44bb2c11-3411-47ae-a92c-f5fda7871753" />

## 🍳 Tarifler

Bu ekran, çeşitli **“Lezzetli Tarifler”** bölümünü sunar.  
Her bir tarif için:

- Tarif Başlığı  
- Tahmini Hazırlık Süresi  
- Videolu tarife yönlendiren bir **"Tarifi İzle"** butonu  bulunmaktadır.


Tarif içerikleri, **RapidAPI** üzerinden **dinamik** olarak çekilmektedir.  
Bu sayede her girişte güncel ve zengin tarif içerikleri kullanıcılara sunulur.

<img width="1920" height="922" alt="Tarifler Sayfası" src="https://github.com/user-attachments/assets/4b90cea4-20ea-4be6-aaa2-31d9298e6b74" />

## 📅 Masa Rezervasyon Sayfası (Book A Table)

Bu ekran, kullanıcıların işletmede masa rezervasyonu yapmasını sağlayan bir arayüz sunar.

Kullanıcılar aşağıdaki bilgileri girerek kolayca rezervasyon talebi oluşturabilir:
- Ad Soyad  
- Telefon Numarası  
- E-posta  
- Kişi Sayısı  
- Rezervasyon Tarihi  

Sayfanın sağ tarafında ise işletmenin fiziksel konumunu gösteren **interaktif bir harita** yer almaktadır.

<img width="1918" height="921" alt="Masa Rezervasyon Sayfası" src="https://github.com/user-attachments/assets/66f179ff-3bc1-4671-a8cb-83833529fc68" />

## 🎛️ Admin Paneli

### 📊 Anlık İstatistik Bilgileri

Bu ekran, yönetim panelinin ana kontrol merkezidir.  
Yöneticiler aşağıdaki verilere **gerçek zamanlı** olarak erişebilir:

- Kategori ve ürün sayıları  
- Aktif/pasif kategori bilgisi  
- Hamburger ve içecek adetleri  
- Ortalama fiyatlar (ürün/hamburger)  
- Sipariş durumu (toplam ve aktif)  
- En pahalı / en ucuz ürün  
- Kasadaki toplam tutar  
- Günlük kazanç  
- Boş masa sayısı  

📡 Bu veriler **SignalR** teknolojisiyle anlık olarak güncellenmektedir.  
Sol menüden diğer yönetim modüllerine hızlı erişim mümkündür.

<img width="1919" height="927" alt="Admin Paneli - Anlık İstatistikler" src="https://github.com/user-attachments/assets/c31c5a43-6b4e-4d76-8f64-44c4ed25ab97" />

---

### 🔔 Anlık Bildirimler (SignalR Destekli)

Bu panel, yöneticilere anlık olarak uyarılar gösterir.  
Bildirimler sağ üstteki zil ikonundan erişilen pencerede listelenir:

- 🆕 Örnek: "Yeni Siparişiniz var"  
- ⏱️ Zaman damgası ile gösterim  
- 🔁 Sayfa yenilemeye gerek kalmadan anında bilgilendirme  
- 📂 "See all notifications" ile geçmiş bildirimlere erişim

<img width="682" height="344" alt="Anlık Bildirimler" src="https://github.com/user-attachments/assets/18a5ac16-9b07-4705-8ef0-03c850511d09" />
<img width="1919" height="923" alt="Admin Paneli - Bildirim Listesi" src="https://github.com/user-attachments/assets/bdb1d24c-ec66-49df-a0de-d1e211797c97" />

---

### 🗂️ Kategoriler

Bu ekran, ürün kategorilerinin yönetildiği bölümdür.  
Mevcut kategoriler tablo halinde listelenir ve işlemler yapılabilir:

- 📄 Kategori adı ve durumu  
- 🛠️ Sil, Güncelle  
- ➕ "Yeni Kategori Ekle" butonu ile yeni kategori oluşturma

<img width="1920" height="919" alt="Admin Paneli - Kategoriler" src="https://github.com/user-attachments/assets/ecf3bec3-3f5f-428a-99e5-7936c2e999b1" />

---

### 🍔 Ürünler

Bu ekran, sistemde kayıtlı tüm ürünlerin listelendiği bölümdür.  
Her ürün için şu bilgiler yer alır:

- Ürün adı  
- Fiyat  
- Kategorisi  
- Aktif/pasif durumu  

Yöneticiler ürünleri kolayca **silip güncelleyebilir**, üst kısımdaki **arama çubuğu** sayesinde ürün araması yapabilir.

<img width="1912" height="978" alt="Admin Paneli - Ürünler" src="https://github.com/user-attachments/assets/8034e273-7f47-4194-8d19-6784353b322c" />

---

### 📆 Rezervasyon Yönetimi (SignalR Destekli)

Yöneticiler, bu panelde gelen masa rezervasyonlarını yönetebilir.  
Tabloda aşağıdaki bilgiler yer alır:

- Ad soyad  
- Telefon numarası  
- Kişi sayısı  
- Rezervasyon durumu (Onaylandı, İptal Edildi vb.)  

Yapılabilecek işlemler:

- 🗑️ Sil  
- ✏️ Güncelle  
- ✅ Onayla  
- ❌ İptal Et  
- ➕ Yeni rezervasyon oluştur  

SignalR entegrasyonu sayesinde tüm işlemler **gerçek zamanlı** olarak yansıtılır.

<img width="1920" height="918" alt="Admin Paneli - Rezervasyonlar" src="https://github.com/user-attachments/assets/7734f95b-b142-4f5b-a6fb-f299c2dd30dd" />

## Hakkımızda İşlemleri

Bu ekran, yöneticilerin web sitesinin **"Hakkımızda"** bölümünü yönetmelerini sağlar.

- İçerik: Başlık ve açıklama bilgileriyle birlikte işletme tanıtımı yer alır.
- İşlemler: Hakkımızda bilgisi **güncellenebilir**, **silinebilir**.
- Uyarı: Sistemin bütünlüğü için sadece bir adet "Hakkımızda" kaydı bulunmalıdır.
- Yeni Kayıt: Alt kısımda **"Yeni Hakkımızda Ekle"** butonu yer alır.

![Hakkımızda Ekranı](https://github.com/user-attachments/assets/744adff4-7588-488f-ab68-d68e84a6f601)

## İndirimler

Bu ekran, yönetim panelindeki **İndirimler Modülü**nü temsil eder.

- Listeleme: Ürün, indirim oranı ve durum bilgileriyle tüm indirimler görüntülenir.
- İşlemler: Mevcut indirimler **güncellenebilir**, **silinebilir**, **aktif/pasif** yapılabilir.
- Yeni Kayıt: **"Yeni İndirim Ürünü Girişi"** butonu ile yeni indirim eklenebilir.
- Gerçek Zamanlı: SignalR sayesinde tüm işlemler anında tüm istemcilere yansır.

![İndirimler Ekranı](https://github.com/user-attachments/assets/0041ea26-549c-4e17-b199-c0629f30ccdd)

## İletişim

Bu ekran, web sitesine ait iletişim bilgilerinin yönetildiği modüldür.

- Bilgiler: Konum, telefon, e-posta ve açıklama bilgileri listelenir.
- İşlemler: Bilgiler **güncellenebilir**, **silinebilir** veya **yeni bilgi** eklenebilir.
- Amaç: Ziyaretçilerin daima güncel iletişim bilgilerine ulaşmasını sağlar.

![İletişim Ekranı](https://github.com/user-attachments/assets/6a8efaf7-2970-43b1-9a1f-17be5137fcf7)

## Öne Çıkanlar

Bu ekran, web sitesinin ana sayfasında gösterilecek öne çıkan içeriklerin yönetimini sağlar.

- İçerik: Başlık ve detaylı açıklama alanları içerir.
- İşlemler: Öne çıkan içerikler **silinebilir**, **güncellenebilir**.
- Yeni Kayıt: **"Öne Çıkan Alan Ekle"** butonu ile yeni içerik eklenebilir.
- Amaç: Dinamik içerik yönetimiyle web sitesini güncel tutmak.

![Öne Çıkanlar Ekranı](https://github.com/user-attachments/assets/f0ef5543-da96-42a0-9f58-7f035a0b40be)

## Referanslar

Bu ekran, müşteri yorumları ve referans içeriklerinin yönetildiği modüldür.

- Bilgiler: Müşteri adı, yorum metni ve yorum durumu (aktif/pasif) ile listelenir.
- İşlemler: Yorumlar **güncellenebilir**, **silinebilir**.
- Yeni Kayıt: **"Yeni Müşteri Yorumu Ekle"** butonu ile yeni yorum eklenebilir.
- Amaç: Web sitesine güven kazandırmak ve kullanıcı geri bildirimlerini sergilemek.

![Referanslar Ekranı](https://github.com/user-attachments/assets/e635200c-681a-4966-8203-97bed0b85472)

## Sosyal Medya
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Sosyal Medya İşlemleri modülünü sunmaktadır. Bu bölüm, web sitesinde kullanılacak sosyal medya platformlarının bağlantılarını merkezi bir yerden yönetmek için tasarlanmıştır. Yöneticiler, listedeki sosyal medya başlıkları ve ilgili linkler üzerinde kolayca silme, güncelleme işlemleri yapabilir veya "Yeni Sosyal Medya Girişi" butonu ile yeni platform bağlantıları ekleyebilirler. Bu modül, sitenin sosyal medya entegrasyonunu dinamik ve güncel tutmak için pratik bir çözüm sunar.
<img width="1920" height="925" alt="image" src="https://github.com/user-attachments/assets/2cfe4754-41aa-46b2-a825-162f0815c445" />
## Masa İşlemleri
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Masa İşlemleri modülünü sunmaktadır. Bu bölüm, özellikle restoran veya benzeri işletmelerde kullanılan masa veya bölüm adlarını yönetmek için tasarlanmıştır. Yöneticiler, listedeki masa adları üzerinde kolayca silme ve güncelleme işlemleri yapabilirler. Bu modül, işletmenin fiziki yerleşim düzeninin veya rezervasyon sisteminin güncel ve düzenli tutulmasına olanak sağlar.
<img width="1920" height="932" alt="image" src="https://github.com/user-attachments/assets/fe1db5e7-4cb2-4a12-8742-0e8de725cd14" />
## Masa Durum Bilgileri
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Anlık Masa Bilgileri modülünü sunmaktadır. Özellikle restoran veya kafe gibi işletmelerde masaların doluluk durumunu gerçek zamanlı olarak takip etmek için tasarlanmıştır. Yeşil kutular masanın boş olduğunu (onay işareti), kırmızı kutular ise dolu olduğunu (çarpı işareti) gösterir. SignalR entegrasyonu sayesinde, masaların doluluk durumları anlık olarak güncellenir, bu da işletme personelinin en güncel masa durumunu hızlıca görmesini ve yönetmesini sağlar. 
<img width="1913" height="930" alt="image" src="https://github.com/user-attachments/assets/2bb67d73-28a5-4e59-a0bc-705129bea183" />
## Anlık Mesajlaşma
Bu ekran görüntüsü, Mr. Berkay Burger web sitesinin SignalR Restoran Anlık Mesajlaşma bölümünü sunmaktadır. Bu özellik, kullanıcılar arasında gerçek zamanlı bir sohbet sistemi sağlamak amacıyla SignalR teknolojisi ile geliştirilmiştir. Ziyaretçiler, basit bir arayüz üzerinden kendi kullanıcı adlarını girerek mesajlarını yazabilir ve anında gönderebilirler. Bu modül, restoran ile müşteriler arasında veya müşterilerin kendi aralarında hızlı ve dinamik iletişimi mümkün kılar.
<img width="1920" height="894" alt="image" src="https://github.com/user-attachments/assets/ea11037a-a928-4ccf-9023-7a2dda8cc2c9" />
## İstatistikler & Durumlar
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Admin İstatistikler & Durumlar bölümünü göstermektedir. Bu panel, işletmenin finansal durumu (Kasadaki Toplam Tutar, Son Sipariş Tutarı vb.) ve operasyonel metrikleri (Toplam Masa Sayısı, Toplam Sipariş Sayısı, Ürün Ortalamaları vb.) hakkında kapsamlı ve özet bilgiler sunar. SignalR entegrasyonu sayesinde, tüm bu istatistikler ve durumlar anlık olarak güncellenir, böylece yöneticiler işletmenin mevcut performansını her zaman en güncel verilerle takip edebilir ve hızlı kararlar alabilir.
<img width="1920" height="909" alt="image" src="https://github.com/user-attachments/assets/1f296574-19dd-4a6b-8839-8a1bd89e1ebc" />
## QR Kod Oluşturma
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin QR Kod Oluştur modülünü göstermektedir. Bu bölüm, yöneticilerin herhangi bir metin veya bağlantı (URL) için hızlıca QR kodları oluşturmasına olanak tanır. Kullanıcılar, girmek istedikleri metni veya web adresini ilgili alana yazıp "QR Kod Oluştur" butonuna bastıklarında, anında taranabilir bir QR kodu elde ederler. Bu özellik, fiziksel materyaller üzerinde veya dijital paylaşımlarda hızlı erişim linkleri sağlamak için oldukça kullanışlıdır.
<img width="1918" height="925" alt="image" src="https://github.com/user-attachments/assets/673eb222-c35c-4d01-8a5d-4ecb10cb9e9c" />
## Mail Gönderme
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Mail Gönder modülünü sunmaktadır. Bu bölüm, yöneticilerin platform üzerinden kolayca e-posta göndermesine olanak tanır. Yöneticiler, alıcının e-posta adresini, e-postanın konusunu ve mesaj içeriğini ilgili alanlara girerek iletişim kurabilirler. Bu modül, duyurular, bilgilendirmeler veya müşteri hizmetleri gibi amaçlarla hızlı ve doğrudan e-posta iletişimi sağlamak için pratik bir araçtır.
<img width="1918" height="922" alt="image" src="https://github.com/user-attachments/assets/4676d0ca-6671-45c1-9ee3-1d7b7941ac71" />
## Bilgi Güncelleme
Bu ekran görüntüsü, SignalR Yönetim Paneli'nin Profil Bilgilerini Güncelle modülünü sunmaktadır. Bu bölüm, yöneticilerin kendi kişisel ve hesap bilgilerini (Ad, Soyad, Kullanıcı Adı, E-posta Adresi ve Şifre) güvenli bir şekilde güncellemelerine olanak tanır. Yöneticiler, bu modül aracılığıyla profillerindeki bilgileri kolayca düzenleyerek hesaplarını güncel tutabilir ve gerektiğinde şifrelerini yenileyebilirler.
<img width="1914" height="922" alt="image" src="https://github.com/user-attachments/assets/6cbadb55-89a1-434a-9037-52b9bac8f370" />

### 📫 İletişim
Proje hakkında sorularınız, önerileriniz ya da katkı istekleriniz için benimle iletişime geçebilirsiniz:
📧 berkaygenceroglu6@example.com
🔗 LinkedIn:Berkay Genceroğlu

## 💬 Son Söz
Teşekkürler! Bu projeyi kullandığınız veya katkıda bulunduğunuz için memnuniyet duyarım. Her türlü geri bildirime açığım.
İyi kodlamalar! 🚀

