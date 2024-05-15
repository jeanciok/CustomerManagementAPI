using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateUserAvatar
{
    public class UpdateUserAvatarCommand : IRequest<Unit>
    {
        public UpdateUserAvatarCommand(List<IFormFile> avatar, Guid userId)
        {
            Avatar = avatar;
            UserId = userId;
        }

        public List<IFormFile> Avatar { get; set; }
        public Guid UserId { get; set; }
    }
}
