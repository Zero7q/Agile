using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    public class DataProviderManager : IDataProviderManager
    {
        public IAgileDataProvider AgileDataProvider(DataProviderType dataProviderType)
        {

            switch (dataProviderType)
            {
                case DataProviderType.SqlServer:
                    return new MsSqlAgileDataProvider();
                case DataProviderType.MySql:
                    return new MySqlAgileDataProvider();
                default:
                    throw new Exception("不支持此数据库");
            }
        }
    }
}
