namespace ECommerce
{
    using FluentValidation;

    public class TokenRequestModelValidator : AbstractValidator<TokenRequestModel>
    {
        public TokenRequestModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
