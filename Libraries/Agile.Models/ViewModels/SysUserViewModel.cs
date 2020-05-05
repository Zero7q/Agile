using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agile.Models.ViewModels
{
    /// <summary>
    /// 用户前端模型
    /// </summary>
    public partial class SysUserViewModel : BaseViewModel
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [Display(Name = "登录账号")]
        public string LoginId { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Display(Name = "登录密码")]
        public string LoginPassword { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [Display(Name = "用户状态")]
        public int UserState { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        [Display(Name = "是否在线")]
        public int IsOnline { get; set; }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        [Display(Name = "最近登录时间")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 最近登录IP
        /// </summary>
        [Display(Name = "最近登录IP")]
        public string LastLoginIp { get; set; }
    }

    /// <summary>
    /// 用户前端模型 扩展
    /// </summary>
    public partial class SysUserViewModel
    {
        [Display(Name = "所属部门")]
        public int DepartmentId { get; set; }
    }
}
