using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Destcription).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen Görsel Seçiniz...!");
            RuleFor(x => x.Destcription).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisi giriniz");
            RuleFor(x => x.Destcription).MaximumLength(1500).WithMessage("Lütfen Açıklamayı Azaltın");
        }
    }
}
