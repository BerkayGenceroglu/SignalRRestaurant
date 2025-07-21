using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
    //DTO (Data Transfer Object), yazılım geliştirme sürecinde kullanılan bir tasarım desenidir. Ana amacı, veriyi bir katmandan başka bir katmana taşırken sadece gerekli olan bilgileri içeren basit nesneler kullanmaktır.
    public class ResultAboutDto
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
