// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  7:11 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  7:13 AM
// ***********************************************************************
// <copyright file="AddPhotoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     AddPhotoRequest.
    /// </summary>
    public class AddPhotoRequest
    {
        /// <summary>
        ///     事项Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     图片内容
        /// </summary>
        [Required, MinLength(1), JsonProperty("content")]
        public string Content { get; set; }
    }
}