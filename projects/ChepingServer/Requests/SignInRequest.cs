// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  2:13 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  2:14 PM
// ***********************************************************************
// <copyright file="SignInRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    public class SignInRequest
    {
        /// <summary>
        ///     用户登录名
        /// </summary>
        [Required, CellphoneFormat, JsonProperty("loginName")]
        public string LoginName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [Required, StringLength(18, MinimumLength = 6), SimplePasswordFormat, JsonProperty("password")]
        public string Password { get; set; }
    }
}