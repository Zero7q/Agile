using Agile.Core;
using Agile.Data;
//using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Domain
{
    [Table("Role")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }
}
