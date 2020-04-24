using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Data
{
    public static class DataSettingsManager
    {
        public static string MySqlConnectionString = "server=localhost;uid=root;pwd=sql123;database=agile;Allow User Variables=True";
        public static string SqlServerConnectionString = "Data Source=.;Initial Catalog=Agile; User Id=sa;Password=sql";
    }
}
