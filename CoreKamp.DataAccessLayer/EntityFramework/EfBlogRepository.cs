using CoreKamp.DataAccessLayer.Abstract;
using CoreKamp.DataAccessLayer.Concrete;
using CoreKamp.DataAccessLayer.Repositories;
using CoreKamp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using(var context =new Context())
            {
                return context.Blogs.Include(x => x.Category).ToList();

            }
            
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList();

            }
        }
    }
}
