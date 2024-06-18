using CustomerManagement.Application.ViewModels;
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
        private readonly string _bucketUrl;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository, IConfiguration configuration)
        {
            _authService = authService;
            _userRepository = userRepository;
            _bucketUrl = configuration["Storage:BucketURL"];
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordHash(request.Email, passwordHash);

            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var token = _authService.GenerateToken(user.Id, user.Role, user.TenantId);

            return new LoginUserViewModel(user.Id, user.Name, user.Email, token, user.Tenant, $"{_bucketUrl}/{user.AvatarUrl}", user.Role);
        }
    }
}