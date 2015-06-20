// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  12:13 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  9:03 AM
// ***********************************************************************
// <copyright file="PhotoDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     Class PhotoEx.
    /// </summary>
    public static class PhotoEx
    {
        /// <summary>
        ///     To the dto.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns>PhotoDto.</returns>
        public static PhotoDto ToDto(this PhotoDto photo)
        {
            return new PhotoDto
            {
                CaseId = photo.CaseId,
                Content = photo.Content,
                Id = photo.Id,
                UploadTime = photo.UploadTime
            };
        }
    }

    /// <summary>
    ///     Class PhotoDto.
    /// </summary>
    public class PhotoDto
    {
        /// <summary>
        ///     订单Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("caseId")]
        public int CaseId { get; set; }

        /// <summary>
        ///     图片内容
        /// </summary>
        [Required, JsonProperty("content")]
        public byte[] Content { get; set; }

        /// <summary>
        ///     图片Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     上传时间
        /// </summary>
        [JsonProperty("uploadTime")]
        public DateTime UploadTime { get; set; }
    }
}