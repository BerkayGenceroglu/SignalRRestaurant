using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Başarılı Bir Şekilde Silinmiştir");
        }
        [HttpPost]
        public IActionResult AddContact(CreateContactDto dto)
        {
          _contactService.TAdd(_mapper.Map<Contact>(dto));
            return Ok("Başarılı Bir Şekilde Eklemiştir");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
           _contactService.TUpdate(_mapper.Map<Contact>(dto));
			return Ok("Başarılı Bir Şekilde Güncellenmiştir");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}
// verinin kendisini değil, verinin temsil şeklini değiştiriyoruz.
//Sınıf değişir: Birinde sadece birkaç alan varken, diğerinde belki 10 alan vardır.
//Temsil şekli değişir: Bu da katmanlar arasında temizlik, güvenlik ve performans sağlar.