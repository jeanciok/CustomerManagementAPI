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
    public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, PaginationResult<ReceiptViewModel>>
    {
        private readonly IReceiptRepository _receiptRepository;

        public GetReceiptsQueryHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<PaginationResult<ReceiptViewModel>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
        {
            var (receipts, total) = await _receiptRepository.Get(
                request.Number,
                request.CustomerName,
                request.StartDate,
                request.EndDate,
                request.Page,
                request.PageSize);

            var receiptViewModels = receipts
                .Select(r => new ReceiptViewModel(r.Id, r.Number, r.Tenant.Name, r.Customer.Name,
                    r.Value, r.Description, r.Date, r.User.Name))
                .ToList();

            int totalPages = (int)Math.Ceiling(total / (double)request.PageSize);

            return new PaginationResult<ReceiptViewModel>(receiptViewModels, request.Page, totalPages, total);
        }
    }

}
