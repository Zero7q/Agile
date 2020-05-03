using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 数据字典详情后端模型
    /// </summary>
    [Table("SysDictionaryDetail")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysDictionaryDetail : BaseEntity
    {
        /// <summary>
        /// 字典id
        /// </summary>
        public int DictionaryId { get; set; }
        /// <summary>
        /// 字典键
        /// </summary>
        public string DictionaryKey { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        public string DictionaryValue { get; set; }
    }
}
