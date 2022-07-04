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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal) { 
            _notificationDal= notificationDal; 
        }

        public void Add(Notification t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification t)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
           return _notificationDal.GetListAll();
        }

        public List<Notification> TGetAll3Last()
        {
            return _notificationDal.GetListAll().Take(3).ToList();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
