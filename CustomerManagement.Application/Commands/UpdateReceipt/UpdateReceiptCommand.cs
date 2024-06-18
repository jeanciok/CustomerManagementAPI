using MediatR;
using System;

namespace CustomerManagement.Application.Commands.UpdateReceipt
{
    public class UpdateReceiptCommand : IRequest<Unit>
    {
        public UpdateReceiptCommand(Guid id, Guid customerId, decimal value, string description, DateTime date)
        {
            Id = id;
            CustomerId = customerId;
            Value = value;
            Description = description;
            Date = date;
        }

        public Guid Id { get; }
        public Guid CustomerId { get; }
        public decimal Value { get; }
        public string Description { get; }
        public DateTime Date { get; }
    }
}
