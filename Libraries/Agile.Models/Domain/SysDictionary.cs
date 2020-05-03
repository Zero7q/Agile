using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 数据字典后端模型
    /// </summary>
    [Table("SysDictionary")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysDictionary : BaseEntity
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string DictionaryName { get; set; }
        /// <summary>
        /// 字典代码
        /// </summary>
        public string DictionaryCode { get; set; }
    }
}
