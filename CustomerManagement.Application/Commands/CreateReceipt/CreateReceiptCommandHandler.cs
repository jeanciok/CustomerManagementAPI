using CustomerManagement.Application.Commands.CreateReceipt;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.CreateReceipt
{
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, Guid>
    {
        private readonly IReceiptRepository _receiptRepository;

        public CreateReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Guid> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = new Receipt(
                request.CustomerId,
                request.Value,
                request.Description,
                request.Date
            );

            await _receiptRepository.AddAsync(receipt);
            return receipt.Id;
        }
    }
}
