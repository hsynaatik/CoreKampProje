using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetLast3Blog();
        List<Blog> GetBlogByID(int id);

        List<Blog> GetBlogListWithCategory();
        
        List<Blog> GetBlogListByWriter(int id);    
    }
}
