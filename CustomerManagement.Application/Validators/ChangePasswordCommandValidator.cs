using CustomerManagement.Application.Commands.ChangePassword;
using FluentValidation;
using System;
using System.Linq;

namespace CustomerManagement.Application.Validators
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Senha atual é obrigatória");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Nova senha é obrigatória")
                .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número")
                .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial")
                .NotEqual(x => x.CurrentPassword).WithMessage("A nova senha não pode ser igual à senha atual");
        }
    }
}
