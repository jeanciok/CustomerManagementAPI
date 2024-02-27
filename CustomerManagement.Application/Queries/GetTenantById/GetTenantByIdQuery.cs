using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetTenantById
{
    public class GetTenantByIdQuery : IRequest<TenantViewModel>
    {
        public Guid Id { get; set; }

        public GetTenantByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
