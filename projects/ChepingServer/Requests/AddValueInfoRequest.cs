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
        /// Gets or sets the preferential price.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("preferentialPrice")]
        public int PreferentialPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum mileage.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("maxMileage")]
        public int MaxMileage { get; set; }

        /// <summary>
        /// Gets or sets the minimum mileage.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("minMileage")]
        public int MinMileage { get; set; }

        /// <summary>
        /// Gets or sets the sale grade.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("saleGrade")]
        public int SaleGrade { get; set; }

        /// <summary>
        /// Gets or sets the web average price.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webAveragePrice")]
        public int WebAveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the web price.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webPrice")]
        public int WebPrice { get; set; }

        /// <summary>
        /// Gets or sets the floor price.
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("floorPrice")]
        public int FloorPrice { get; set; }

    }
}