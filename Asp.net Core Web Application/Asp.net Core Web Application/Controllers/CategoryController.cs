using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager= new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            List<Category> values = categoryManager.GetList();
            return View(values);
        }
    }
}
