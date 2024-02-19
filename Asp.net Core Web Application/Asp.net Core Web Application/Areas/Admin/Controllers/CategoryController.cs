using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		CategoryManager manager =  new CategoryManager(new EfCategoryRepository());
		
		public IActionResult Index(int page=1)
		{
			// Topagelist() ilk paramatresi kaç sayfalı olsu, 2. değer her sayfada kaç tane değer olsun diye sorulur
			var values = manager.GetList().ToPagedList(page,3);
			return View(values);
		}
		public IActionResult AddCategory()
		{
			return View();	
		}

		[HttpPost]
		public IActionResult AddCategory(Category p)
		{
			CategoryValidator validator = new CategoryValidator();
			ValidationResult result = validator.Validate(p);
			if (result.IsValid)
			{
				p.CategoryStatus = true;
				manager.TAdd(p);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}

		public IActionResult DeleteCategory(int id)
		{
			Category c = manager.TGetById(id);
			c.CategoryStatus = false;
			manager.TUpdate(c);
			return RedirectToAction("Index","Category");
		}
	}
}
