using Asp.net_Core_Web_Application.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categorycount = 10,
                categoryname = "Teknolloji"
            });

            list.Add(new CategoryClass
            {
                categorycount = 14,
                categoryname = "Yazılım"
            });

            list.Add(new CategoryClass
            {
                categorycount = 5,
                categoryname = "spor"
            });

            list.Add(new CategoryClass
            {
                categorycount = 25,
                categoryname = "Laptop"
            });

            return Json(new { jsonlist = list });
        }
    }
}
