using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class City : BaseEntity
    {
        public City(string name, string uF, State state, ICollection<Customer> customers)
        {
            Name = name;
            UF = uF;
            State = state;
            Customers = customers;
        }

        public string Name { get; set; }
        public string UF { get; set; }
        public State State { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
