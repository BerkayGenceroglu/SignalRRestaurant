using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult Addessage(CreateMessageDto dto)
		{
			dto.MessageSendDate = DateTime.Now;
			dto.Status = false;
			_messageService.TAdd(_mapper.Map<Message>(dto));
			return Ok("Message Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Message Başarılı Bir Şekilde Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto dto)
		{
			dto.Status = false; // Ensure status is set to false during update
			_messageService.TUpdate(_mapper.Map<Message>(dto));
			return Ok("Message Başarılı Bir Şekilde Güncellendi");
		}
		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(_mapper.Map<ResultMessageDto>(value));
		}
	}
}
