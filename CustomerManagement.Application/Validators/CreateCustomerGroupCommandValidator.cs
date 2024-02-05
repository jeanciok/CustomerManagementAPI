using CustomerManagement.Application.Commands.CreateCustomerGroup;
using FluentValidation;

namespace CustomerManagement.Application.Validators
{
    public class CreateCustomerGroupCommandValidator : AbstractValidator<CreateCustomerGroupCommand>
    {
        public CreateCustomerGroupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
