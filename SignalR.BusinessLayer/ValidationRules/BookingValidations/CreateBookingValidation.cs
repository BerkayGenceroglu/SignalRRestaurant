using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    //FluentValidation kütüphanesinde kullanılan bir temel (base) sınıftır.
    //Senin CreateBookingDto gibi bir sınıfın varsa, o sınıfa ait doğrulama kurallarını tanımlamak için AbstractValidator<T>'den kalıtım (inheritance) alırsın.	Hangi özellik için kural yazmak istiyorsan(Rulefor)
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Numara Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısı Boş Geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Boş Geçilemez");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("En az 5 Karakterli Veri Girişi Yapmanız Gerekmektedir").MaximumLength(50).WithMessage("En Fazla 50 Karakterli Veri Girişi Yapmanız Gerekmektedir");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("En Fazla 300 Karakterli Veri Girişi Yapmanız Gerekmektedir").MinimumLength(10).WithMessage("En az 5 Karakterli Veri Girişi Yapmanız Gerekmektedir");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli Bir E-Mail Adresi Giriniz");
        }
    }
}
