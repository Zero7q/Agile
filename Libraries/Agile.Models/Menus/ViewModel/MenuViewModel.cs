using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Agile.Models.Menus.ViewModel
{
    /// <summary>
    /// 菜单前端模型
    /// </summary>
    public partial class MenuViewModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [DisplayName("ID")]
        public int Id { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        [DisplayName("父节点id")]
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [DisplayName("菜单名称")]
        public string Name { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]
        public string Icon { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        [DisplayName("菜单地址")]
        public string OpenUrl { get; set; }

    }

    /// <summary>
    /// 菜单前段模型
    /// </summary>
    public partial class MenuViewModel
    {
        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<MenuViewModel> SubMenus { get; set; }
        /// <summary>
        /// 父节点列表
        /// </summary>
        public IEnumerable<SelectListItem> ParentSelectItems { get; set; }
    }
}
