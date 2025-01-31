using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;

namespace CustomerManagement.Application.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public ResetPasswordCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null ||
                user.PasswordResetTokenExpiration < DateTime.UtcNow ||
                user.PasswordResetToken != _authService.ComputeSha256Hash(request.Token))
            {
                throw new Exception("Token inválido ou expirado");
            }

            user.Password = _authService.ComputeSha256Hash(request.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiration = null;
            
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
