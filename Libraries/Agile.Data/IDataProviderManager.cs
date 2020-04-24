using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    public interface IDataProviderManager
    {
        IAgileDataProvider AgileDataProvider(DataProviderType dataProviderType);
    }
}
