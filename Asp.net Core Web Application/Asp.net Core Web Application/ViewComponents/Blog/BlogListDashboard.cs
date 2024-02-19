using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Blog
{
	public class BlogListDashboard:ViewComponent
	{
		BlogManager manager = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = manager.getBlogListWithCategory();
			return View(values);
		}
	}
}
