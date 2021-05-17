using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidatonRules
{
   public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adını Boş Geçemezsiniz");
            RuleFor(x => x.HeadingName).MinimumLength(4).WithMessage("En Az 4 Sözcük Yazın");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Başlık Tarihini Boş Geçemezsiniz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategoriyi Boş Geçemezsiniz");
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Yazarı Boş Geçemezsiniz");
        }
    }
}
