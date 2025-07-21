using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            //id değerini TempData'da saklıyoruz, böylece diğer sayfalarda kullanabiliriz.
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7259/api/Basket/BasketListByMenuTablewithProductName?id="+ id);
            /*Bu yanıtın içinde:*/  //StatusCode: 200 mü ? 404 mü ?
                                    //Headers : Gelen HTTP header bilgileri
                                    //Content: Gövde(yani esas veri)
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Yani ReadAsStringAsync() yapmazsan, verinin içine erişemezsin, onu sadece dış kabuğuyla tutmuş olursun.
                var Values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(Values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteProductbyBasket(int id)
        {
            int tableId =int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7259/api/Basket?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new {id = tableId});
            }
            return NoContent();
        }
    }
}
//[HttpGet("{id}")]
//public IActionResult GetBasketById(int id)
//👉 URL'deki /5 → id = 5 olarak gelir.
// URL: /api/Basket?id=5
//[HttpGet]
//public IActionResult GetBasketById(int id)
//👉 URL'deki ?id=5 → id = 5 olarak gelir.