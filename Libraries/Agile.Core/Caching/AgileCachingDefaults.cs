using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core.Caching
{
    public static class AgileCachingDefaults
    {
        /// <summary>
        /// Gets the default cache time in minutes
        /// </summary>
        public static int CacheTime => 60;

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Entity type name
        /// {1} : Entity id
        /// </remarks>
        public static string AgileEntityCacheKey => "Agile.{0}.id-{1}";
    }
}
