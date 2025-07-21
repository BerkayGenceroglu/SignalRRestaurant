using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.MessageDtos;
using System.Runtime.CompilerServices;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

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
		[HttpGet] 
		public async Task<PartialViewResult> SendMessage()
		{
            return PartialView();
		}
		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMessageDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//StringContent   JSON, XML, düz metin gibi verileri göndermek için
			var responseMessage = await client.PostAsync("https://localhost:7259/api/Message", content);
			if (responseMessage.IsSuccessStatusCode)
            {
                TempData["MessageStatus"] = "Success";
                return RedirectToAction("Index");
			}
            TempData["MessageStatus"] = "Error";
            return View("Index");
        }
	}
}
//ViewBag aynı View içinde kullanılırsa	✅ Evet, geçerli
//PartialViewResult döndüren method ViewBag atarsa	❌ Hayır, üst View’da kullanılamaz
//PartialView kendi içinde ViewBag’i kullanırsa	✅ Evet, o Partial içinde çalışır