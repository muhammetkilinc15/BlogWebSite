using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminCommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			var values = commentManager.GetCommentListWithBlog();
			return View(values);
		}
	}
}
