using CustomerManagement.Application.Commands.CreateCustomer;
using FluentValidation;
using System;

namespace CustomerManagement.Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("O número de telefone é obrigatório");
            RuleFor(x => x.Cnpj).NotEmpty().WithMessage("O CNPJ é obrigatório");
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("O CPF é obrigatório");
            RuleFor(x => x.Cep).NotEmpty().WithMessage("O CEP é obrigatório");
            RuleFor(x => x.Street).NotEmpty().WithMessage("A rua é obrigatória");
            RuleFor(x => x.Number).NotEmpty().WithMessage("O número é obrigatório");
            RuleFor(x => x.Additional).NotEmpty().WithMessage("As informações adicionais são obrigatórias");
            RuleFor(x => x.Email).EmailAddress().WithMessage("O e-mail não é válido");
            RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição é obrigatória");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("O ID da cidade é obrigatório");
        }
    }
}
