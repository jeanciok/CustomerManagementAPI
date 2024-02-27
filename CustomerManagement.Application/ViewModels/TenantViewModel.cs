using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class TenantViewModel
    {
        public TenantViewModel(Guid id, string name, bool isActive, string slug, string documentNumber)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            Slug = slug;
            DocumentNumber = documentNumber;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }
        public string DocumentNumber { get; set; }
    }
}
