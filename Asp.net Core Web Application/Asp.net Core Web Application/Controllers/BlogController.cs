using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Asp.net_Core_Web_Application.Controllers
{
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		Context c = new Context();
		public IActionResult Index()
		{
			var values = bm.getBlogListWithCategory();
			return View(values);
		}

		public IActionResult BLogDetails(int id)
		{
			ViewBag.Id = id;
			var values = bm.GetBlogById(id);
			return View(values);
		}
		[AllowAnonymous]
		public IActionResult BlogListByWriter()
		{
			Context c = new Context();
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = bm.GetBlogListWithByWriterBM(writerID);
			return View(values);
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult BlogAdd()
		{

			CategoryManager cm = new CategoryManager(new EfCategoryRepository());
			List<SelectListItem> values = (from x in cm.GetList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString()
										   }).ToList();
			ViewBag.cv = values;
			return View();
		}

		[HttpPost]
		public IActionResult BlogAdd(Blog newBLog)
		{
			// Bu şekilde de id ye ulaşılabilir
			//var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
			Context c = new Context();
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(y => y.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();


			BlogValidator validator = new BlogValidator();
			ValidationResult result = validator.Validate(newBLog);
			if (result.IsValid)
			{
				newBLog.BlogStatus = true;
				newBLog.WriterID = writerID;
				newBLog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortTimeString()).ToString();
				bm.TAdd(newBLog);
				return RedirectToAction("BlogListByWriter", "Blog");
			}

			return View();
		}
		public IActionResult DeleteBlog(int id)
		{
			var value = bm.TGetById(id);
			bm.TDelete(value);
			return RedirectToAction("BlogListByWriter", "Blog");
		}

		[HttpGet]
		public IActionResult UpdateBlog(int id)
		{
			var usermail = User.Identity.Name;
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			CategoryManager cm = new CategoryManager(new EfCategoryRepository());
			List<SelectListItem> values = (from x in cm.GetList()
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString()
										   }).ToList();
			ViewBag.cv = values;
			Blog value = bm.TGetById(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateBlog(int id, Blog p)
		{
			var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			Blog updatedBlog = bm.TGetById(id);
			updatedBlog.WriterID =int.Parse( writerID);
			updatedBlog.BlogContent = p.BlogContent;
			updatedBlog.BlogTitle = p.BlogTitle;
			updatedBlog.BlogImage = p.BlogImage;
			updatedBlog.BlogThumbnailImage = p.BlogThumbnailImage;
			updatedBlog.Category = p.Category;
			bm.TUpdate(updatedBlog);
			return RedirectToAction("BlogListByWriter", "Blog");
		}
	}
}
