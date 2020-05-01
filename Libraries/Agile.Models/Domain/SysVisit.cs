using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 访问后端模型
    /// </summary>
    [Table("SysVisit")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysVisit : BaseEntity
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }
    }
}
