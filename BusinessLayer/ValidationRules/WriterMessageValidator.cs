using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterMessageValidator : AbstractValidator<WriterMessage>
    {
        public WriterMessageValidator()
        {
            RuleFor(x => x.Recevier).NotEmpty().WithMessage("Mesaj alıcı kısmına lütfen mail yazınız boş geçilemez");
        }
    }
}
