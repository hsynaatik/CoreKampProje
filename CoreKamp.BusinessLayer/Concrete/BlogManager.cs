using CoreKamp.BusinessLayer.Abstract;
using CoreKamp.DataAccessLayer.Abstract;
using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hüseyin Atık");
            }
        }


        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
        {

            return _blogDal.GetByID(id);

        }

        public List<Blog> GetLast3Blog()
        {
           return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog>TGetByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public void Add(Blog item)
        {
           _blogDal.Insert(item);
        }

        public void Delete(Blog item)
        {
            _blogDal.Delete(item);
        }

        public void Update(Blog item)
        {
           _blogDal.Update(item);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
    }
}
