using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminBlogController : Controller
	{
		BlogManager manager = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			var values = manager.getBlogListWithCategory();
			return View(values);
		}
	}
}
