// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  2:31 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  9:33 AM
// ***********************************************************************
// <copyright file="TranscationRecordDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using ChepingServer.Models;
using Newtonsoft.Json;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     TranscationRecordEx.
    /// </summary>
    public static class TranscationRecordEx
    {
        /// <summary>
        ///     To the dto.
        /// </summary>
        /// <param name="transcationRecord">The transcation record.</param>
        /// <returns>TranscationRecordDto.</returns>
        public static TranscationRecordDto ToDto(this TranscationRecord transcationRecord)
        {
            return new TranscationRecordDto
            {
                Id = transcationRecord.Id,
                InnerColor = transcationRecord.InnerColor,
                OuterColor = transcationRecord.OuterColor,
                Mileage = transcationRecord.Mileage,
                ModelId = transcationRecord.ModelId,
                Price = transcationRecord.Price,
                LicenseTime = transcationRecord.LicenseTime,
                Source = transcationRecord.Source
            };
        }
    }

    /// <summary>
    ///     TranscationRecordDto.
    /// </summary>
    public class TranscationRecordDto
    {
        /// <summary>
        ///     交易记录Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     内饰颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("innerColor")]
        public int InnerColor { get; set; }

        /// <summary>
        ///     上牌时间
        /// </summary>
        [Required, JsonProperty("licenseTime")]
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     里程数
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("mileage")]
        public int Mileage { get; set; }

        /// <summary>
        ///     车型Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("modelId")]
        public int ModelId { get; set; }

        /// <summary>
        ///     外饰颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("outerColor")]
        public int OuterColor { get; set; }

        /// <summary>
        ///     成交价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        ///     来源
        /// </summary>
        [Required, StringLength(200, MinimumLength = 2), JsonProperty("source")]
        public string Source { get; set; }
    }
}