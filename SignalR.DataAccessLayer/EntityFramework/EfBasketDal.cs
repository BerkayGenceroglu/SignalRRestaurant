using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
            //Bir sınıf, başka bir sınıftan miras alıyorsa (örneğin EfBasketDal : GenericRepository<Basket>), üst sınıfın (base class) constructor’ı parametre alıyorsa, alt sınıf (türetilmiş sınıf) bu parametreyi base(...) ifadesiyle iletmek zorundadır.
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(y=> y.Product).Where(x => x.MenuTableId == id).ToList();
            return values;
        }
    }
}
