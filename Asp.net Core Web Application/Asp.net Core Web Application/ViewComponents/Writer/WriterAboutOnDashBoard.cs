using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Writer
{
	public class WriterAboutOnDashBoard : ViewComponent
	{

		WriterManager manager = new WriterManager(new EfWriterRepository());
		public  IViewComponentResult Invoke(int? id)
		{
			var username = User.Identity.Name;
			ViewBag.v = username;
			
			Context c = new Context();
			var usermail = c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();

			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

			var values = manager.GetWriterById(writerID);

			return View(values);
		}

	}
}
