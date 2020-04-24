using Agile.Core;
using DapperExtensions;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Agile.Data
{
    public interface IAgileDataProvider
    {
        IDatabase CreateConnection();
    }
}
