// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-27  7:14 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  8:14 PM
// ***********************************************************************
// <copyright file="AddQiatanInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     AddQiatanInfoRequest.
    /// </summary>
    public class AddQiatanInfoRequest
    {
        /// <summary>
        ///     订单编号
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     车主姓名
        /// </summary>
        [Required, StringLength(50, MinimumLength = 1), JsonProperty("vehicleOwner")]
        public string VehicleOwner { get; set; }

        /// <summary>
        ///     车主银行卡开户行
        /// </summary>
        [Required, StringLength(50, MinimumLength = 1), JsonProperty("vehicleOwnerBank")]
        public string VehicleOwnerBank { get; set; }

        /// <summary>
        ///     车主银行卡号
        /// </summary>
        [Required, StringLength(50, MinimumLength = 1), JsonProperty("vehicleOwnerBankCardNo")]
        public string VehicleOwnerBankCardNo { get; set; }

        /// <summary>
        ///     车主手机号
        /// </summary>
        [JsonProperty("vehicleOwnerCellphone")]
        public string VehicleOwnerCellphone { get; set; }

        /// <summary>
        ///     车主身份证号
        /// </summary>
        [JsonProperty("vehicleOwnerIdNo")]
        public string VehicleOwnerIdNo { get; set; }
    }
}