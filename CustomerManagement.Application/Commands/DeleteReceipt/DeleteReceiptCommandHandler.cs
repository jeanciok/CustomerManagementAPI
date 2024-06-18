using CustomerManagement.Application.Commands.DeleteReceipt;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.DeleteReceipt
{
    public class DeleteReceiptCommandHandler : IRequestHandler<DeleteReceiptCommand, Unit>
    {
        private readonly IReceiptRepository _receiptRepository;

        public DeleteReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Unit> Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
            await _receiptRepository.DeleteAsync(request.ReceiptId);
            return Unit.Value;
        }
    }
}
