using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core.Extensions
{
    public static class StringExtension
    {
        public static void TryStringToInt(this string s, out int def)
        {
            int.TryParse(s, out def);
        }

        public static int StringToInt(this string s)
        {
            return int.Parse(s);
        }
    }
}
