using DataAccessLayer.Concreate;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.ViewComponents.Statistic
{
	[Area("Admin")]
	public class Statistic2:ViewComponent
	{
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.lasBlogName = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault().ToString();
			return View();
		}
	}
}
