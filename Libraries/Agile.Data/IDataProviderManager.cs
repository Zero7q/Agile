using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    /// <summary>
    /// Represents a data provider manager
    /// </summary>
    public partial interface IDataProviderManager
    {
        #region Properties

        /// <summary>
        /// Gets data provider
        /// </summary>
        IAgileDataProvider DataProvider { get; }

        #endregion
    }
}
