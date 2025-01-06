using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GenerateReceiptPdf
{
    public class GenerateReceiptPdfQueryHandler : IRequestHandler<GenerateReceiptPdfQuery, byte[]>
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IPdfService _pdfService;

        public GenerateReceiptPdfQueryHandler(IReceiptRepository receiptRepository, IPdfService pdfService)
        {
            _receiptRepository = receiptRepository;
            _pdfService = pdfService;
        }

        public async Task<byte[]> Handle(GenerateReceiptPdfQuery request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetByIdAsync(request.ReceiptId);

            if (receipt == null)
            {
                throw new Exception("Receipt not found");
            }

            return _pdfService.GenerateReceipt(receipt);
        }
    }
}
