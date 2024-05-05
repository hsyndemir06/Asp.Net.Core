using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori adını boş gecemezsin");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("kategori acıklmasını boş gecemezsin");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("kategori adı en az 2 karakter olmalı");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("kategori adı en az 30 karakter olmalı");
        }
    }
}
