using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class State : BaseEntity
    {
        public State(string name, string uf)
        {
            Name = name;
            UF = uf;
        }

        public string Name { get; set; }
        public string UF { get; set; }
    }
}
