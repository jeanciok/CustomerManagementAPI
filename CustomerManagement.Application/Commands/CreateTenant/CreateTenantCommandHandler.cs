using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Helpers;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateTenant
{
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;

        public CreateTenantCommandHandler(ITenantRepository tenantRepository, IAuthService authService, IMediator mediator)
        {
            _tenantRepository = tenantRepository;
            _authService = authService;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant(Guid.NewGuid(), request.Name, true, request.Name.ToSlug(), request.DocumentNumber);

            await _tenantRepository.AddAsync(tenant);

            var createUser = new CreateUserCommand
            {
                Name = request.User.Name,
                Email = request.User.Email,
                Password = request.User.Password,
                RoleId = request.User.RoleId,
                TenantId = tenant.TenantId
            };

            await _mediator.Send(createUser);

            return tenant.TenantId;
        }

    }
}