using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Services
{
    public interface IFileStorageService
    {
        Dictionary<string, IFormFile> UploadFiles(List<IFormFile> file, string folder);
        Task DeleteFileAsync(string filePath);
    }
}
