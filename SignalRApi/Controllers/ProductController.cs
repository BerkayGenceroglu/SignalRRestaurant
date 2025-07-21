using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using SSignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //-----------------İSTATİSTİKLER--------------------------//
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
		}
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}
        [HttpGet("ProductPriceAvgHamburger")]
        public IActionResult ProductPriceAvgHamburger()
		{
			return Ok(_productService.TProductAvgPriceHamburger());
		}
        [HttpGet("GetFirst9Products")]
        public IActionResult TGetFirst9Products()
        {
            return Ok(_productService.TGetFirst9Products());
        }
        //------------------------------------------------------------------//
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.TGetProductWithCategories());
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductDto dto)
        {
			_productService.TAdd(_mapper.Map<Product>(dto));
			return Ok("Başarılı Bir Şekilde Eklemiştir");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            _productService.TUpdate(_mapper.Map<Product>(dto));
            return Ok("Başarılı Bir Şekilde Güncellenmiştir");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
    }
}
