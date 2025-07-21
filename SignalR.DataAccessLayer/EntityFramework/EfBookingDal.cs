using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
		private readonly SignalRContext _context;
		public EfBookingDal(SignalRContext context) : base(context)
        {
			_context = context;	
		}

		public void BookingStatusApproved(int id)
		{
			var value =_context.Bookings.Find(id);
			value.Description = "Rezervasyon Onaylandı";
			_context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			var value = _context.Bookings.Find(id);
			value.Description = "Rezervasyon İptal Edildi";
			_context.SaveChanges();
		}
	}

}
