using CustomerManagement.Application.Services;
using CustomerManagement.Core.Entities;
using CustomerManagement.Core.Exceptions;
using CustomerManagement.Core.Repositories;
using CustomerManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Services
{
    public class OpenCepService : IOpenCepService
    {
        private readonly HttpClient _httpClient;
        private readonly ICityRepository _cityRepository;

        public OpenCepService(HttpClient httpClient, ICityRepository cityRepository)
        {
            _httpClient = httpClient;
            _cityRepository = cityRepository;
        }

        public async Task<Address> GetAddressByPostalCode(string postalCode)
        {
            var response = await _httpClient.GetAsync($"https://opencep.com/v1/{postalCode}.json");
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new APIException("CEP não encontrado");
            else if (!response.IsSuccessStatusCode)
                throw new APIException("Erro ao buscar o CEP, contate o suporte");

            var content = await response.Content.ReadAsStringAsync();
            var openCepResponse = JsonSerializer.Deserialize<OpenCepResponse>(content);

            var city = await _cityRepository.GetByIbge(int.Parse(openCepResponse.Ibge));

            return new Address()
            {
                PostalCode = openCepResponse.PostalCode,
                Street = openCepResponse.Street,
                District = openCepResponse.District,
                City = city
            };
        }
    }
}
