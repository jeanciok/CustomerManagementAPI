using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllCustomerGroups
{
    public class GetAllCustomerGroupsQueryHandler : IRequestHandler<GetAllCustomerGroupsQuery, List<CustomerGroupViewModel>>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public GetAllCustomerGroupsQueryHandler(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<List<CustomerGroupViewModel>> Handle(GetAllCustomerGroupsQuery request, CancellationToken cancellationToken)
        {
            List<CustomerGroup> customerGroups = await _customerGroupRepository.GetAllAsync();

            List<CustomerGroupViewModel> customerGroupsViewModel = customerGroups
                .Select(cg => new CustomerGroupViewModel(cg.Id, cg.Name, cg.Customers))
                .ToList();

            return customerGroupsViewModel;
        }
    }
}
