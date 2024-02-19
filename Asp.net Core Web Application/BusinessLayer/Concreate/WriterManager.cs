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
	public class WriterManager : IWriterService
	{
		IWriterdal _writerDal;

		public WriterManager(IWriterdal writerDal)
		{
			_writerDal = writerDal;
		}

		//public void AddWriter(Writer writer)
		//{
		//	_writerDal.Add(writer);
		//}

		public List<Writer> GetList()
		{
			return _writerDal.GetListAll();
		}

		public List<Writer> GetWriterById(int id)
		{
			return _writerDal.GetListAll(X=>X.WriterID == id);
		}

		public void TAdd(Writer entity)
		{
			_writerDal.Add(entity);
		}

		public void TDelete(Writer entity)
		{
			_writerDal.Delete(entity);
		}

		public Writer TGetById(int id)
		{
			return _writerDal.GetByID(id);	
		}

		public void TUpdate(Writer entity)
		{
			_writerDal.Update(entity);
		}
	}
}
