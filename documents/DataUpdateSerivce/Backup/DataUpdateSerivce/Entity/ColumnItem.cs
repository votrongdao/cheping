using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class ColumnItem
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型 SQLDbType枚举ToString
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 类型长度
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 获取首长
        /// </summary>
        /// <returns></returns>
        public int GetLegth() {
            if (this.Type==null)
            {
                return 0;
            }
            else if ("decimal".Equals(this.Type.ToLower()))
            {

                return int.Parse(Length.Split(',')[0]);
            }
            else
            {
                return int.Parse(Length);
            }
           
        }
        /// <summary>
        /// 获取精度
        /// </summary>
        /// <returns></returns>
        public int GetLegth1() {
            if (this.Type == null)
            {
                return 0;
            }
            else if ("decimal".Equals(this.Type.ToLower()))
            {

                return int.Parse(Length.Split(',')[1]);
            }
            else
            {
                return 0;
            }
        }
    }
}