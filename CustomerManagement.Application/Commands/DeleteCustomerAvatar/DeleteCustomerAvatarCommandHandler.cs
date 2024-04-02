using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteCustomerAvatar
{
    public class DeleteCustomerAvatarCommandHandler : IRequestHandler<DeleteCustomerAvatarCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteCustomerAvatarCommandHandler(ICustomerRepository customerRepository, IFileStorageService fileStorageService)
        {
            _customerRepository = customerRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(DeleteCustomerAvatarCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            await _fileStorageService.DeleteFileAsync(customer.AvatarUrl);

            customer.AvatarUrl = string.Empty;

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }

    }
}
