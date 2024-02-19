using Asp.net_Core_Web_Application.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Writerlist()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int id)
        {
            var findWriter = writers.FirstOrDefault(x=>x.ID == id);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.ID==id);
            writers.Remove(writer);

            return Json(writer);
        }
        [HttpPost]
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x=>x.ID==w.ID);
            writer.Name= w.Name;
            var jsonwriter = JsonConvert.SerializeObject(writer);
            return Json(jsonwriter);
        }


        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                ID = 1,
                Name="Mehmet"
            },
             new WriterClass
            {
                ID = 2,
                Name="Ahmet"
            }
             , new WriterClass
            {
                ID = 3,
                Name="Osman"
            }

        };

    }
}
