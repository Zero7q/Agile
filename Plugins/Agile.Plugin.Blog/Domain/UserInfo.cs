using Agile.Core;
using Agile.Data;

//using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Domain
{
    [Table("UserInfo")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class UserInfo : BaseEntity
    {
        public int RoleId { get; set; }
        public string UserName { get; set; }
    }
}
