using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agile.Models.ViewModels
{
    /// <summary>
    /// 数据字典详情前端模型
    /// </summary>
    public class SysDictionaryDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// 字典id
        /// </summary>
        [Display(Name = "字典id")]
        public int DictionaryId { get; set; }
        /// <summary>
        /// 字典项名称
        /// </summary>
        [Display(Name = "字典项名称")]
        public string DictionaryKey { get; set; }
        /// <summary>
        /// 字典项代码
        /// </summary>
        [Display(Name = "字典项代码")]
        public string DictionaryValue { get; set; }
    }
}
