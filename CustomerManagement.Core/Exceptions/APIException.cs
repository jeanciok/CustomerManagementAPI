using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Exceptions
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message)
        {
        }

        public APIException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
