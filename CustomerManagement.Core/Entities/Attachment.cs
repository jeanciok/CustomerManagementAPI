using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public string Name { get; set; }
        public string URLFile { get; set; }
        public Customer Customer { get; set; }
    }
}
