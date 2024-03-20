using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyApplication.Domain.Services
{
    public static class ValidationServices
    {
        public static bool TextBoxValidation(string[] strings)
        {
            if (strings.Any(x => string.IsNullOrEmpty(x.ToString())))
            {
                return false;
            }
            return true;
        }

        public static bool ValidEmail(string email)
        {
            Regex emailinput = new Regex("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+");
            return emailinput.IsMatch(email);
        }

        public static bool ValidPassword(string Password)
        {
            Regex passinput = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,}$");
            return passinput.IsMatch(Password);
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
