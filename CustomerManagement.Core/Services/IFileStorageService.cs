using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Services
{
    public interface IFileStorageService
    {
        Task UploadFileAsync(string filePath);
    }
}
