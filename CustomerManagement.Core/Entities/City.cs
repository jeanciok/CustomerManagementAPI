using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class City : BaseEntity
    {
        public City() { }

        public City(string name, State state)
        {
            Name = name;
            State = state;
        }

        public string Name { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
        //public ICollection<Customer> Customers { get; set; }
    }
}
