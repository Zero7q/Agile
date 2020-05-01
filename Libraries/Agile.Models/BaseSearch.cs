using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models
{
    /// <summary>
    /// 前端搜索模型
    /// </summary>
    public class BaseSearch
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int Limit { get; set; }
    }
}
