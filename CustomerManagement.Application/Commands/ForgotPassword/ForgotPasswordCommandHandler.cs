using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public ForgotPasswordCommandHandler(IUserRepository userRepository, IEmailService emailService, IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _userRepository = userRepository;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is not null)
            {
                string rawToken = _authService.GenerateSecureToken();

                user.PasswordResetToken = _authService.ComputeSha256Hash(rawToken);
                user.PasswordResetTokenExpiration = DateTime.UtcNow.AddMinutes(30);

                var encodedToken = WebUtility.UrlEncode(rawToken);
                var encodedEmail = WebUtility.UrlEncode(user.Email);

                await _userRepository.UpdateAsync(user);

                var resetLink = $"{_configuration["FrontEndUrl:Url"]}/sessions/reset-password?token={encodedToken}&email={encodedEmail}";

                //await _emailService.SendEmailAsync(user.Email, "Recuperação de Senha", $"Clique no link para redefinir sua senha: {resetLink}");
                //await _emailService.SendEmailAsync("jeanciok@gmail.com", "Teste Email", "Teste Email");
                await _emailService.SendPasswordResetEmailAsync(user.Email, resetLink);
            }


            return Unit.Value;
        }
    }
}
