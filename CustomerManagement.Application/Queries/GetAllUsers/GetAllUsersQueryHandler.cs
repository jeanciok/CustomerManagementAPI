using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly string _bucketUrl;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _bucketUrl = configuration["Storage:BucketURL"];
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userRepository.GetAllAsync();

            List<UserViewModel> usersViewModel = users
                .Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.IsActive, u.Role, u.Tenant))
                .ToList();

            return usersViewModel;
        }
    }
}
