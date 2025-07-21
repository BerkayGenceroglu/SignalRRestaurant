using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPost]
        public IActionResult AddDiscount(CreateDiscountDto dto)
        {
            dto.Status = false; // Default status set to false
			_discountService.TAdd(_mapper.Map<Discount>(dto)); // Map DTO to Entity
			return Ok("Başarılı Bir Şekilde Eklemiştir");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            dto.Status = false; // Ensure status is set to false during update
			_discountService.TUpdate(_mapper.Map<Discount>(dto)); // Map DTO to Entity
			return Ok("Başarılı Bir Şekilde Güncellenmiştir");
        }

		[HttpGet("ChangeStatusToTrue")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Status True Olarak Güncellenmiştir");
		}

		[HttpGet("ChangeStatusToFalse")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Status False Olarak Güncellenmiştir");
		}
		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue(int id)
		{
            return Ok(_discountService.TGetListByStatusTrue());
		}
	}
}
