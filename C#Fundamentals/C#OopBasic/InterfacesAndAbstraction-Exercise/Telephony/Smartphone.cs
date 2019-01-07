using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
