using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatonRules
{
  public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakteri Geçmeyin");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Giriniz");
            
        }
    }
}
