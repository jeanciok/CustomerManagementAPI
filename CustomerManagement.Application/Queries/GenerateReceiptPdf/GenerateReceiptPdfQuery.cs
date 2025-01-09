using CustomerManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GenerateReceiptPdf
{
    public class GenerateReceiptPdfQuery : IRequest<PdfViewModel>
    {
        public Guid ReceiptId { get; set; }

        public GenerateReceiptPdfQuery(Guid receiptId)
        {
            ReceiptId = receiptId;
        }
    }
}
