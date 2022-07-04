using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var values = commentManager.GetCommentWithBlog().ToPagedList(page, 20);
            return View(values);
        }

        [HttpPost]
        public IActionResult DeleteComment(int id)
        {

            var value = commentManager.TGetById(id);
            if (value.IsDelete)
            {
                value.IsDelete = false;
            }
            else
            {
                value.IsDelete = true;
            }
            commentManager.Update(value);
            return View();
        }
    }
}
