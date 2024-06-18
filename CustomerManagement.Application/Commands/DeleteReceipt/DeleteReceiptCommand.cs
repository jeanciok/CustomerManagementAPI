using MediatR;
using System;

namespace CustomerManagement.Application.Commands.DeleteReceipt
{
    public class DeleteReceiptCommand : IRequest<Unit>
    {
        public Guid ReceiptId { get; }

        public DeleteReceiptCommand(Guid receiptId)
        {
            ReceiptId = receiptId;
        }
    }
}
