using CustomerManagement.Application.Services;
using CustomerManagement.Core.Entities;
using CustomerManagement.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.Services
{
    public class OpenCepService : IOpenCepService
    {
        private readonly HttpClient _httpClient;

        public OpenCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Address> GetAddressByPostalCode(string postalCode)
        {
            var response = await _httpClient.GetAsync($"https://opencep.com/v1/{postalCode}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var openCepResponse = JsonSerializer.Deserialize<OpenCepResponse>(content);

            //return new Address()
            //{
            //    PostalCode = openCepResponse.PostalCode,
            //    Street = openCepResponse.Street,
            //    District = openCepResponse.District,
            //    City = new City()
            //    {
            //        Name = openCepResponse.,
            //        State = openCepResponse.Uf
            //    }
            //}

            return new Address();
        }
    }
}
