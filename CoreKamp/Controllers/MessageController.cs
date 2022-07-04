
using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreKamp.Controllers
{
   
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult InBox()
        {
           
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetInBoxListByWriter(writerID);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = message2Manager.GetSendBoxListByWriter(writerID);
            return View();
        }


        public IActionResult MessageDetails(int id)
        {
            var value=message2Manager.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message2)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            message2.SenderID = writerID;
            message2.ReceiverID = 2;
            message2.MessageStatus = true;
            message2.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.Add(message2);
            return RedirectToAction("InBox");
        }
    }
}
