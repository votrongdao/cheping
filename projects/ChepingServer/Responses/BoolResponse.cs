// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  11:46 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  2:23 PM
// ***********************************************************************
// <copyright file="BoolResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Responses
{
    /// <summary>
    ///     BoolResponse.
    /// </summary>
    public class BoolResponse
    {
        /// <summary>
        ///     Boolean 值
        /// </summary>
        [Required, JsonProperty("result")]
        public bool Result { get; set; }
    }
}