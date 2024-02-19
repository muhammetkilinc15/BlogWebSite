using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class NewsLetterController : Controller
	{

		NewsLetterManager manager = new NewsLetterManager(new EfNewsLetterRepository());

		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public string SendMail(string Mail)
		{
			NewsLetter newsLetter = new NewsLetter();
			newsLetter.Mail = Mail;
			newsLetter.mailStatus = true;
			manager.AddNewsLetter(newsLetter);
			//Response.Redirect("/Blog/BlogDetails/"+1);
			return "success";
		}
	}
}
