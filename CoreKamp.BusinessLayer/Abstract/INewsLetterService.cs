using CoreKamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.Abstract
{
    public interface INewsLetterService
    {
        void AddNewsLetter(NewsLetters newsLetters);
    }
}
