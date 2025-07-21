using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7259/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var productValues=JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(productValues);
            }
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7259/api/Category");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var categoryValues = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> categoryList = (from x in categoryValues
												select new SelectListItem
												{
													Value = x.CategoryID.ToString(),
													Text = x.CategoryName
												}).ToList();
			ViewBag.mycategoryList = categoryList;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
		{
			productDto.ProductStatus = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(productDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7259/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
			return View();
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7259/api/Product?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage2 = await client.GetAsync("https://localhost:7259/api/Category");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			var categoryValues2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
			List<SelectListItem> categoryList2 = (from x in categoryValues2
												  select new SelectListItem
												 {
													 Value = x.CategoryID.ToString(),
													 Text = x.CategoryName
												 }).ToList();
			ViewBag.mycategoryList = categoryList2;
			//----------------------------------------------
			var responseMessage=await client.GetAsync($"https://localhost:7259/api/Product/GetProduct?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var productValues=JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(productValues);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
		{
			productDto.ProductStatus = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(productDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7259/api/Product",content);
            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
			return View();
		}
	}
}
