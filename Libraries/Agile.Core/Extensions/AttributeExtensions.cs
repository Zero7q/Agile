
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Core.Extensions
{
    public static class AttributeExtensions
    {
        public static T GetCustomAttribute<T>(this Type type)
        {
            object attribute = type.GetCustomAttributes(typeof(T), false).FirstOrDefault();
            if (attribute == null)
            {
                return default;
            }
            return ((T)attribute);
        }
    }
}
