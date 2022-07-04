using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreKamp.Areas.Admin.ViewComponents.Statistic
{
    
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogManager.GetList().Count();
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();

            string api = "2fe56a31e597d92e969ddd7e3bf20fcb";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=d%C3%BCzce&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
