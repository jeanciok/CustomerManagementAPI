using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetTenantById
{
    public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, TenantViewModel>
    {
        private readonly ITenantRepository _tenantRepository;

        public GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<TenantViewModel> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
        {
            Tenant tenant = await _tenantRepository.GetByIdAsync(request.Id);

            if (tenant == null)
            {
                return null;
            }

            TenantViewModel viewModel = new TenantViewModel(tenant.TenantId, tenant.Name, tenant.IsActive, tenant.Slug, tenant.DocumentNumber);

            return viewModel;
        }
    }
}
