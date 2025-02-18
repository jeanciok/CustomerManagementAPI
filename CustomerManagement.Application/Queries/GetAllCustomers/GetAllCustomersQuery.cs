using CustomerManagement.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PaginationResult<CustomerViewModel>>
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
