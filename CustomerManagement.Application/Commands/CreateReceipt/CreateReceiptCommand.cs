using MediatR;
using System;

namespace CustomerManagement.Application.Commands.CreateReceipt
{
    public class CreateReceiptCommand : IRequest<Guid>
    {
        public CreateReceiptCommand(Guid customerId, decimal value, string description, DateTime date, Guid createdBy)
        {
            CustomerId = customerId;
            Value = value;
            Description = description;
            Date = date;
            CreatedBy = createdBy;
        }

        public Guid CustomerId { get; }
        public decimal Value { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public Guid CreatedBy { get; }
    }
}
