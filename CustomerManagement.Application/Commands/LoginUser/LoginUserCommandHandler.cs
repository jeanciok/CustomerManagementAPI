﻿using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using MediatR.Pipeline;
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

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordHash(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateToken(user.Email, "Admin");

            return new LoginUserViewModel(user.Email, token, user.Tenant);
        }
    }
}
