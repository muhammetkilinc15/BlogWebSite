using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
	public class AdminManager:IAdminService
	{
		IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}

		public List<Admin> GetList()
		{
			return _adminDal.GetListAll();
		}

		public void TAdd(Admin entity)
		{
			_adminDal.Add(entity);
		}

		public void TDelete(Admin entity)
		{
			_adminDal.Delete(entity);
		}

		public Admin TGetById(int id)
		{
			return _adminDal.GetByID(id);
		}

		public void TUpdate(Admin entity)
		{
			_adminDal.Update(entity);	
		}
	}
}
