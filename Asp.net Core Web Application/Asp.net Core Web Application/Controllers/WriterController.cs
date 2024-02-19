using Asp.net_Core_Web_Application.Models;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        // Authorize nedir : Yetksiz erişimleri engeller. Mesela obs ye şifre ve kullanıcı no girmeden öğrenciye ait sayfa gelmez gibi.
        // Eğer class üzerine yazarsak tüm sınf için authorize çalışır

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        WriterManager manager = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {

            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.name = writerName;
            ViewBag.writerName = writerName;
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult WriterProfile()
        {

            return View();
        }

        [Authorize]
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<IActionResult> WriterEditProfile()
        {
            Context c = new Context();

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.nameSurname = values.NameSurname;
            model.imageUrl = values.ImageUrl;
            model.userName = values.UserName;
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.nameSurname;
            values.ImageUrl = model.imageUrl;
            values.UserName = model.userName;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "Dashboard");

        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newimagename;
            }
            writer.WriterName = p.WriterName;
            writer.WriterPassword = p.WriterPassword;
            writer.WriterAbout = p.WriterAbout;
            writer.WriterMail = p.WriterMail;
            writer.WriterStatus = true;

            manager.TAdd(writer);

            return RedirectToAction("Index", "Dashboard");


        }

    }
}
