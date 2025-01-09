using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Helpers;
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
    public class GenerateReceiptPdfQueryHandler : IRequestHandler<GenerateReceiptPdfQuery, PdfViewModel>
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IPdfService _pdfService;

        public GenerateReceiptPdfQueryHandler(IReceiptRepository receiptRepository, IPdfService pdfService)
        {
            _receiptRepository = receiptRepository;
            _pdfService = pdfService;
        }

        public async Task<PdfViewModel> Handle(GenerateReceiptPdfQuery request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetByIdAsync(request.ReceiptId);

            if (receipt == null)
            {
                throw new Exception("Receipt not found");
            }

            byte[] pdf = _pdfService.GenerateReceipt(receipt);

            return new PdfViewModel { FileName = $"recibo-{receipt.Customer.Name.ToSlug()}-{receipt.Date}", File = pdf };
        }
    }
}
