using Asp.net_Core_Web_Application.Models;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Asp.net_Core_Web_Application.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		// AllowAnonymous : TÜm kuralları devre dısa bırakıp ekrana gözükecek :D
		private readonly SignInManager<AppUser> _singInManager;

		public LoginController(SignInManager<AppUser> singInManager)
		{
			_singInManager = singInManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignIn user)
		{

			if (ModelState.IsValid)
			{
				var result = await _singInManager.PasswordSignInAsync(user.username, user.password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await _singInManager.SignOutAsync();
			return RedirectToAction("Index","Login");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}

    }
}
