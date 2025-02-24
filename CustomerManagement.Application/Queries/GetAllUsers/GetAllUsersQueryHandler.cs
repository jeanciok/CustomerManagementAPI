using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileStorageService _fileStorageService;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IConfiguration configuration, IFileStorageService fileStorageService)
        {
            _userRepository = userRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userRepository.GetAllAsync();

            List<UserViewModel> usersViewModel = users
                .Select(u => new UserViewModel(
                    u.Id,
                    u.Name,
                    u.Email,
                    u.IsActive,
                    u.Role,
                    u.Tenant,
                    !string.IsNullOrEmpty(u.AvatarUrl) ? _fileStorageService.GeneratePreSignedUrl(u.AvatarUrl, 30) : null))
                .ToList();

            return usersViewModel;
        }
    }
}
