using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 用户部门后端模型
    /// </summary>
    [Table("SysUserDepartment")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysUserDepartment : BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public string DepartmentId { get; set; }
    }
}
