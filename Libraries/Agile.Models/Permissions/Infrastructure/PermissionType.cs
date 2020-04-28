using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Models.Permissions.Infrastructure
{
    /// <summary>
    /// 权限类型枚举
    /// </summary>
    public enum PermissionType
    {
        /// <summary>
        /// 添加
        /// </summary>
        [EnumMember(Value = "add")]
        Add = 0,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumMember(Value = "delete")]
        Delete = 1,
        /// <summary>
        /// 查看
        /// </summary>
        [EnumMember(Value = "view")]
        View = 2,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumMember(Value = "edit")]
        Edit = 3,
        /// <summary>
        /// 导出
        /// </summary>
        [EnumMember(Value = "export")]
        Export = 4,
        /// <summary>
        /// 导入
        /// </summary>
        [EnumMember(Value = "import")]
        Import = 5,
    }
}
