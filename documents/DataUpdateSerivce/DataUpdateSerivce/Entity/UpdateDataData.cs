using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{

    /// <summary>
    /// date
    /// </summary>
    [Serializable]
    public class UpdateDataData {
        /// <summary>
        /// 需要操作的表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public int OperateID { get; set; }
        /// <summary>
        /// 操作 1、2 新增或修改 3、删除
        /// </summary>
        public int Operate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 数据列名和值得对应集合
        /// </summary>
        public List<RecordItem> Record { get; set; }
    }



 

}