using AutoMapper;
using SignalR.DtoLayer.Notification;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class NotificationMapping:Profile
	{
		public NotificationMapping()
		{
			//Veritabanındaki About isimli tabloyu, 4 farklı amaç için oluşturduğun DTO sınıflarına dönüştürüyor.
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, GetNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
		}
	}
}
