using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.ViewComponents.Writer
{
    public class WriterNotifications : ViewComponent
    {
        NotificationManager manager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = manager.GetList();
            return View(values);
        }
    }
}
