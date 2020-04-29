using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Users
{
    /// <summary>
    /// 用户组织机构关联表后端模型
    /// </summary>
    public class UserOrganization : BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 机构id
        /// </summary>
        public int OrganizationId { get; set; }
    }
}
