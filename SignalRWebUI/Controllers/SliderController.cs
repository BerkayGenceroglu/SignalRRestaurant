using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using SignalRWebUI.Dtos;
using SignalRWebUI.Dtos.SliderrDtos;

namespace SignalRWebUI.Controllers
{
	public class SliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7259/api/Slider");
			/*Bu yanıtın içinde:*/  //StatusCode: 200 mü ? 404 mü ?
									//Headers : Gelen HTTP header bilgileri
									//Content: Gövde(yani esas veri)
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				//Yani ReadAsStringAsync() yapmazsan, verinin içine erişemezsin, onu sadece dış kabuğuyla tutmuş olursun.
				var SliderValues = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(SliderValues);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSliderDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//StringContent   JSON, XML, düz metin gibi verileri göndermek için
			var responseMessage = await client.PostAsync("https://localhost:7259/api/Slider", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7259/api/Slider?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7259/api/Slider/GetSlider?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var SliderValues = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
				return View(SliderValues);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSliderDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7259/api/Slider", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
