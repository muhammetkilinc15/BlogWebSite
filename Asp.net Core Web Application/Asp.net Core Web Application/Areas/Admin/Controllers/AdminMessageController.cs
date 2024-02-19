using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.ExtendedProperties;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Context c = new Context();
		Message2Manager manager = new Message2Manager(new EfMessage2Repository());
		public IActionResult GelenKutusu()
        {
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = manager.GetListWithMessagesByWriter(writerID);
			return View(values);
        }

		public IActionResult SendBox()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = manager.GetSendBoxListByWriter(writerID);
			return View(values);
		}

		[HttpGet]
		public IActionResult ComposeMessage()
		{
			return View();
		}

		public IActionResult ComposeMessage(Message2 p,string mail)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			p.SenderID = writerID;
			var recirderID = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
			p.RecieverID = recirderID;
			p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.MessageStatus = true;
			manager.TAdd(p);
			return RedirectToAction("SendBox");
		}

	}
}
