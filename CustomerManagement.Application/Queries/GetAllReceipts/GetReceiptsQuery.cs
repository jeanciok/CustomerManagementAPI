using MediatR;
using CustomerManagement.Core.Entities;
using System.Collections.Generic;
using CustomerManagement.Application.ViewModels;

namespace CustomerManagement.Application.Queries.GetAllReceipts
{
    public class GetReceiptsQuery : IRequest<List<ReceiptViewModel>>
    {
        public int Number { get; }
        public Guid CustomerId { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetReceiptsQuery(int number, Guid customerId, DateTime startDate, DateTime endDate)
        {
            Number = number;
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
