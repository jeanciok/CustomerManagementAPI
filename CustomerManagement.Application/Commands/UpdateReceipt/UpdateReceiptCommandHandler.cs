using CustomerManagement.Application.Commands.UpdateReceipt;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Commands.UpdateReceipt
{
    public class UpdateReceiptCommandHandler : IRequestHandler<UpdateReceiptCommand, Unit>
    {
        private readonly IReceiptRepository _receiptRepository;

        public UpdateReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Unit> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetByIdAsync(request.Id);

            if (receipt == null)
            {
                throw new Exception("Receipt not found");
            }

            receipt.CustomerId = request.CustomerId;
            receipt.Value = request.Value;
            receipt.Description = request.Description;
            receipt.Date = request.Date;

            await _receiptRepository.UpdateAsync(receipt);
            return Unit.Value;
        }
    }
}
