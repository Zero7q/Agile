using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Infrastructure
{
    /// <summary>
    /// 菜单特性
    /// </summary>
    public class MenuAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuType">菜单类型</param>
        /// <param name="name">菜单名称</param>
        /// <param name="url">菜单地址</param>
        /// <param name="icon">菜单图标</param>
        public MenuAttribute(MenuType menuType, string name, string url, string icon = "layui-icon layui-icon-home")
        {
            Name = name;
            Url = url;
            Type = menuType;
            Icon = icon;
        }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType Type { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }
    }
}
