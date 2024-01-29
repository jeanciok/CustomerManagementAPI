using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Helpers
{
    public static class StringExtensions
    {
        public static string ToSlug(this string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(
                System.Text.RegularExpressions.Regex.Replace(
                    System.Text.RegularExpressions.Regex.Replace(
                        text.ToLower(),
                        @"\s", "-",
                        System.Text.RegularExpressions.RegexOptions.Compiled),
                    @"[^a-z0-9\s-_]", "",
                    System.Text.RegularExpressions.RegexOptions.Compiled),
                @"-+", "-",
                System.Text.RegularExpressions.RegexOptions.Compiled).Trim('-');
        }
    }
}
