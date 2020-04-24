using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Agile.Data
{
    public class MySqlAgileDataProvider : IAgileDataProvider
    {
        public IDatabase CreateConnection()
        {
            var connection = new MySqlConnection(DataSettingsManager.MySqlConnectionString);
            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new MySqlDialect());
            var sqlGenerator = new SqlGeneratorImpl(config);
            return new Database(connection, sqlGenerator);
        }
    }
}
