using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Roles
{
    /// <summary>
    /// 角色表后端模型
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
