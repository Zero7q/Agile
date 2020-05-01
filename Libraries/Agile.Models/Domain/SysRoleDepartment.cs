using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 角色部门后端模型
    /// </summary>
    [Table("SysRoleDepartment")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysRoleDepartment : BaseEntity
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
    }
}
