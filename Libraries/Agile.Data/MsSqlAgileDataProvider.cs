using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Agile.Data
{
    public class MsSqlAgileDataProvider : IAgileDataProvider
    {
        public IDatabase CreateConnection()
        {
            var connection = new SqlConnection(DataSettingsManager.SqlServerConnectionString);
            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect());
            var sqlGenerator = new SqlGeneratorImpl(config);
            return new Database(connection, sqlGenerator);
        }
    }
}
