using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class AttachmentViewModel
    {
        public AttachmentViewModel(Guid id, string name, string fileUrl)
        {
            Id = id;
            Name = name;
            FileUrl = fileUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
    }
}
