using MediatR;
using System;

namespace CustomerManagement.Application.Commands.UpdateReceipt
{
    public class UpdateReceiptCommand : IRequest<Unit>
    {
        public UpdateReceiptCommand(Guid id, decimal value, string description)
        {
            Id = id;
            Value = value;
            Description = description;
        }

        public Guid Id { get; }
        public decimal Value { get; }
        public string Description { get; }
        public DateTime Date { get; set; }
    }
}
