using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreKamp.Controllers
{
    
    public class DashboardController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
       
        public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerId).Count();
            ViewBag.v3 = context.Categories.Count();
            return View();
        }

        public IActionResult Deneme(int id)
        {
            return View();

        }
    }
}
