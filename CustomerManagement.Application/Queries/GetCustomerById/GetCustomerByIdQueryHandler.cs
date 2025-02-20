using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Core.Services;
using MediatR;


namespace CustomerManagement.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IFileStorageService _fileStorageService;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IFileStorageService fileStorageService)
        {
            _customerRepository = customerRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerRepository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(customer.AvatarUrl))
            {
                customer.AvatarUrl = _fileStorageService.GeneratePreSignedUrl(customer.AvatarUrl, 30);
            }

            CustomerViewModel customerViewModel = new(
                customer.Id,
                customer.Name,
                customer.PhoneNumber,
                customer.PhoneNumber2,
                customer.Cpf ?? customer.Cnpj,
                customer.Cep,
                customer.Street,
                customer.Number,
                customer.District,
                customer.Additional,
                customer.Email,
                customer.Description,
                customer.City,
                customer.CreatedAt,
                customer.UpdatedAt,
                customer.AvatarUrl
            );

            return customerViewModel;
        }
    }
}
