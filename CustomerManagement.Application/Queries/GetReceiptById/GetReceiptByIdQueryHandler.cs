using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;

namespace CustomerManagement.Application.Queries.GetReceiptById
{
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ReceiptViewModel>
    {
        private readonly IReceiptRepository _receiptRepository;

        public GetReceiptByIdQueryHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<ReceiptViewModel> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetByIdAsync(request.ReceiptId);

            return new ReceiptViewModel(receipt.Id, receipt.Number, receipt.Tenant.Name, receipt.Customer.Name, receipt.Value, receipt.Description, receipt.Date, receipt.User.Name);
        }
    }
}

