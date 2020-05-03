using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core.Extensions
{
    public static class ObjectExtension
    {
        public static int TryObjToInt(this object obj, int def = 0)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch { return def; }
        }
    }
}
