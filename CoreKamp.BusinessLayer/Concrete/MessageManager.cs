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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message t)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListWithByWriter(string p)
        {
            return _messageDal.GetListAll(x => x.Receiver == p);
        }

        public List<Message> GetList()
        {
           return _messageDal.GetListAll();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
