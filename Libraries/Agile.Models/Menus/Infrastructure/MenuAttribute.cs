using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Menus.Infrastructure
{
    /// <summary>
    /// 菜单特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MenuAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuType">菜单类型</param>
        /// <param name="name">菜单名称</param>
        /// <param name="openUrl">菜单地址</param>
        /// <param name="icon">菜单图标</param>
        public MenuAttribute(MenuType menuType, string name = "", string openUrl = "", string icon = "layui-icon layui-icon-home")
        {
            Name = name;
            OpenUrl = openUrl;
            MenuType = menuType;
            Icon = icon;
        }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType MenuType { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单打开地址
        /// </summary>
        public string OpenUrl { get; set; }
    }
}
