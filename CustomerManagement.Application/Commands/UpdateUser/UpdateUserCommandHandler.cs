using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = request.Name;
            user.IsActive = request.IsActive;

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
