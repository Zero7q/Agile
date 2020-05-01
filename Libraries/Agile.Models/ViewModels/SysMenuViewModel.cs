using Agile.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agile.Models.ViewModels
{
    /// <summary>
    /// 菜单前端模型
    /// </summary>
    public class SysMenuViewModel : BaseViewModel
    {
        /// <summary>
        /// 上级菜单
        /// </summary>
        [Display(Name = "上级菜单")]
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name = "菜单名称")]
        public string Name { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [Display(Name = "菜单图标")]
        public string Icon { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        [Display(Name = "菜单地址")]
        public string Url { get; set; }
        /// <summary>
        /// 打开菜单节点
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// 子菜单集合
        /// </summary>
        public List<SysMenuViewModel> SubMenus { get; set; }
        /// <summary>
        /// 父菜单列表
        /// </summary>
        public IEnumerable<SelectListItem> ParentSelectItems { get; set; }
    }
}
