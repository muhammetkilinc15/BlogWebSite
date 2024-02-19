using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
