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
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Message2s.Include(x => x.ReceiverUser).Where(y => y.SenderID == id).ToList();

            }
        }

        public List<Message2> GetInBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();

            }
        }
    }
}
