// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  12:13 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:51 PM
// ***********************************************************************
// <copyright file="AddYancheInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     AddYancheInfoRequest.
    /// </summary>
    public class AddYancheInfoRequest
    {
        /// <summary>
        ///     对应的事项Id
        /// </summary>
        /// <value>The case identifier.</value>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     发动机编号
        /// </summary>
        /// <value>The engine code.</value>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("engineCode")]
        public string EngineCode { get; set; }

        /// <summary>
        ///     保单号
        /// </summary>
        /// <value>The insurance code.</value>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("insuranceCode")]
        public string InsuranceCode { get; set; }

        /// <summary>
        ///     车牌号
        /// </summary>
        /// <value>The license code.</value>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("licenseCode")]
        public string LicenseCode { get; set; }

        /// <summary>
        ///     车架编号
        /// </summary>
        /// <value>The vin code.</value>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("vinCode")]
        public string VinCode { get; set; }
    }
}