using Agile.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core
{
    public interface IStoreContext
    {
        /// <summary>
        /// Gets the current store
        /// </summary>
        Store CurrentStore { get; }

        /// <summary>
        /// Gets active store scope configuration
        /// </summary>
        int ActiveStoreScopeConfiguration { get; }
    }
}
