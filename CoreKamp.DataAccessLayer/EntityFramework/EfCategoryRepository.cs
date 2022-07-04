using CoreKamp.DataAccessLayer.Abstract;
using CoreKamp.DataAccessLayer.Repositories;
using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public ICollection<Category> GetAllStatusActive()
        {
            return context.Categories.Where(_category => _category.CategoryStatus == true).ToList();
        }
    }
}
