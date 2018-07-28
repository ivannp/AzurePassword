using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AzurePassword
{
    public static class AzurePassword
    {
        private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string AllowedSymbols = "~!@#$%^&*()_+-={}|[]:;<>?,./";
        private const string Allowed = UpperCaseLetters + LowerCaseLetters + Digits + AllowedSymbols;
        private const string Banned = "\'\"`\\"; // "'`\
        private const string BannedPattern = "[\\\'\\\"`\\\\]"; // "'`\

        private const int DEFAULT_LEN = 14;

        public static string Generate(int len = DEFAULT_LEN, bool upper = true, bool lower = true, bool digits = true, string allowedSymbols = AllowedSymbols)
        {
            if (len <= 0) len = DEFAULT_LEN;

            var random = new Random();
            var buffer = new StringBuilder(len);
            string allowed = "";
            if(upper)
            {
                buffer.Append(UpperCaseLetters[random.Next(UpperCaseLetters.Length)]);
                allowed += UpperCaseLetters;
            }

            if(lower)
            {
                buffer.Append(LowerCaseLetters[random.Next(LowerCaseLetters.Length)]);
                allowed += LowerCaseLetters;
            }
            
            if(digits)
            {
                buffer.Append(Digits[random.Next(Digits.Length)]);
                allowed += Digits;
            }
            
            if(allowedSymbols.Length > 0)
            {
                buffer.Append(allowedSymbols[random.Next(allowedSymbols.Length)]);
                allowed += allowedSymbols;
            }
                
            for (var id = 4; id < len; ++id)
                buffer.Append(allowed[random.Next(allowed.Length)]);

            // Shuffle
            for (var id = 0; id < buffer.Length; ++id)
            {
                var otherId = random.Next(buffer.Length);
                if (otherId == id) continue;
                var c = buffer[otherId];
                buffer[otherId] = buffer[id];
                buffer[id] = c;
            }
            return buffer.ToString();
        }

        public static bool Verify(string password)
        {
            return !Regex.IsMatch(password, BannedPattern);
        }
    }
}
