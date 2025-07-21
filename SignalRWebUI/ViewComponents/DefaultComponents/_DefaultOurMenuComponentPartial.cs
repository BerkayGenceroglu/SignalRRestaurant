using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7259/api/Product/GetFirst9Products");
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
    }
}
