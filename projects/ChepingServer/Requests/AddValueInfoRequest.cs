// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  9:02 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  9:09 AM
// ***********************************************************************
// <copyright file="AddValueInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using ChepingServer.Enum;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     Class AddValueInfoRequest.
    /// </summary>
    public class AddValueInfoRequest
    {
        /// <summary>
        ///     相关事项Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     销售底价
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("floorPrice")]
        public int FloorPrice { get; set; }

        /// <summary>
        ///     查询最大里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("maxMileage")]
        public int MaxMileage { get; set; }

        /// <summary>
        ///     查询最小里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("minMileage")]
        public int MinMileage { get; set; }

        /// <summary>
        ///     4S店优惠价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("preferentialPrice")]
        public int PreferentialPrice { get; set; }

        /// <summary>
        /// 评估价格或者实际采购价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        ///     售卖等级
        /// </summary>
        [Required, AvailableValues(SaleGrade.A, SaleGrade.B, SaleGrade.C, SaleGrade.D), JsonProperty("saleGrade")]
        public SaleGrade SaleGrade { get; set; }

        /// <summary>
        ///     网络均价
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webAveragePrice")]
        public int WebAveragePrice { get; set; }

        /// <summary>
        ///     网上价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("webPrice")]
        public int WebPrice { get; set; }
    }
}