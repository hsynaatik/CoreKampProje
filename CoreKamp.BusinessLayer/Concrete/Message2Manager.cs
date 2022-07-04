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
    public class Message2Manager: IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Add(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void Delete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetInBoxListByWriter(int id)
        {
            return _message2Dal.GetInBoxWithMessageByWriter(id);
        }
        public List<Message2> GetList()
        {
           return _message2Dal.GetListAll();
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            return _message2Dal.GetSendBoxWithMessageByWriter(id);
        }

        public Message2 TGetById(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public void Update(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
