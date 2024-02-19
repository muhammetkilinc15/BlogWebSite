using Asp.net_Core_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asp.net_Core_Web_Application.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        
    }
}
