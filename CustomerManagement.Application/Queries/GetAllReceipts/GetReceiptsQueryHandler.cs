using CustomerManagement.Application.Queries.GetAllReceipts;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetAllReceipts
{
    public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, List<ReceiptViewModel>>
    {
        private readonly IReceiptRepository _receiptRepository;

        public GetReceiptsQueryHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<List<ReceiptViewModel>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
        {
            List<Receipt> receipts = await _receiptRepository.Get(request.Number, request.CustomerName);

            List<ReceiptViewModel> receiptViewModels = receipts
                .Select(r => new ReceiptViewModel(r.Id, r.Number, r.Customer, r.Tenant, r.Value, r.Description, r.Date, r.User))
                .ToList();

            return receiptViewModels;
        }
    } 
}
