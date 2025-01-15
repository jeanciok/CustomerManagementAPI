using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class AddressViewModel
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public CityViewModel City { get; set; }
    }
}
