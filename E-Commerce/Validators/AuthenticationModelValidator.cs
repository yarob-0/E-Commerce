namespace ECommerce
{
    using FluentValidation;

    public class AuthenticationModelValidator : AbstractValidator<AuthenticationModel>
    {
        public AuthenticationModelValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName cannot be empty");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.Message).MaximumLength(500);
        }
    }
}
