using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfMessage2Repository:GenericRepository<Message2>,IMessage2Dal
	{
	

		public List<Message2> GetLInboxWithMessagesByWriter(int id)
		{
			using (var c = new Context())
			{
				// İnclude metotudunu bloglara ait categoryi çekmek için 
				return c.Messages2.Include(x => x.RecieverUser).Where(x => x.SenderID == id).ToList();
			}
		}

		public List<Message2> GetListWithMessagesByWriter(int id)
		{
			using (var c = new Context())
			{
				return c.Messages2.Include(x => x.SenderUser).Where(x => x.RecieverID == id).ToList();
			}
		}

		public List<Message2> GetSendBoxWithMessagesByWriter(int id)
		{
			using(var c = new Context())
			{
				return c.Messages2.Include(x=>x.RecieverUser).Where(x=>x.SenderID == id).ToList();
			}
		}
	}
}
