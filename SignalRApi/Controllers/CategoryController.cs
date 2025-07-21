using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;///Bir nesneyi başka bir tipe kolayca dönüştürmek.

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        //---------------------------- İSTATİSTİKLER -----------------------------
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
		}
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}
		[HttpGet("PasiveCategoryCount")]
		public IActionResult PasiveCategoryCount()
		{
			return Ok(_categoryService.TPassiveCategoryCount());
		}

		//---------------------------- İSTATİSTİKLER -----------------------------
		[HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategortDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
		//{id} kısmı, URL’nin o bölümünde bir değer olacağını belirtir.
		//URL’nin sonunda bir id parametresi beklediğini belirtir.
		[HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto dto)
        {
            dto.CategoryStatus = true;
			_categoryService.TAdd(_mapper.Map<Category>(dto));
			return Ok("Başarılı Bir Şekilde Eklemiştir");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            _categoryService.TUpdate(_mapper.Map<Category>(dto));
			return Ok("Başarılı Bir Şekilde Güncellenmiştir");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
            var value = _mapper.Map<List<GetCategoryDto>>(_categoryService.TGetById(id));
            return Ok(value);
        }
    }
}
