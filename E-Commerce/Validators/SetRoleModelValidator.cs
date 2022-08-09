namespace ECommerce
{
    using FluentValidation;

    public class SetRoleModelValicator : AbstractValidator<SetRoleModel>
    {
        public SetRoleModelValicator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.RoleName).NotEmpty().WithMessage("RoleName cannot be empty");

        }
    }
}
