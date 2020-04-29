using Agile.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Organizations
{
    /// <summary>
    /// 组织机构表后端模型
    /// </summary>
    public class Organization : BaseEntity
    {
        /// <summary>
        /// 父节点id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }
    }
}
