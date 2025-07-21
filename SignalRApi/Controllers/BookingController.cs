using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        //“Ben CreateBookingDto tipi için validasyon kurallarını barındıran bir yapı sunuyorum.” = İnterface
        //CreateBookingValidation sınıfı → Bu arayüzü gerçekleştiriyor=Class




        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            return Ok(_mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult AddBooking(CreateBookingDto dto)
        {
            var validationResult= _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
                //İstek hatalı, sistem kabul etmez
                //(HTTP 400)Hangi alanlarda hata var, onu verir"
            }
            _bookingService.TAdd(_mapper.Map<Booking>(dto));
            return Ok("Rezervasyon Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            _bookingService.TUpdate(_mapper.Map<Booking>(dto));
            return Ok("Rezervasyon Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_mapper.Map<GetBookingDto>(_bookingService.TGetById(id)));
        }
        [HttpGet("BookingStatusApproved")]
        public IActionResult BookingStatusApproved(int id) 
        { 
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
		}
		[HttpGet("BookingStatusCancelled")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.TBookingStatusCancelled(id);
			return Ok("Rezervasyon İptal Edildi");
		}
	}
}
