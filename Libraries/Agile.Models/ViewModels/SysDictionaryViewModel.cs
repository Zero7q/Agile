using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agile.Models.ViewModels
{
    /// <summary>
    /// 数据字典前端模型
    /// </summary>
    public class SysDictionaryViewModel : BaseViewModel
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        [Display(Name = "字典名称")]
        public string DictionaryName { get; set; }
        /// <summary>
        /// 字典代码
        /// </summary>
        [Display(Name = "字典代码")]
        public string DictionaryCode { get; set; }
    }
}
