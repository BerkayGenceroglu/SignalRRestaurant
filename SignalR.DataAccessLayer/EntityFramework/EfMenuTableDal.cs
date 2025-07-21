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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeMenuTableStatustoFalse(int id)
        {
            using SignalRContext context = new SignalRContext();
            var value = context.MenuTables.Where(x => x.MenuTableId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatustoTrue(int id)
        {
            using SignalRContext context = new SignalRContext();
            var value = context.MenuTables.Where(x => x.MenuTableId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public int GetAllMenuTableCount()
		{
            using var context = new SignalRContext();
            return context.MenuTables.Count();  
		}

		public int GetAvailableMenuTableCount()
        {
            using var context = new SignalRContext();
            return context.MenuTables.Where(context => context.Status == false).Count();
        }
    }
}
