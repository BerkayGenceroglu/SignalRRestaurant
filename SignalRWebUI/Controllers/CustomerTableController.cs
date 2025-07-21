using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTableDtos;
using System.Net.Http;

namespace SignalRWebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7259/api/MenuTable");
            /*Bu yanıtın içinde:*/  //StatusCode: 200 mü ? 404 mü ?
                                    //Headers : Gelen HTTP header bilgileri
                                    //Content: Gövde(yani esas veri)
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Yani ReadAsStringAsync() yapmazsan, verinin içine erişemezsin, onu sadece dış kabuğuyla tutmuş olursun.
                var MenuTableValues = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(MenuTableValues);
            }
            return View();
        }
    }
}
