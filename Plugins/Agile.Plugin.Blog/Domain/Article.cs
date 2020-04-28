using Agile.Core;
using Agile.Data;

//using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Domain
{
    [Table("Article")]
    [DataBaseAttrobute(DataProviderType.SqlServer)]
    public class Article : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
