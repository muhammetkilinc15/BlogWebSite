using Asp.net_Core_Web_Application.Controllers;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.BlogLast3Post
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager manager = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = manager.GetLast3Blog();
			return View(values);
		}
	}
}
