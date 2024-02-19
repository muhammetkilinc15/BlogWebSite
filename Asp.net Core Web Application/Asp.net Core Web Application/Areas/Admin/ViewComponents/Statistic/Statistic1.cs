using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.ViewComponents.Statistic
{
	[Area("Admin")]
	public class Statistic1:ViewComponent
	{
		BlogManager manager = new BlogManager(new EfBlogRepository());
		Context c = new Context();
		public IViewComponentResult Invoke()
		{ 
			ViewBag.count = manager.GetList().Count();
			ViewBag.messageNumber = c.Messages2.Count();
			ViewBag.commentNumber = c.Comments.Count();
			return View(); 	
		}

	}
}
