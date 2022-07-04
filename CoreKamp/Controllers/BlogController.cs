using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.BusinessLayer.ValidationRules;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{

    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

       
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.TGetByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();        
            var values= bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }

        [HttpGet]  
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
           
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;
                bm.Add(blog);

                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue=bm.TGetById(id);
            bm.Delete(blogValue);
            return RedirectToAction("BlogListByWriter");

        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue= bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            blog.WriterID=writerID;
            blog.BlogCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
