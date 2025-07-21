using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.MenuTableId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7259/api/Product/ProductListWithCategory");
            /*Bu yanıtın içinde:*/  //StatusCode: 200 mü ? 404 mü ?
                                    //Headers : Gelen HTTP header bilgileri
                                    //Content: Gövde(yani esas veri)
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Yani ReadAsStringAsync() yapmazsan, verinin içine erişemezsin, onu sadece dış kabuğuyla tutmuş olursun.
                var productValues = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(productValues);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id ,int Table)
        {
            //id parametresi, menüdeki ürünün id'si
            //Bu id'yi kullanarak, sepete ekleme işlemi yapacağız.
            CreateBasketDto createBasketDto = new CreateBasketDto()
            {
                ProductId = id,
                MenuTableId = Table
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7259/api/Basket", content);

            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7259/api/MenuTable/ChangeMenuTableStatusToTrue?id=" + Table );

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
//🔹 Aynı View içinde veri göstereceksen → ViewBag
//🔹 Redirect sonrası başka Action’da kullanacaksan → TempData

