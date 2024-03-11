using CustomerManagement.Application.ViewModels;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCityByUf
{
    public class GetCityByUfQueryHandler : IRequestHandler<GetCityByUfQuery, List<CityViewModel>>
    {
        private readonly ICityRepository _cityRepository;

        public GetCityByUfQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityViewModel>> Handle(GetCityByUfQuery request, CancellationToken cancellationToken)
        {
            List<City> cities = await _cityRepository.GetAllByUf(request.Uf);

            List<CityViewModel> citiesViewModel = cities
                .Select(c => new CityViewModel(c.Id, c.Name, c.State.Uf))
                .ToList();

            return citiesViewModel;
        }
    }
}
