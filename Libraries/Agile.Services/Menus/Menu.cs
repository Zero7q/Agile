using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Services.Menus
{
    [Table("Menu")]
    [DataBaseProviderAttrobute(DataProviderType.SqlServer)]
    public class Menu : BaseEntity
    {
        public string Node { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
