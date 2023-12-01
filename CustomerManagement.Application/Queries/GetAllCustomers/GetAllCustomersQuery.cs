using CustomerManagement.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerViewModel>>
    {
    }
}
