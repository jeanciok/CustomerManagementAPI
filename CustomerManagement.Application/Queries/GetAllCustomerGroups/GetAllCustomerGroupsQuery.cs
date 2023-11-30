using CustomerManagement.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllCustomerGroups
{
    public class GetAllCustomerGroupsQuery : IRequest<List<CustomerGroupViewModel>>
    {
    }
}
S