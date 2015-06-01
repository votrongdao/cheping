using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    /// <summary>
    /// 操作枚举
    /// </summary>
    [Serializable]
    public enum OperateEnum
    {
        /// <summary>
        /// 新增
        /// </summary>
        Insert = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Update = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delte = 3
    }
}