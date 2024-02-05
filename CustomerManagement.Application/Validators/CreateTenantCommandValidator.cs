using CustomerManagement.Application.Commands.CreateTenant;
using FluentValidation;

namespace CustomerManagement.Application.Validators
{
    public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
    {
        public CreateTenantCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.DocumentNumber).NotEmpty().WithMessage("DocumentNumber is required");
            RuleFor(x => x.User).NotNull().WithMessage("User is required");
        }
    }
}
