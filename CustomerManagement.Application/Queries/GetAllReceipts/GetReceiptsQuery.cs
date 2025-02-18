using CustomerManagement.Application.ViewModels;
using MediatR;

public class GetReceiptsQuery : IRequest<PaginationResult<ReceiptViewModel>>
{
    public int Number { get; set; }
    public string CustomerName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
