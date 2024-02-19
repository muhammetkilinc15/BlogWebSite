using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class MessageController : Controller
	{
		Message2Manager manager = new Message2Manager(new EfMessage2Repository());
		Context c = new Context();
		public IActionResult InBox()
		{
		
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = manager.GetListWithMessagesByWriter(writerID);
			return View(values);
		}

		[HttpGet]
		public IActionResult MessageDetails(int id)
		{
			var values = manager.TGetById(id);
			return View(values);
		}

		public IActionResult SendMessage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendMessage(Message2 mesaj,string mail)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			mesaj.SenderID = writerID;
			mesaj.MessageStatus = true;

			var recieverID = c.Writers.Where(x=>x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

			mesaj.RecieverID = recieverID;
			mesaj.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			manager.TAdd(mesaj);
			return RedirectToAction("Inbox");
		}
		public IActionResult SendBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = manager.GetSendBoxListByWriter(writerID);
			return View(values);
		}

		public IActionResult RE()
		{
		return View();
		}

	}
}
