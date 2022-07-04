using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.BusinessLayer.ValidationRules;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using CoreKamp.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Controllers
{
   
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        public WriterController(UserManager<AppUser> signInManager)
        {
            _userManager = signInManager;
        }


       
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.V = userMail;
            Context context = new Context();
            var writerName= context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;

            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

       
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WrtierNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WrtierFooterPartial()
        {
            return PartialView();
        }

       
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values =await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }

      
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
           var values=await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl=model.imageurl;
            values.UserName = model.username;
            values.PasswordHash=_userManager.PasswordHasher.HashPassword(values,model.password);
            var result=await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

        [AllowAnonymous]
        [HttpGet]

        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]

        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer w8 = new Writer();
            if (writer.WriterImage!=null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",
                    newImageName);
                var stream=new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                w8.WriterImage = newImageName;
            }
            w8.WriterMail = writer.WriterMail;
            w8.WriterName=writer.WriterName;
            w8.WriterPassword= writer.WriterPassword;
            w8.WriterStatus = true;
            w8.WriterAbout= writer.WriterAbout;
            writerManager.Add(w8);
           
            return RedirectToAction("Index","Dashboard");
        }

    }
}
