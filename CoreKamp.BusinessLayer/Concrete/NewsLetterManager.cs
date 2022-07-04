
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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLettersDal _newsletterDal;

        public NewsLetterManager(INewsLettersDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void AddNewsLetter(NewsLetters newsLetters)
        {
            _newsletterDal.Insert(newsLetters);
        }
    }
}
