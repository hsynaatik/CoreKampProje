using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetInboxListWithByWriter(string p);
    }
}
