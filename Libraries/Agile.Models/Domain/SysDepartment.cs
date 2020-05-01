using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 部门后端模型
    /// </summary>
    [Table("SysDepartment")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysDepartment : BaseEntity
    {
        /// <summary>
        /// 上级部门Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
