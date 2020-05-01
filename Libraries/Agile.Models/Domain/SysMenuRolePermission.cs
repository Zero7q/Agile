using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 菜单角色权限后端模型
    /// </summary>
    [Table("SysMenuRolePermission")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysMenuRolePermission : BaseEntity
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 权限Id
        /// </summary>
        public int PermissionId { get; set; }
    }
}
