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
	public class MessageManager : IMessageService
	{
		IMessageDal _dal;

		public MessageManager(IMessageDal dal)
		{
			_dal = dal;
		}

		public List<Message> GetInboxByWriter(string mail)
		{
			return _dal.GetListAll(x=>x.Reciever==mail);
		}

		public List<Message> GetList()
		{
			return _dal.GetListAll();
		}

		
		public void TAdd(Message entity)
		{
			_dal.Add(entity);
		}

		public void TDelete(Message entity)
		{
			_dal.Delete(entity);	
		}

		public Message TGetById(int id)
		{

			return _dal.GetByID(id);
		}

		public void TUpdate(Message entity)
		{
			_dal.Update(entity);
		}
	}
}
