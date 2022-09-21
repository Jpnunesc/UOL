
using Business.IO.Notification;
using FluentValidation;


namespace Business.Validations
{
    public class NotificationEmailValidation : AbstractValidator<NotificationInput>
    {
        public NotificationEmailValidation()
        {
            RuleFor(f => f.Tipo)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Mensagem)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.EmailDestinatario)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.EmailOrigem)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Assunto)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Cliente)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.NomeUsuario)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}