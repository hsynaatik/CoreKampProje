using CoreKamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreKamp.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass 
            { 
                categoryname = "Teknoloji",
                categorycount = 10 
            });

            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 15
            });

            list.Add(new CategoryClass
            {
                categoryname = "Donanım",
                categorycount = 8
            });

            return Json( new {jsonlist= list });

        }
    }
}
