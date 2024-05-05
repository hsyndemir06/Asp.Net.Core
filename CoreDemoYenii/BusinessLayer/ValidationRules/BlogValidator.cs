using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlıgını bos gecemezsiniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog açıklmasını bos gecemezsiniz");
            RuleFor(x => x.BlogContent).MaximumLength(200).WithMessage("Blog açıklmasını en fazla 200 karakter olmalı ");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Imaj bos gecemezsiniz");
            //RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini bos gecemezsini");
        }

    }
}
