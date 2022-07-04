using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using CoreKamp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
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

        [HttpGet]
        public IActionResult ComposeMessage()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(SendMessageModelView model)
        {
            Message2 message2 = new Message2();
            var reciever = _userManager.FindByEmailAsync(model.Email);

            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            message2.SenderID = writerID;
            message2.ReceiverID = reciever.Id;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.MessageStatus = false;
            message2.Subject = model.Subject;
            message2.MessageDetails = model.Detail;
           
            message2Manager.Add(message2);
            return RedirectToAction("SendBox","AdminMessage");
        }
        public async Task<IActionResult> MessageDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var inboxMessageCount = message2Manager.GetInBoxListByWriter(user.Id).Count();
            var sendMessageCount = message2Manager.GetSendBoxListByWriter(user.Id).Count();
            ViewBag.imc = inboxMessageCount;
            ViewBag.smc = sendMessageCount;

            var value =message2Manager.TGetById(id);
            if (value.MessageStatus == false)
            {
                value.MessageStatus = true;
               message2Manager.Update(value);
            }

            return View(value);
        }
    }
}
