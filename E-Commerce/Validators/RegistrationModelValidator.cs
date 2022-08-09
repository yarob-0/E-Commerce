namespace ECommerce
{
    using FluentValidation;

	public class RegistrationModelValidator : AbstractValidator<RegisterationModel>
    {
        public RegistrationModelValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName cannot be empty");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty");

        }
    }
}
