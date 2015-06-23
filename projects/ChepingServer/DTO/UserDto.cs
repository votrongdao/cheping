// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  9:41 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-23  8:36 PM
// ***********************************************************************
// <copyright file="UserDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using ChepingServer.Enum;
using ChepingServer.Models;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     UserEx.
    /// </summary>
    public static class UserEx
    {
        /// <summary>
        ///     To the dto.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>UserDto.</returns>
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Cellphone = user.Cellphone,
                Id = user.Id,
                JobTitle = user.JobTitle,
                OutletId = user.OutletId,
                UserCode = user.UserCode,
                UserName = user.UserName,
                ValuerGroup = user.ValuerGroup,
                Available = user.Available,
                HangOn = user.HangOn,
                OutletName = ""
            };
        }

        /// <summary>
        ///     To the dto.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="outletName">Name of the outlet.</param>
        /// <returns>UserDto.</returns>
        public static UserDto ToDto(this User user, string outletName)
        {
            return new UserDto
            {
                Cellphone = user.Cellphone,
                Id = user.Id,
                JobTitle = user.JobTitle,
                OutletId = user.OutletId,
                UserCode = user.UserCode,
                UserName = user.UserName,
                ValuerGroup = user.ValuerGroup,
                Available = user.Available,
                HangOn = user.HangOn,
                OutletName = outletName
            };
        }
    }

    /// <summary>
    ///     UserDto.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        ///     是否正常使用
        /// </summary>
        [Required, JsonProperty("available")]
        public bool Available { get; set; }

        /// <summary>
        ///     用户手机号
        /// </summary>
        [Required, CellphoneFormat, JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        /// <summary>
        ///     是否挂起
        /// </summary>
        [Required, JsonProperty("hangOn")]
        public bool HangOn { get; set; }

        /// <summary>
        ///     用户Id，非必需情况，传默认值0
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     用户职位
        /// </summary>
        [Required, AvailableValues(JobTitle.Purchaser, JobTitle.Valuer, JobTitle.Querying, JobTitle.Director, JobTitle.Manager), JsonProperty("jobTitle")]
        public JobTitle JobTitle { get; set; }

        /// <summary>
        ///     用户所属网点
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("outletId")]
        public int OutletId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the outlet.
        /// </summary>
        /// <value>The name of the outlet.</value>
        public string OutletName { get; set; }

        /// <summary>
        ///     用户代码
        /// </summary>
        [Required, StringLength(100, MinimumLength = 3), JsonProperty("userCode")]
        public string UserCode { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [Required, StringLength(100, MinimumLength = 2), JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        ///     用户Id，非必需情况，传默认值0
        /// </summary>
        [Required, JsonProperty("valuerGroup")]
        public string ValuerGroup { get; set; }
    }
}