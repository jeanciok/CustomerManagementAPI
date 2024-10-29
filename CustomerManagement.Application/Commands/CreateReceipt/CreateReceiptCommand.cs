using MediatR;
using System;

namespace CustomerManagement.Application.Commands.CreateReceipt
{
    public class CreateReceiptCommand : IRequest<Guid>
    {
        public CreateReceiptCommand(Guid customerId, decimal value, string description, DateTime date)
        {
            CustomerId = customerId;
            Value = value;
            Description = description;
            Date = date;
        }

        public Guid CustomerId { get; }
        public decimal Value { get; }
        public string Description { get; }
        public DateTime Date { get; }
    }
}
