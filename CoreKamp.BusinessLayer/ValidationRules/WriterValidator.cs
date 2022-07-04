using CoreKamp.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.BusinessLayer.ValidationRules
{
    public  class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş bırakılamaz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola boş bırakılamaz.");
            RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Sifre en azı bir büyük harfden ibaret olmalıdır.");
            RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Sifre en azı bir kücük harfden ibaret olmalıdır.");
            RuleFor(x => x.WriterMail).Matches(@"[@,.]+").WithMessage("Mail Adresi @ ve . içermelidir.");
            RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Sifre en azı bir rakamdan ibaret olmalıdır.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 karakter girişi yapınız.");
        }
    }
}
