// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  12:29 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:40 AM
// ***********************************************************************
// <copyright file="CityDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using ChepingServer.Models;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    public static class CityEx
    {
        public static CityDto ToDto(this City city)
        {
            return new CityDto
            {
                Id = city.Id,
                CityName = city.CityName,
                ProvinceName = city.ProvinceName
            };
        }
    }

    /// <summary>
    ///     CityDto.
    /// </summary>
    public class CityDto
    {
        /// <summary>
        ///     城市名
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("cityName")]
        public string CityName { get; set; }

        /// <summary>
        ///     城市Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     省份名
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("provinceName")]
        public string ProvinceName { get; set; }
    }
}