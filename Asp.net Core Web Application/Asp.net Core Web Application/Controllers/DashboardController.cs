using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.wwwroot
{
	public class DashboardController : Controller
	{
		BlogManager manager = new BlogManager(new EfBlogRepository());

		public IActionResult Index()
		{
			Context c = new Context();
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x=>x.UserName == username).Select(y=>y.Email).FirstOrDefault();
			int count = manager.GetList().Count;
			var writerID = c.Writers.Where(x=>x.WriterMail == usermail).Select(x=>x.WriterID).FirstOrDefault();
			
			ViewBag.TotalBlogCount = count.ToString();
			ViewBag.WriterBlogCount =c.Blogs.Where(x=>x.WriterID==writerID).Count().ToString();

			ViewBag.categoriesCount = c.Categories.Count().ToString();
			return View();
		}
	}
}
