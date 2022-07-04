using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.DataAccessLayer.Abstract
{
    public interface IMessage2Dal:IGenericDal<Message2>
    {
        List<Message2> GetInBoxWithMessageByWriter(int id);
        List<Message2> GetSendBoxWithMessageByWriter(int id);
    }
}
