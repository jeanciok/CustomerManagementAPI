using MediatR;
using CustomerManagement.Core.Entities;
using System.Collections.Generic;
using CustomerManagement.Application.ViewModels;

namespace CustomerManagement.Application.Queries.GetAllReceipts
{
    public class GetReceiptsQuery : IRequest<List<ReceiptViewModel>>
    {
        public int Number { get; }
        public string CustomerName { get; }

        public GetReceiptsQuery(int number, string customerName)
        {
            Number = number;
            CustomerName = customerName;
        }
    }
}
