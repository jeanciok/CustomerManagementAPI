using CustomerManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Queries.GetCityByUf
{
    public class GetCityByUfQuery : IRequest<List<CityViewModel>>
    {
        public string Uf { get; set; }
    }
}
