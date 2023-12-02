using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class StateViewModel
    {
        public StateViewModel(Guid id, string name, string uf, ICollection<City> cities)
        {
            Id = id;
            Name = name;
            Uf = uf;
            Cities = cities;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
