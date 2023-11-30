using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCustomerGroupById
{
    public class GetCustomerGroupByIdQueryHandler : IRequestHandler<GetCustomerGroupByIdQuery, CustomerGroupViewModel>
    {
        private readonly ICustomerGroupRepository _customerGroupRepository;

        public GetCustomerGroupByIdQueryHandler(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }

        public async Task<CustomerGroupViewModel> Handle(GetCustomerGroupByIdQuery request, CancellationToken cancellationToken)
        {
            CustomerGroup customerGroup = await _customerGroupRepository.GetByIdAsync(request.Id);

            if (customerGroup == null) return null;

            return new CustomerGroupViewModel(customerGroup.Id, customerGroup.Name, customerGroup.Customers);
        }
    }
}
