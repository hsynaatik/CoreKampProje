using ClosedXML.Excel;
using CoreKamp.Areas.Admin.Models;
using CoreKamp.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.ID;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-" +
                        "officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogManager = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel{ID=2,BlogName="Tesla Firması Araçları"},
                new BlogModel{ID=3,BlogName="2022 Olimpiyatları"}
            };
            return blogManager;

        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.ID;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-" +
                        "officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel2>BlogTitleList()
        {
            List<BlogModel2> blogManager = new List<BlogModel2>();
            using(var context=new Context())
            {
                blogManager=context.Blogs.Select(x=>new BlogModel2
                {
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return blogManager;

        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
