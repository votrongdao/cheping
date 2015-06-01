using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class FindDataEntity
    {

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public List<RecordItem> FilterItems { get; set; }

    }
}