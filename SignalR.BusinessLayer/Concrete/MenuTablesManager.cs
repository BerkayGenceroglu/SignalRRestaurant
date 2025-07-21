using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MenuTablesManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTablesManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void TAdd(MenuTable entity)
        {
            _menuTableDal.Add(entity);
		}

        public void TChangeMenuTableStatustoFalse(int id)
        {
            _menuTableDal.ChangeMenuTableStatustoFalse(id);
        }

        public void TChangeMenuTableStatustoTrue(int id)
        {
            _menuTableDal.ChangeMenuTableStatustoTrue(id);
        }

        public void TDelete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);
		}

		public int TGetAllMenuTableCount()
		{
			return _menuTableDal.GetAllMenuTableCount();
		}

		public int TGetAvailableMenuTableCount()
        {
            return _menuTableDal.GetAvailableMenuTableCount();
        }

        public MenuTable TGetById(int id)
        {
			return _menuTableDal.GetById(id);
		}

        public List<MenuTable> TGetListAll()
        {
            return _menuTableDal.GetListAll();
		}

        public void TUpdate(MenuTable entity)
        {
			_menuTableDal.Update(entity);
		}
    }
}
