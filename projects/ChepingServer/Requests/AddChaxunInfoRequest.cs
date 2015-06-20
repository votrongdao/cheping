// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  11:37 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  11:42 PM
// ***********************************************************************
// <copyright file="AddChaxunInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    /// Class AddChaxunInfoRequest.
    /// </summary>
    public class AddChaxunInfoRequest
    {
        /// <summary>
        /// 债券情况备注
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("bondsNote")]
        public string BondsNote { get; set; }

        /// <summary>
        /// 债券情况
        /// </summary>
        [Required, JsonProperty("bondsState")]
        public bool BondsState { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        /// 理赔记录备注
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("claimNote")]
        public string ClaimNote { get; set; }

        /// <summary>
        /// 理赔记录
        /// </summary>
        [Required, JsonProperty("claimState")]
        public bool ClaimState { get; set; }

        /// <summary>
        /// 养护记录备注
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("conservationNote")]
        public string ConservationNote { get; set; }

        /// <summary>
        /// 养护记录
        /// </summary>
        [Required, JsonProperty("conservationState")]
        public bool ConservationState { get; set; }

        /// <summary>
        /// 最后养护时间
        /// </summary>
        [Required, JsonProperty("lastConservationTime")]
        
        public DateTime LastConservationTime { get; set; }

        /// <summary>
        /// 真实里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("realMileage")]
        public int RealMileage { get; set; }

        /// <summary>
        /// 违章情况备注
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("violationNote")]
        
        public string ViolationNote { get; set; }

        /// <summary>
        /// 违章情况
        /// </summary>
        [Required, JsonProperty("violationState")]
        public bool ViolationState { get; set; }
    }
}