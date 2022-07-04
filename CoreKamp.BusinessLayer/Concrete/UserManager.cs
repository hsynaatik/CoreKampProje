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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public void Update(AppUser t)
        {
           _userDal.Update(t);
        }
    }
}
