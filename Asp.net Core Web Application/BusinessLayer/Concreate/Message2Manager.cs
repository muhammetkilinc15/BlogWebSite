using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
	public class Message2Manager : IMessage2Service
	{
		IMessage2Dal _dal;
		public Message2Manager(IMessage2Dal _dal)
		{
			this._dal = _dal;
		}


		public List<Message2> GetList()
		{
			return _dal.GetListAll();
		}

		public void TAdd(Message2 entity)
		{
			_dal.Add(entity);
		}

		public void TDelete(Message2 entity)
		{
			_dal.Delete(entity);
		}

		public Message2 TGetById(int id)
		{
			return _dal.GetByID(id);
		}

		public void TUpdate(Message2 entity)
		{
			_dal.Update(entity);
		}
		

		public List<Message2> GetSendBoxListByWriter(int id)
		{
			return _dal.GetSendBoxWithMessagesByWriter(id);
		}

		public List<Message2> GetListWithMessagesByWriter(int id)
		{
			return _dal.GetListWithMessagesByWriter(id);
		}

		public List<Message2> GetInboxBoxListByWriter(int id)
		{
			return _dal.GetLInboxWithMessagesByWriter(id);
		}
	}
}
