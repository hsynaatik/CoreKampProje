using CoreKamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass wC)
        {
            writers.Add(wC);
            var jsonWriters=JsonConvert.SerializeObject(wC);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer= writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writers);
        }
        public IActionResult UpdateWriter(WriterClass wC)
        {
            var writer = writers.FirstOrDefault(x => x.Id == wC.Id);
            writer.Name=wC.Name;
            var jsonWriter=JsonConvert.SerializeObject(wC);
            return Json(writers);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ayşe"
            },

            new WriterClass
            {
                Id=2,
                Name="Ahmet"
            },
             new WriterClass
            {
                Id=3,
                Name="Hüseyin"
            },
        };
    }
}
