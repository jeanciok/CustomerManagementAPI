using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IFileStorageService fileStorageService)
        {
            _customerRepository = customerRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                return Unit.Value;

            if (customer.Attachments != null)
            {
                foreach (var attachment in customer.Attachments)
                {
                    if (!string.IsNullOrEmpty(attachment.FileUrl))
                    {
                        await _fileStorageService.DeleteFileAsync(attachment.FileUrl);
                    }
                }
            }

            if (!string.IsNullOrEmpty(customer.AvatarUrl))
            {
                await _fileStorageService.DeleteFileAsync(customer.AvatarUrl);
            }

            await _customerRepository.DeleteAsync(request.Id);
            
            return Unit.Value;
        }
    }
}
