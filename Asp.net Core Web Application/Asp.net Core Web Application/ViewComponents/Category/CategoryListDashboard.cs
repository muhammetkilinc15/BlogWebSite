using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Category
{
	public class CategoryListDashboard:ViewComponent
	{
		CategoryManager manager = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = manager.GetList();
			return View(values);
		}
	}
}
