using CustomerManagement.Application.ViewModels;
using MediatR;
using System;

namespace CustomerManagement.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerViewModel>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
