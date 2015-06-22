// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  2:23 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  2:23 PM
// ***********************************************************************
// <copyright file="IntResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Responses
{
    /// <summary>
    ///     IntResponse.
    /// </summary>
    public class IntResponse
    {
        /// <summary>
        ///     int 值
        /// </summary>
        [Required, JsonProperty("result")]
        public bool Result { get; set; }
    }
}