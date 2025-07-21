using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}
		//---------------İstatistikler-------------------
		[HttpGet(" GetAvailableMenuTableCount")]
        public IActionResult GetAvailableMenuTableCount()
        {
            return Ok(_menuTableService.TGetAvailableMenuTableCount());
        }
        [HttpGet(" GetAllMenuTableCount")]
		public IActionResult GetAllMenuTableCount()
		{
			return Ok(_menuTableService.TGetAllMenuTableCount());
		}
		//---------------İstatistikler-------------------
		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
			return Ok(values);
		}
		[HttpDelete]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Başarılı Bir Şekilde Silinmiştir");
		}
		[HttpPost]
		public IActionResult AddMenuTable(CreateMenuTableDto dto)
		{
			dto.Status = false; // Default status set to false
			_menuTableService.TAdd(_mapper.Map<MenuTable>(dto)); 
			return Ok("Başarılı Bir Şekilde Eklemiştir");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto dto)
		{
			_menuTableService.TUpdate(_mapper.Map<MenuTable>(dto));
			return Ok("Başarılı Bir Şekilde Güncellenmiştir");
		}
		[HttpGet("GetMenuTable")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}
        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
			_menuTableService.TChangeMenuTableStatustoTrue(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatustoFalse(id);
            return Ok("İşlem Başarılı");
        }
    }
}
