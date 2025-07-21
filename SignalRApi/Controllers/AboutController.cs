using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}
		[HttpGet]
        public IActionResult AboutList()
        {
            return Ok(_mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll()));
			//Dto ile entityclassından gerekli olan verileri alıyoruz bunları manuel eşleme yapmak yerine mapper ile tanımlıyoruz sonra _mapper diyerek bunu buna dönüştür diyoruz
		}
        [HttpPost]
        public IActionResult AddAbout(CreateAboutDto dto)
        {
			_aboutService.TAdd(_mapper.Map<About>(dto));
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id) 
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            var value = _mapper.Map<About>(dto);
            _aboutService.TUpdate(value);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            return Ok(_mapper.Map<GetAboutDto>(_aboutService.TGetById(id)));
        }
    }
}
