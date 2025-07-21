using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Migrations;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		private readonly SignalRContext _context;
		public EfNotificationDal(SignalRContext context) : base(context)
		{
			_context = context;
		}

		public List<Notification> GetNotificationsByStatusFalse()
		{
			return _context.Notifications.Where(y => y.Status == false).ToList();
		}

		public int NotificationCountByStatusFalse()
		{
			var values = _context.Notifications.Where(x => x.Status == false).Count();
			return values;
		}

		public void NotificationStatusChangeToFalse(int id)
		{
			var value = _context.Notifications.Find(id);
			value.Status = false;
			_context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			var value = _context.Notifications.Find(id);
			value.Status = true;
			_context.SaveChanges();
		}
	}
}
