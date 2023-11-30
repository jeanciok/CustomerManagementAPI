using CustomerManagement.Application.ViewModels;
using MediatR;
using System;

namespace CustomerManagement.Application.Queries.GetCustomerGroupById
{
    public class GetCustomerGroupByIdQuery : IRequest<CustomerGroupViewModel>
    {
        public Guid Id { get; set; }

        public GetCustomerGroupByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
