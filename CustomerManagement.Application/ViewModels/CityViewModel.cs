using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class CityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
    }
}
