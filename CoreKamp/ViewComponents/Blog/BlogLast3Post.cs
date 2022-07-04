using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreKamp.ViewComponents.Blog
{
    public class BlogLast3Post:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }
    }
}
