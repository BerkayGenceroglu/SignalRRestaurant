using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Dtos.ContactDtos;
using Microsoft.IdentityModel.Tokens;
using SignalRApi.Viewmodel;
using SignalRWebUI.Models;

namespace SignalRWebUI.Controllers
{
    public class BookATable : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATable(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7259/api/Contact");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata);
            var GetContact = contact.FirstOrDefault();
            ViewBag.location = GetContact.LocationMap;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client2.GetAsync("https://localhost:7259/api/Contact");
            var jsondata2 = await responseMessage.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata2);
            var GetContact = contact.FirstOrDefault();
            ViewBag.location = GetContact.LocationMap;

            //-----------------------------------------------
            createBookingDto.Description = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7259/api/Booking", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                TempData["BookingStatus"] = "success";
                return RedirectToAction("Index", "BookATable");
            }
            else
            {
                ModelState.Clear();
                var errorResponse = await responsemessage.Content.ReadFromJsonAsync<ValidationErrorWrapper>();
                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach (var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }
                }
                //View’da(ekranda) hata mesajı gösterebilmek için ModelState’e hata ekler.
                //string.Empty    Bu hata herhangi bir input'a ait değil (genel hata)
                //errorContent API’den gelen hata mesajı
                TempData["BookingStatus"] = "error";
                return View(createBookingDto);
            }
        }
    }
}
//ViewBag.location, harita gösterimi için gerekli olduğu için,
//POST başarısız olursa sayfa tekrar yüklendiğinde harita düzgün görünmesi adına
//Contact verisi tekrar sorgulanır.

//✅ Bu, kullanıcıya daha düzgün bir deneyim sunar.
//❌ Ama POST başarılıysa zaten başka sayfaya yönlendiğimiz için bu sorgu gereksiz olur.