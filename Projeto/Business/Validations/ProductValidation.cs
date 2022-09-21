
using Business.IO.Product;
using FluentValidation;


namespace Business.Validations
{
    public class ProductValidation : AbstractValidator<ProductInput>
    {
        public ProductValidation()
        {
            RuleFor(f => f.Name)
              .NotEmpty().WithMessage("The {PropertyName} field must be provided");

            RuleFor(f => f.Sku)
                .NotEmpty().WithMessage("Campo {PropertyName} obrigatório!");
        }
    }
}