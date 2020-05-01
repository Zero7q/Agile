using Agile.Core.Caching;
using Agile.Core.Domain;
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

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int Sort { get; set; }

        public EnabledType IsEnabled { get; set; }

        public virtual void Parse<K>(K model) { }
    }
}
