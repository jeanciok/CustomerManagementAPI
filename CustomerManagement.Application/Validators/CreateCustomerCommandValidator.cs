using CustomerManagement.Application.Commands.CreateCustomer;
using FluentValidation;
using System;

namespace CustomerManagement.Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.Cnpj).NotEmpty().WithMessage("CNPJ is required");
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("CPF is required");
            RuleFor(x => x.Cep).NotEmpty().WithMessage("CEP is required");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required");
            RuleFor(x => x.Additional).NotEmpty().WithMessage("Additional information is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("City ID is required");
        }
    }
}
