using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Models
{
    public class OpenCepResponse
    {
        [JsonPropertyName("cep")]
        public string PostalCode { get; set; }
        [JsonPropertyName("logradouro")]
        public string Street { get; set; }
        [JsonPropertyName("bairro")]
        public string District { get; set; }
        [JsonPropertyName("localidade")]
        public string City { get; set; }
        [JsonPropertyName("uf")]
        public string State { get; set; }
    }
}
