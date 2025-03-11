using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteUserCommandHandler(IUserRepository userRepository, IFileStorageService fileStorageService)
        {
            _userRepository = userRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return Unit.Value;

            if (!string.IsNullOrWhiteSpace(user.AvatarUrl))
            {
                await _fileStorageService.DeleteFileAsync(user.AvatarUrl);
            }

            await _userRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
