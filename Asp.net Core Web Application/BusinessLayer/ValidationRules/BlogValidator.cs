using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog başlıgını boş geçemezsiniz");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz");
            RuleFor(x=>x.BlogContent).MinimumLength(5).WithMessage("Lütfen en az 5 karakterlik bir blog içeriği giriniz");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x=>x.BlogTitle).MaximumLength(100).WithMessage("Lütfen 100 karakterden az veri girişi yapın");
            RuleFor(x=>x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden fazla veri girişi yapın");
        }
    }
}
