// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  1:32 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  1:38 PM
// ***********************************************************************
// <copyright file="StringResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Responses
{
    /// <summary>
    ///     StringResponse.
    /// </summary>
    public class StringResponse
    {
        /// <summary>
        ///     string 值
        /// </summary>
        /// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
        [Required, JsonProperty("result")]
        public string Result { get; set; }
    }
}