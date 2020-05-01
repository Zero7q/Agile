using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Infrastructure
{
    /// <summary>
    /// 权限特性
    /// </summary>
    public class PermissionAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissionCode">权限代码</param>
        public PermissionAttribute(string permissionCode)
        {
            PermissionCode = permissionCode;
        }

        /// <summary>
        /// 权限代码
        /// </summary>
        public string PermissionCode { get; set; }
    }
}
