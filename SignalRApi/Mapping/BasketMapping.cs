using AutoMapper;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRApi.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
        }
    }
}
