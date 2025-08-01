﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7259/api/Discount");
			/*Bu yanıtın içinde:*/  //StatusCode: 200 mü ? 404 mü ?
									//Headers : Gelen HTTP header bilgileri
									//Content: Gövde(yani esas veri)
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				//Yani ReadAsStringAsync() yapmazsan, verinin içine erişemezsin, onu sadece dış kabuğuyla tutmuş olursun.
				var discountValues = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
				return View(discountValues);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//StringContent   JSON, XML, düz metin gibi verileri göndermek için
			var responseMessage = await client.PostAsync("https://localhost:7259/api/Discount", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7259/api/Discount?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7259/api/Discount/GetDiscount?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var discountValues = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
				return View(discountValues);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7259/api/Discount", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> ChangeStatusToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7259/api/Discount/ChangeStatusToTrue?id={id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> ChangeStatusToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7259/api/Discount/ChangeStatusToFalse?id={id}");
			return RedirectToAction("Index");
		}

	}
}
