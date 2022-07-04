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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            throw new NotImplementedException();
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentWithBlog()
        {
           return _commentDal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x => x.BlogID == id);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
