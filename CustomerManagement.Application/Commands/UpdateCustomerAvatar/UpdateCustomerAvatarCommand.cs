﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateAvatarCustomer
{
    public class UpdateCustomerAvatarCommand : IRequest<Unit>
    {
        public UpdateCustomerAvatarCommand(List<IFormFile> avatar, Guid customerId)
        {
            Avatar = avatar;
            CustomerId = customerId;
        }

        public List<IFormFile> Avatar { get; set; }
        public Guid CustomerId { get; set; }
    }
}
