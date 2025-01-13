using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool IsCpf(this string text)
        {
            return text.Length == 11 && Regex.IsMatch(text, @"^\d{11}$");
        }

        public static bool IsCnpj(this string text)
        {
            return text.Length == 14 && Regex.IsMatch(text, @"^\d{14}$");
        }

        public static string FormatAsCpfOrCnpj(this string text)
        {
            if (text.Length == 11 && Regex.IsMatch(text, @"^\d{11}$"))
            {
                return Regex.Replace(text, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
            }
            else if (text.Length == 14 && Regex.IsMatch(text, @"^\d{14}$"))
            {
                return Regex.Replace(text, @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})", "$1.$2.$3/$4-$5");
            }
            else
            {
                throw new ArgumentException("O texto deve conter exatamente 11 dígitos numéricos para CPF ou 14 dígitos numéricos para CNPJ.");
            }
        }

        public static string FormatAsPhoneNumber(this string text)
        {
            if (text.Length == 10 && Regex.IsMatch(text, @"^\d{10}$"))
            {
                return Regex.Replace(text, @"(\d{2})(\d{4})(\d{4})", "($1) $2-$3");
            }
            else if (text.Length == 11 && Regex.IsMatch(text, @"^\d{11}$"))
            {
                return Regex.Replace(text, @"(\d{2})(\d{5})(\d{4})", "($1) $2-$3");
            }
            else
            {
                throw new ArgumentException("O texto deve conter exatamente 10 ou 11 dígitos numéricos.");
            }
        }
    }
}
