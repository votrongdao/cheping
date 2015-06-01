using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class AddFieldEntity
    {

        /// <summary>
        /// 需要操作的表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public int OperateID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FieldType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldLength { get; set; }
    }
}