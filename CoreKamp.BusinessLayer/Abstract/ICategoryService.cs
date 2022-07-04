using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        ICollection<Category> GetAllStatusActive();
    }
}
