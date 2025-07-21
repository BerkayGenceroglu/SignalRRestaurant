using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.Notification;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetListNotifications()
		{
			return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
			//📬 Ok(values) dediğinde, o veriler otomatik olarak bu isteği yapan tarayıcıya gönderilir.
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetNotificationsByStatusFalse")]
		public IActionResult GetNotificationsByStatusFalse()
		{
			return Ok(_notificationService.TGetNotificationsByStatusFalse());
		}
		[HttpDelete]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Silme İşlemi Başarılı");
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto dto)
		{
			dto.Status = false; // Varsayılan olarak false olarak ayarlanıyor
			_notificationService.TAdd(_mapper.Map<Notification>(dto));
			return Ok("Bildirim Oluşturuldu");
		}
		[HttpGet("GetNotification")]
		public IActionResult UpdateNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(_mapper.Map<GetNotificationDto>(value));
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			_notificationService.TUpdate(_mapper.Map<Notification>(updateNotificationDto));
			return Ok("Bildirim Güncellendi");
		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Bildirim Durumu True Olarak Güncellendi");
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Bildirim Durumu False Olarak Güncellendi");
		}
	}
}
//Ok(...) = “Tarayıcıya bu veriyi gönder!” sonuç başarılı ise 200 döner