using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRApi.Mapping
{
	public class MenuTableMapping : Profile
	{
		public MenuTableMapping()
		{
			CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
		}
	}
}
