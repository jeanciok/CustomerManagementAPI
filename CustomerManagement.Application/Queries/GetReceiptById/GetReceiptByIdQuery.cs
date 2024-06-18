using MediatR;
using CustomerManagement.Core.Entities;
using System;
using CustomerManagement.Application.ViewModels;

namespace CustomerManagement.Application.Queries.GetReceiptById
{
    public class GetReceiptByIdQuery : IRequest<ReceiptViewModel>
    {
        public GetReceiptByIdQuery(Guid receiptId)
        {
            ReceiptId = receiptId;
        }


        public Guid ReceiptId { get; }
    }
}

