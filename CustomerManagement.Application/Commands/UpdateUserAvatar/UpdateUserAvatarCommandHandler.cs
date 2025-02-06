using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommandHandler : IRequestHandler<UpdateUserAvatarCommand, Unit>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IUserRepository _userRepository;

        public UpdateUserAvatarCommandHandler(IFileStorageService fileStorageService, IUserRepository userRepository)
        {
            _fileStorageService = fileStorageService;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserAvatarCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, IFormFile> avatarUrl = await _fileStorageService.UploadFilesAsync(request.Avatar, "profile_avatar");

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user != null && !string.IsNullOrWhiteSpace(user.AvatarUrl))
            {
                await _fileStorageService.DeleteFileAsync(user.AvatarUrl);
            }

            user.AvatarUrl = avatarUrl.First().Key;

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
