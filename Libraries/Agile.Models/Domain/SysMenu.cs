using Agile.Core;
using Agile.Data;
using Agile.Models.Infrastructure;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 菜单后端模型
    /// </summary>
    [Table("SysMenu")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysMenu : BaseEntity
    {
        /// <summary>
        /// 菜单节点
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// 父节点id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单打开地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType Type { get; set; }
    }
}
