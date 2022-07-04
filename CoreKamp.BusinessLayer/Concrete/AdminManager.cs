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
    public class AdminManager:IAdminService
    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }

        public void Add(Admin t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin t)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public Admin TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
