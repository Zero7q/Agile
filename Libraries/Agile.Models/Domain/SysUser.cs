using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 用户信息后端模型
    /// </summary>
    [Table("SysUser")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysUser : BaseEntity
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int UserState { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public int IsOnline { get; set; }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 最近登录IP
        /// </summary>
        public string LastLoginIp { get; set; }
    }
}
