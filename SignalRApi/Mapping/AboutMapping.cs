using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;
using System;

namespace SignalRApi.Mapping
{
    public class AboutMapping:Profile
    {
        //Çok katmanlı mimaride "mapping" kavramı, basitçe bir katmandaki verinin veya nesnenin başka bir katmandaki veri veya nesneye dönüştürülmesi işlemidir. 
        public AboutMapping()
        {
            //Veritabanındaki About isimli tabloyu, 4 farklı amaç için oluşturduğun DTO sınıflarına dönüştürüyor.
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
        //AutoMapper bu sınıfı başlatırken mapping kurallarını otomatik olarak çalıştırabilsin diye.
        //Benim içimdeki eşleştirmeleri constructor çalışınca yükle.
    }
}
