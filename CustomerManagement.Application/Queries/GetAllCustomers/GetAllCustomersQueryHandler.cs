using CustomerManagement.Application.Queries.GetAllCustomers;
using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Repositories;
using MediatR;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginationResult<CustomerViewModel>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PaginationResult<CustomerViewModel>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var (customers, total) = await _customerRepository.Get(request.Name, request.CpfCnpj, request.Page, request.PageSize);

        var customerViewModels = customers
            .Select(c => new CustomerViewModel(c.Id, c.Name, c.PhoneNumber, c.PhoneNumber2,
                c.Cpf != null ? c.Cpf : c.Cnpj, c.Cep, c.Street, c.Number, c.District,
                c.Additional, c.Email, c.Description, c.City, c.CreatedAt, c.UpdatedAt, c.AvatarUrl))
            .ToList();

        int totalPages = (int)Math.Ceiling(total / (double)request.PageSize);

        return new PaginationResult<CustomerViewModel>(customerViewModels, request.Page, totalPages, total);
    }
}
