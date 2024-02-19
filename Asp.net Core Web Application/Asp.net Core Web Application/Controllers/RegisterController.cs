using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer w)
		{
			WriterValidator writerVld = new WriterValidator();

			ValidationResult result = writerVld.Validate(w);

			if (result.IsValid)
			{
				w.WriterStatus = true;
				w.WriterAbout = "Deneme Test";
				writerManager.TAdd(w);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					ViewBag.err = item.ErrorMessage;
				}
			}

			return View();
		}
	}
}
