
using Business.IO.Notification;
using FluentValidation;


namespace Business.Validations
{
    public class NotificationValidation : AbstractValidator<NotificationInput>
    {
        public NotificationValidation()
        {
            RuleFor(f => f.Tipo)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Mensagem)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Valor)
                .NotEmpty().EmailDestinatario("O campo {PropertyName} precisa ser fornecido");
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