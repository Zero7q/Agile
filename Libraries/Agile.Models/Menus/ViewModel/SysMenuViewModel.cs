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
    public partial class SysMenuViewModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [DisplayName("ID")]
        public int Id { get; set; }
        /// <summary>
        /// 上级节点
        /// </summary>
        [DisplayName("上级节点")]
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
        public string Url { get; set; }
    }

    /// <summary>
    /// 菜单前段模型
    /// </summary>
    public partial class SysMenuViewModel
    {
        /// <summary>
        /// 展开树
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<SysMenuViewModel> SubMenus { get; set; }
        /// <summary>
        /// 父节点列表
        /// </summary>
        public IEnumerable<SelectListItem> ParentSelectItems { get; set; }
    }
}
