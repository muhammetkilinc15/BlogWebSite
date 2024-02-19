using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Writer
{
	public class WriterMessagesNotification : ViewComponent
	{
		Message2Manager manager = new Message2Manager(new EfMessage2Repository());

		public IViewComponentResult Invoke()
		{
			Context c = new Context();
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = manager.GetListWithMessagesByWriter(writerID);
			ViewBag.count = values.Where(x=>x.MessageStatus==true).Count();
			return View(values);
		}

	}
}
