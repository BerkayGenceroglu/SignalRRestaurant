using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using SSignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetFirst9Products()
        {
			using var context = new SignalRContext();
			return context.Products.Take(9).ToList();
        }

        public List<Product> GetProductWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            //Include() metodu, ana tablodaki verilerle birlikte, ilişkili (bağlı) olan diğer tabloların verilerini de çekmeye yarar.
            //Her bir Product nesnesini getirir (yani ürünün adı, fiyatı, stock vs. ne varsa)
            //Ve her ürünle ilişkili Category nesnesini de birlikte getirir
            return values;
        }

		public decimal ProductAvgPriceHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(b => b.CategoryID).FirstOrDefault())).Average(p =>p.Price);
		}

		public int ProductCount()
		{
            using var context = new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(x => x.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(x => x.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNamePotato()
		{
			using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.CategoryName == "Patates").Select(x => x.CategoryID).FirstOrDefault();
			return context.Products.Where(x => x.CategoryID == id).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price==(context.Products.Max(y=>y.Price))).Select(b => b.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(b => b.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
		}
	}
}
