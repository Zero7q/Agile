using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Roles
{
    /// <summary>
    /// 角色组织机构关联表后端模型
    /// </summary>
    public class RoleOrganization : BaseEntity
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 机构id
        /// </summary>
        public int OrganizationId { get; set; }
    }
}
