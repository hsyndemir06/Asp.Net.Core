using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("YazarAdı Soyadı Kısmı bos gecemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mesaj Bos Gecemezsim");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Mesaj Bos Gecemezsim");
            RuleFor(x => x.WriterPassword).MinimumLength(2).WithMessage("En az 2 karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter olmalı");
        }
    }
}
