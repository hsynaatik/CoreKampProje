using CoreKamp.BusinessLayer.Concrete;
using CoreKamp.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreKamp.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetList();
            return View(values);    
        }

    }
}
