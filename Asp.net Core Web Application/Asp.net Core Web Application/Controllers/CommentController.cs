using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class CommentController : Controller
	{
		CommentManager manager = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			return View();
		}

		
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}

		[HttpPost]
		public string SenComment(string name,string title,string comment)
		{
			Comment c= new Comment();
			c.CommentUserName="Tarkan";
			c.CommentTitle="Banane A";
			c.CommentContent=comment;
			c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.BlogID = 2;
			manager.TAdd(c);
			return "success for the comment";

		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = manager.getCommentListWithCategory(id);
			return PartialView(values);
		}
	}
}
