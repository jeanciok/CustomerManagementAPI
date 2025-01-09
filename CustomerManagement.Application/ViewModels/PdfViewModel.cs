using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class PdfViewModel
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
