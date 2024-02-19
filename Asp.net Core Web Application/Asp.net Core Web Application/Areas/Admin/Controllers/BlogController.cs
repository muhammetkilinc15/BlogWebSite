using Asp.net_Core_Web_Application.Areas.Admin.Models;
using BusinessLayer.Concreate;
using ClosedXML.Excel;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = " Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;

                foreach(var item in GetBlogList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.ID;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogAdı;
                    blogRowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {

            List<BlogModel> newList = new List<BlogModel>
            {
                new BlogModel {ID=1,BlogAdı="Test1"},
                new BlogModel {ID=2,BlogAdı="Test2"},
                new BlogModel {ID=3,BlogAdı="Test3"},
            };
            return newList;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = " Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;

                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.ID;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }

        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> list = new List<BlogModel2>();
            using (var c = new Context())
            {
                list = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return list;
        }
    }
}
