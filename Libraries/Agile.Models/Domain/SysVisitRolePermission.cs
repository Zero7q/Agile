using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 访问角色后端模型
    /// </summary>
    [Table("SysVisitRolePermission")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysVisitRolePermission : BaseEntity
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 访问Id
        /// </summary>
        public int VisitId { get; set; }
        /// <summary>
        /// 权限Id
        /// </summary>
        public int PermissionId { get; set; }
    }
}
