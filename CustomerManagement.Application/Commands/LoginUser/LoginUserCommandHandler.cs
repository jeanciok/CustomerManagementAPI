using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private IAuthService _authService;
        private IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository, IConfiguration configuration)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordHashAsync(request.Email, passwordHash);

            if (user == null)
                throw new APIException("Usuário ou senha inválido");

            if (!user.IsActive)
            {
                throw new APIException("Usuário inativo ou bloqueado");
            }

            var token = _authService.GenerateToken(user.Id, user.Role, user.TenantId);

            return new LoginUserViewModel(user.Id, user.Name, user.Email, token, user.Tenant, "", user.Role);
        }
    }
}