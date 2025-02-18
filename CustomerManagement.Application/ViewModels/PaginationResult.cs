using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.ViewModels
{
    public class PaginationResult<T>
    {
        public PaginationResult(List<T> data, int page, int totalPages, int total)
        {
            Data = data;
            Page = page;
            TotalPages = totalPages;
            Total = total;
        }

        public List<T> Data { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int Total { get; set; }
    }
}
