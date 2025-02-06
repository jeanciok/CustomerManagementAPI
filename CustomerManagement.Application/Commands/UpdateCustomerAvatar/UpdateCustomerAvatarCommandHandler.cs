using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateAvatarCustomer
{
    public class UpdateCustomerAvatarCommandHandler : IRequestHandler<UpdateCustomerAvatarCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IFileStorageService _fileStorageService;

        public UpdateCustomerAvatarCommandHandler(ICustomerRepository customerRepository, IFileStorageService fileStorageService)
        {
            _customerRepository = customerRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(UpdateCustomerAvatarCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, IFormFile> avatarUrl = await _fileStorageService.UploadFilesAsync(request.Avatar, "customer_avatar");

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer != null && !string.IsNullOrWhiteSpace(customer.AvatarUrl)) 
            {
                await _fileStorageService.DeleteFileAsync(customer.AvatarUrl);
            }

            customer.AvatarUrl = avatarUrl.First().Key;

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}
