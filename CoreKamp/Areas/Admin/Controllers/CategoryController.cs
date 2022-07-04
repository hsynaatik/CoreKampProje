using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.BusinessLayer.ValidationRules;
using CoreKamp.DataAccessLayer.EntityFramework;
using CoreKamp.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using X.PagedList;

namespace CoreKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values =categoryManager.GetList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator cv= new CategoryValidator();
            ValidationResult results =cv.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.Add(category);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError
                        (item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult ChangeStatusCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            if (value.CategoryStatus)
            {
                value.CategoryStatus = false;
            }
            else
            {
                value.CategoryStatus = true;
            }
            categoryManager.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}
