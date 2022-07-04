using CoreKamp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreKamp.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Hüseyin",
                },
                new UserComment
                {
                    ID = 2,
                    UserName="Hasan",
                },
                 new UserComment
                {
                    ID = 3,
                    UserName="Merve",
                },
            };
            return View(commentValues);  
        }
    }
}
