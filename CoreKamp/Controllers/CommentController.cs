using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.EntityLayer.Concrete;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 2;
            commentManager.CommentAdd(comment);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values=commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
