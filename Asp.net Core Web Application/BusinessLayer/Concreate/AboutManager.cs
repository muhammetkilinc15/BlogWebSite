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
	public class AboutManager:IAboutService
	{
		IAboutDal _dal;

		public AboutManager(IAboutDal dal)
		{
			_dal = dal;
		}

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
		{
			return _dal.GetListAll();
		}

        public void TAdd(About entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(About entity)
        {
           _dal.Delete(entity); 
        }

        public void TUpdate(About entity)
        {
            _dal.Update(entity);
        }
    }
}
