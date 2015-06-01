using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    /// <summary>
    /// 添加表实体
    /// </summary>
    [Serializable]
    public class AddTableEntity
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
        /// 列，Value值不用填写
        /// </summary>
        public List<ColumnItem> Columns { get; set; }
    }
}