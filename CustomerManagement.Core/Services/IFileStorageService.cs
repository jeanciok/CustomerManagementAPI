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
        Task<Dictionary<string, IFormFile>> UploadFilesAsync(List<IFormFile> files, string folder);
        Task DeleteFileAsync(string filePath);
    }
}
