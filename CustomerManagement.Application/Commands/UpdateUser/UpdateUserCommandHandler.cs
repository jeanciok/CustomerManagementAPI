using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
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

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new(request.Id, request.Name, request.Email, request.Password, request.RoleId, request.IsActive);

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
