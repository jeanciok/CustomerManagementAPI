using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Address
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public City City { get; set; }
    }
}
