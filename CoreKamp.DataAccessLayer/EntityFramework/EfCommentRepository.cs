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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.Blog).ToList();

            }
        }
    }
}
