using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    /// Class AddValueInfoRequest.
    /// </summary>
    public class AddValueInfoRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("preferentialPrice")]
        public int PreferentialPrice { get; set; }

        /// <summary>
        /// 最大里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("maxMileage")]
        public int MaxMileage { get; set; }

        /// <summary>
        /// 最小里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("minMileage")]
        public int MinMileage { get; set; }

        /// <summary>
        /// 售卖等级
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("saleGrade")]
        public int SaleGrade { get; set; }

        /// <summary>
        /// 网络均价
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webAveragePrice")]
        public int WebAveragePrice { get; set; }

        /// <summary>
        /// 网上价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webPrice")]
        public int WebPrice { get; set; }

        /// <summary>
        /// 线下价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("floorPrice")]
        public int FloorPrice { get; set; }

    }
}