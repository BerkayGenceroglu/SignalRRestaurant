using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QRCoder;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.WebRequestMethods;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
            QRCodeGenerator createQRCode = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCodeData = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = qrCodeData.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
//"Bir yazıyı (örneğin Merhaba Berkay) alır, onu QR koda çevirir, sonra bu QR kodu bir resim gibi bellekte tutar ve bu resmi tarayıcıda gösterecek şekilde HTML'ye gömer."
//🔍 1. public IActionResult Index(string value)
//Bu bir ASP.NET Core MVC Action metodudur.

//Index metoduna bir parametre olarak value gelir.

//Bu value, QR koda çevrilmek istenen metindir.

//Örnek: / Home / Index ? value = https ://berkay.com

//🧠 Bu metodun amacı: Kullanıcının verdiği metinden QR kod üretip View’a göndermek.

//🔍 2. using (MemoryStream memoryStream = new MemoryStream())
//🧾 Anlamı:
//MemoryStream, geçici bellek alanı oluşturur.

//Resmi bilgisayara dosya olarak kaydetmeden, sadece RAM’de tutmak için kullanılır.

//🧠 Görseli geçici olarak bellekte oluşturacağız çünkü biz onu ekrana basacağız, dosya olarak kaydetmeyeceğiz.

//🔍 3. QRCodeGenerator createQRCode = new QRCodeGenerator();
//🧾 Anlamı:
//QRCodeGenerator, QR kod üretebilen bir sınıftır (QRCoder kütüphanesinden).

//Bu satırda bir QR kod üretici nesnesi oluşturuluyor.

//🧠 Tıpkı bir yazıcı gibi düşün, ona ne yazdırmak istediğimizi söyleyeceğiz.

//🔍 4. QRCodeGenerator.QRCode qrCodeData = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
//🧾 Ne oluyor?
//CreateQrCode metodu, QR kodun ham veri halini üretir.

//value → QR kodda yer alacak yazıdır.

//ECCLevel.Q → Hata düzeltme seviyesi (QR kodun %25’i bozulsa bile hala okunabilir olması).

//🧠 Örnek: "Merhaba Berkay" metni QR kodun içine gizlenmiş olur.

//🔍 5. using (Bitmap image = qrCodeData.GetGraphic(10))
//🧾 Ne demek?
//QR kodun görselini oluşturur.

//GetGraphic(10) → QR kod kutucuklarının büyüklüğü. Ne kadar büyük sayı verilirse QR kod o kadar büyük olur.

//🧠 Bitmap, resmi temsil eder. Artık QR kodumuz bir resim formatında bellekte var.

//🔍 6. image.Save(memoryStream, ImageFormat.Png);
//🧾 Ne yapar?
//Görseli belleğe (memoryStream) PNG formatında yazar.

//Bu işlem sırasında hala dosya kaydı yapılmaz, her şey RAM üzerinde olur.

//🧠 QR kod resmi artık geçici bellekte bir PNG resim olarak tutuluyor.

//🔍 7. ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
//Bu satır çok önemli! Parça parça açıklayayım:

//🧩 A.memoryStream.ToArray()
//Bellekteki PNG dosyasını byte dizisine çevirir.

//Yani bilgisayar dilinde resim: 010101011001...

//🧩 B.Convert.ToBase64String(...)
//Bu byte dizisini base64 metnine dönüştürür.

//Çünkü HTML’de resmi direkt byte olarak gösteremeyiz.

//Örnek çıktı: iVBORw0KGgoAAAANSUhEUgAA...

//🧩 C. "data:image/png;base64," + ...
//Bu kısım HTML için özel bir başlıktır.

//Tarayıcıya der ki: “Bu bir PNG resmidir ve base64 formatında kodlanmıştır.”

//🧩 D. ViewBag.QRCodeImage = ...
//Bu base64 formatındaki resmi, ViewBag ile View’a taşıyoruz.

//🧠 HTML sayfasında resim olarak görünmesini sağlıyoruz, ama dosya yok! Her şey yazıya çevrilmiş bir resim.

//🔍 8. return View();
//Kod biter ve .cshtml dosyası açılır (örneğin Index.cshtml).

//Artık o sayfa içinde QR kodu gösterebiliriz.

