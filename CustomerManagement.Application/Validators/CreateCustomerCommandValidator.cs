using CustomerManagement.Application.Commands.AddCustomer;
using FluentValidation;
using System;

namespace CustomerManagement.Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birth date is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.BusinessPhone).NotEmpty().WithMessage("Business phone is required");
            RuleFor(x => x.HomePhone).NotEmpty().WithMessage("Home phone is required");
            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("CNPJ is required");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF is required");
            RuleFor(x => x.RG).NotEmpty().WithMessage("RG is required");
            RuleFor(x => x.CEP).NotEmpty().WithMessage("CEP is required");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required");
            RuleFor(x => x.Additional).NotEmpty().WithMessage("Additional information is required");
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group ID is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Site).NotEmpty().WithMessage("Site is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.URLPicture).NotEmpty().WithMessage("URL picture is required");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("City ID is required");
        }
    }
}
