using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;
using SSignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPost]
        public IActionResult AddTestimonial(CreateTestimonialDto dto)
        {
            _testimonialService.TAdd(_mapper.Map<Testimonial>(dto));
			return Ok("Başarılı Bir Şekilde Eklemiştir");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto dto)
        {
           _testimonialService.TUpdate(_mapper.Map<Testimonial>(dto));
			return Ok("Başarılı Bir Şekilde Güncellenmiştir");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));
        }
    }
}
