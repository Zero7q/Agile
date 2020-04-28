using Agile.Core;
using Agile.Data;
//using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Domain
{
    [Table("Category")]
    [DataBaseAttrobute(DataProviderType.SqlServer)]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}
