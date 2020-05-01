using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 文件角色权限后端模型
    /// </summary>
    [Table("SysFileRolePermission")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysFileRolePermission : BaseEntity
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 文件Id
        /// </summary>
        public int FileId { get; set; }
        /// <summary>
        /// 权限Id
        /// </summary>
        public int PermissionId { get; set; }
    }
}
