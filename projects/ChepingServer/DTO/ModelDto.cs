// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  11:06 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:32 PM
// ***********************************************************************
// <copyright file="ModelDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using ChepingServer.Models;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    public static class ModelEx
    {
        public static ModelDto ToDto(this Model model)
        {
            return new ModelDto
            {
                Brand = model.Brand,
                Id = model.Id,
                Modeling = model.Modeling,
                Price = model.Price,
                Series = model.Series,
                Available = model.Available
            };
        }
    }

    /// <summary>
    ///     ModelDto.
    /// </summary>
    public class ModelDto
    {
        /// <summary>
        ///     是否正常使用
        /// </summary>
        [Required, JsonProperty("available")]
        public bool Available { get; set; }

        /// <summary>
        ///     品牌
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        ///     车型Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     车型年款
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("modeling")]
        public string Modeling { get; set; }

        /// <summary>
        ///     指导价
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        ///     车系
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("series")]
        public string Series { get; set; }
    }
}