using CustomerManagement.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.CloudServices
{
    public class FileStorageService : IFileStorageService
    {
        public Task UploadFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
