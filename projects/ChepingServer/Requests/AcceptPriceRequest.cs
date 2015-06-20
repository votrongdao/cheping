// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  9:02 AM
// 
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:50 PM
// ***********************************************************************
// <copyright file="AcceptPriceRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     AcceptPriceRequest.
    /// </summary>
    public class AcceptPriceRequest
    {
        /// <summary>
        ///     相关事项Id
        /// </summary>
        /// <value>The case identifier.</value>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     最终确定价格
        /// </summary>
        /// <value>The price.</value>
        [Required, Range(0, int.MaxValue), JsonProperty("price")]
        public int Price { get; set; }
    }
}