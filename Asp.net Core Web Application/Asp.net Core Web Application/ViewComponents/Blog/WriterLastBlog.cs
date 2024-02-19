using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListWriter(1);
			return View(values);
		}

			
	}
}
