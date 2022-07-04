﻿using CoreKamp.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreKamp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {

            ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.v3 = context.Comments.Count();
            return View();
        }
    }
}
