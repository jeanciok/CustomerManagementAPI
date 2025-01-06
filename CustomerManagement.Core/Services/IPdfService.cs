using CustomerManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Services
{
    public interface IPdfService
    {
        byte[] GenerateReceipt(Receipt receipt);
    }
}
