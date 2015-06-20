// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  1:13 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  1:18 PM
// ***********************************************************************
// <copyright file="QueryTranscationRecordRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     Class QueryTranscationRecordRequest.
    /// </summary>
    public class QueryTranscationRecordRequest
    {
        /// <summary>
        ///     上牌时间
        /// </summary>
        [Required, JsonProperty("licenseTime")]
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     最大里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("maxMileage")]
        public int MaxMileage { get; set; }

        /// <summary>
        ///     最小里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("minMileage")]
        public int MinMileage { get; set; }

        /// <summary>
        ///     车型Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("modelId")]
        public int ModelId { get; set; }
    }
}