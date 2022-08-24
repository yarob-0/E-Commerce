namespace Common
{
    using FluentValidation;

    public class BaseValidator<T> : AbstractValidator<T> where T : BaseEntityViewModel
    {
        public BaseValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(e => e.Name).MaximumLength(49).WithMessage("Max Length is 49");

        }
    }
}
