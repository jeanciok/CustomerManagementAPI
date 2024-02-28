using CustomerManagement.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CustomerManagement.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerViewModel>>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
    }
}
