using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
        string GenerateToken(string username, string password);
    }
}
