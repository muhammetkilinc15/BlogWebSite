using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator :AbstractValidator<Category>
	{
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklmasını boş geçemezsiniz");
            RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maximumum 50 karakter olabilir");
            RuleFor(x=>x.CategoryName).MinimumLength(10).WithMessage("Kategori adı minumum 10 karakter olabilir");
        }
    }
}
