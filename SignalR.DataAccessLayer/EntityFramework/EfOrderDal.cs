﻿using SignalR.DataAccessLayer.Abstract;
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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.Description== "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(b=>b.TotalPrice).FirstOrDefault();
		}

        public decimal TodayTotalPrice()
        {
			using var context = new SignalRContext();
            DateTime today = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
			return context.Orders.Where(x => x.Date == today && x.Description =="Hesap Ödendi").Sum(x => x.TotalPrice);
        }

        public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
