using Agile.Core;
using Agile.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models
{
    public abstract class BaseViewModel: BaseSearch
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int Sort { get; set; }
        public EnabledType IsEnabled { get; set; }
    }
}
