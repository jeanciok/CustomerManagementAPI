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

namespace CustomerManagement.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly string _bucketUrl;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _bucketUrl = configuration["Storage:BucketURL"];
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null) return null;

            UserViewModel viewModel = new
            (
                user.Id,
                user.Name,
                user.Email,
                user.IsActive,
                user.Tenant,
                $"{_bucketUrl}/{user.AvatarUrl}"
            );

            return viewModel;
        }
    }
}
