using CustomerManagement.Application.Commands.CreateUser;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateTenant
{
    public class CreateTenantCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public CreateUserCommand User { get; set; }
    }
}