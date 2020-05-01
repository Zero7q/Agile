using Agile.Core;
using Agile.Data;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Models.Domain
{
    /// <summary>
    /// 文件后端模型
    /// </summary>
    [Table("SysFile")]
    [DataBaseAttrobute(DataProviderType.MySql)]
    public class SysFile : BaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 文件后缀
        /// </summary>
        public string FileSuffix { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string FileMd5 { get; set; }
    }
}
