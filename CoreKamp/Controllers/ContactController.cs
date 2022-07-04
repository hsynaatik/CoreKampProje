using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.BusinessLayer.ValidationRules;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreKamp.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ContactValidator contactValidator = new ContactValidator();
            ValidationResult result = contactValidator.Validate(contact);

            if (result.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contact.ContactStatus = true;
                contactManager.ContactAdd(contact);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
