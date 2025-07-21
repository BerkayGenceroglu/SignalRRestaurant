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
        //Hem GenericRepository<About>'un sunduğu tüm hazır metotları kullanır,
        //Hem de IAboutDal arayüzünün sözleşmesini uygular.
	public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
		//EfAboutDal, GenericRepository<About>'tan türediği için:
		//Add, Delete, Update, GetById, GetAll gibi metotlar otomatik gelir.
		//Bunları isterse override edebilirsin, gerekirse direkt kullanırsın.
		//Generic sınıfta constructor varsa ve parametre alıyorsa, o constructor’ı alt sınıfta kullanmak için base(...) kullanman gerekir.
		public EfAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}
