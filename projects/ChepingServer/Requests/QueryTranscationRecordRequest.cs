using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    /// Class QueryTranscationRecordRequest.
    /// </summary>
    public class QueryTranscationRecordRequest
    {
        /// <summary>
        /// 车型Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("modelId")]
        public int ModelId { get; set; }
        /// <summary>
        /// 最小里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("minMileage")]
        public int MinMileage { get; set; }
        /// <summary>
        /// 最大里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("maxMileage")]
        public int MaxMileage { get; set; }
        /// <summary>
        /// 上牌时间
        /// </summary>
        [Required, JsonProperty("licenseTime")]
        public DateTime LicenseTime { get; set; }
    }
}