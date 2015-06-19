// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  1:25 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  1:39 AM
// ***********************************************************************
// <copyright file="OutletDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using ChepingServer.Models;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     OutletEx.
    /// </summary>
    public static class OutletEx
    {
        /// <summary>
        ///     To the dto.
        /// </summary>
        /// <param name="outlet">The outlet.</param>
        /// <returns>OutletDto.</returns>
        public static OutletDto ToDto(this Outlet outlet)
        {
            return new OutletDto
            {
                Address = outlet.Address,
                Cellphone = outlet.Cellphone,
                CityId = outlet.CityId,
                CityName = outlet.CityName,
                Contact = outlet.CityName,
                Id = outlet.Id,
                OutletName = outlet.OutletName,
                ProvinceName = outlet.ProvinceName,
                Available = outlet.Available
            };
        }
    }

    /// <summary>
    ///     OutletDto.
    /// </summary>
    public class OutletDto
    {

        /// <summary>
        ///     是否正常使用
        /// </summary>
        [Required, JsonProperty("available")]
        public bool Available { get; set; }

        /// <summary>
        ///     网点地址
        /// </summary>
        [Required, StringLength(300, MinimumLength = 2), JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        ///     网点电话
        /// </summary>
        [Required, CellphoneFormat, JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        /// <summary>
        ///     所在城市Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("cityId")]
        public int CityId { get; set; }

        /// <summary>
        ///     所在城市名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("cityName")]
        public string CityName { get; set; }

        /// <summary>
        ///     联系人
        /// </summary>
        [Required, StringLength(50, MinimumLength = 2), JsonProperty("contact")]
        public string Contact { get; set; }

        /// <summary>
        ///     网点Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     网点名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("outletName")]
        public string OutletName { get; set; }

        /// <summary>
        ///     所在省份名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("provinceName")]
        public string ProvinceName { get; set; }
    }
}