using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class State : BaseEntity
    {
        public State() { }
        public State(string name, string uf, ICollection<City> city)
        {
            Name = name;
            Uf = uf;
            Cities = city;
        }

        public string Name { get; set; }
        public string Uf{ get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
