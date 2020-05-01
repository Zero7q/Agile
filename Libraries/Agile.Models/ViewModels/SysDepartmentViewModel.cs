using Agile.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agile.Models.ViewModels
{
    /// <summary>
    /// 部门前端模型
    /// </summary>
    public class SysDepartmentViewModel : BaseViewModel
    {
        /// <summary>
        /// 上级部门
        /// </summary>
        [Display(Name = "上级部门")]
        public int ParentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Display(Name = "部门名称")]
        public string DepartmentName { get; set; }
    }
}
