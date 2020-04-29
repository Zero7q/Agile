using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Users
{
    /// <summary>
    /// 用户表后端模型
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
    }
}
