using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
	
	
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
