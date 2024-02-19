using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class AboutController : Controller
	{
		AboutManager manager= new AboutManager(new EfAboutRepository()	);
		public IActionResult Index()
		{
			var values = manager.GetList();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
}
