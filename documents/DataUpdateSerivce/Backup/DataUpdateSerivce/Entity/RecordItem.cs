using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class RecordItem
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 类型 SQLDbType枚举ToString
        /// </summary>
        public string Type { get; set; }
       /// <summary>
       /// 类型长度
       /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 是否是可以修改的数据
        /// </summary>
        public bool IsNotBeInsertOrUpdate { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
   
    }
}