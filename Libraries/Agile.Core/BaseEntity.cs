using Agile.Core.Caching;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
