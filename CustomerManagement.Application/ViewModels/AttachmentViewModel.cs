using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class AttachmentViewModel
    {
        public AttachmentViewModel(Guid id, string name, string fileType, DateTime createdAt)
        {
            Id = id;
            Name = name;
            FileType = fileType;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
