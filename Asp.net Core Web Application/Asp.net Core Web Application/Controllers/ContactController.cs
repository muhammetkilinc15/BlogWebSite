using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class ContactController : Controller
	{
		ContactManager manager = new ContactManager(new EfContactRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact c)
		{
			c.ContactTime =DateTime.Parse(DateTime.Now.ToShortDateString());
			c.ContactStatus = true;
			manager.ContactAdd(c);
			// Anlamı Bizi Blog controller içindeki index sayfasına yönlendir
			return RedirectToAction("Index","Blog");
		}
	}
}
