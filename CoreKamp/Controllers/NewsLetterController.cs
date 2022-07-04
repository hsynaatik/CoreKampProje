using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
       
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());


        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetters newsLetters)
        {
            newsLetters.MailStatus = true;
            nm.AddNewsLetter(newsLetters);   
            return PartialView();
        }
    }
}
