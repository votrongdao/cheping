// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  12:13 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  7:17 PM
// ***********************************************************************
// <copyright file="AddCaseRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChepingServer.Enum;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.Requests
{
    /// <summary>
    ///     AddCaseRequest.
    /// </summary>
    public class AddCaseRequest
    {
        /// <summary>
        ///     品牌名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("brandName")]
        public string BrandName { get; set; }

        /// <summary>
        ///     事项类型，10 =&gt; 轿车, 20 =&gt; 跑车, 30 =&gt; 房车, 40 =&gt; 越野车, 50 =&gt; 商务用车
        /// </summary>
        /// <value>The type of the case.</value>
        [Required, AvailableValues(CarType.Jiao, CarType.Pao, CarType.Fang, CarType.Yueye, CarType.ShangWu), JsonProperty("caseType")]
        public CarType CaseType { get; set; }

        /// <summary>
        ///     合作方式
        /// </summary>
        [Required, AvailableValues(CooperationMethod.Yijiuqisan, CooperationMethod.Ziying), JsonProperty("cooperationMethod")]
        public CooperationMethod CooperationMethod { get; set; }

        /// <summary>
        ///     表显里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("displayMileage")]
        public int DisplayMileage { get; set; }

        /// <summary>
        ///     心理价格
        /// </summary>
        [JsonProperty("expectedPrice")]
        public int? ExpectedPrice { get; set; }

        /// <summary>
        ///     出厂时间
        /// </summary>
        [JsonProperty("factoryTime")]
        public DateTime? FactoryTime { get; set; }

        /// <summary>
        ///     内部颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("innerColor")]
        public int InnerColor { get; set; }

        /// <summary>
        ///     牌照所在地
        /// </summary>
        [JsonProperty("licenseLocation")]
        public int? LicenseLocation { get; set; }

        /// <summary>
        ///     上牌时间
        /// </summary>
        [Required, JsonProperty("licenseTime")]
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     车型名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("modelName")]
        public string ModelName { get; set; }

        /// <summary>
        ///     改装内容
        /// </summary>
        [JsonProperty("modifiedContent")]
        public string ModifiedContent { get; set; }

        /// <summary>
        ///     外部颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("outerColor")]
        public int OuterColor { get; set; }

        /// <summary>
        ///     照片id
        /// </summary>
        [Required, JsonProperty("photoIds")]
        // ReSharper disable once CollectionNeverUpdated.Global
        public List<int> PhotoIds { get; set; }

        /// <summary>
        ///     车系名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("seriesName")]
        public string SeriesName { get; set; }

        /// <summary>
        ///     车辆所在地
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("vehicleLocation")]
        public int VehicleLocation { get; set; }
    }
}