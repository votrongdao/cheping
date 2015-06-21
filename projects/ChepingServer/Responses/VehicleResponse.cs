// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-21  12:21 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-21  1:00 PM
// ***********************************************************************
// <copyright file="VehicleResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.ComponentModel.DataAnnotations;
using ChepingServer.Enum;
using Moe.AspNet.Validations;
using Newtonsoft.Json;

namespace ChepingServer.Responses
{
    /// <summary>
    ///     VehicleResponse.
    /// </summary>
    public class VehicleResponse
    {
        /// <summary>
        ///     是否确认放弃
        /// </summary>
        [JsonProperty("abandon")]
        public bool? Abandon { get; set; }

        /// <summary>
        ///     放弃原因
        /// </summary>
        [JsonProperty("abandonReason")]
        public string AbandonReason { get; set; }

        /// <summary>
        ///     品牌名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("brandName")]
        public string BrandName { get; set; }

        /// <summary>
        ///     事项类型，10 => 轿车, 20 => 跑车, 30 => 房车, 40 => 越野车, 50 => 商务用车
        /// </summary>
        [Required, AvailableValues(CarType.Jiao, CarType.Pao, CarType.Fang, CarType.Yueye, CarType.ShangWu), JsonProperty("caseType")]
        public CarType CaseType { get; set; }

        /// <summary>
        ///     合作方式
        /// </summary>
        [Required, AvailableValues(CooperationMethod.Yijiuqisan, CooperationMethod.Ziying), JsonProperty("cooperationMethod")]
        public CooperationMethod CooperationMethod { get; set; }

        /// <summary>
        ///     订单创建时间
        /// </summary>
        [Required, JsonProperty("createTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     总监Id
        /// </summary>
        [JsonProperty("directorId")]
        public int? DirectorId { get; set; }

        /// <summary>
        ///     表显里程
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("displayMileage")]
        public int DisplayMileage { get; set; }

        /// <summary>
        ///     心理价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("expectedPrice")]
        public int ExpectedPrice { get; set; }

        /// <summary>
        ///     出厂时间
        /// </summary>
        [Required, JsonProperty("factoryTime")]
        public DateTime FactoryTime { get; set; }

        /// <summary>
        ///     Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     内部颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("innerColor")]
        public int InnerColor { get; set; }

        /// <summary>
        ///     牌照所在地
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("licenseLocation")]
        public int LicenseLocation { get; set; }

        /// <summary>
        ///     上牌时间
        /// </summary>
        [Required, JsonProperty("licenseTime")]
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     总经理Id
        /// </summary>
        [JsonProperty("managerId")]
        public int? ManagerId { get; set; }

        /// <summary>
        ///     车型Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("modelId")]
        public int ModelId { get; set; }

        /// <summary>
        ///     车型名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("modelName")]
        public string ModelName { get; set; }

        /// <summary>
        ///     改装内容
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("modifiedContent")]
        public string ModifiedContent { get; set; }

        /// <summary>
        ///     外部颜色
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("outerColor")]
        public int OuterColor { get; set; }

        /// <summary>
        ///     网点Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("outletId")]
        public int OutletId { get; set; }

        /// <summary>
        ///     采购价格
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("purchasePrice")]
        public int PurchasePrice { get; set; }

        /// <summary>
        ///     采购员Id
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("purchaserId")]
        public int PurchaserId { get; set; }

        /// <summary>
        ///     查询师Id
        /// </summary>
        [JsonProperty("queryingId")]
        public int? QueryingId { get; set; }

        /// <summary>
        ///     事项序列号
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("serialId")]
        public string SerialId { get; set; }

        /// <summary>
        ///     车系名称
        /// </summary>
        [Required, StringLength(200, MinimumLength = 1), JsonProperty("seriesName")]
        public string SeriesName { get; set; }

        /// <summary>
        ///     事项状态, 10 => 评估中, 20 => 审核中, 30 => 审核失败, 40 => 验车中, 50 => 验车失败, 60 => 查询补充信息中, 70 => 收购中, 80 => 收购失败, 90 => 付款中, 100 => 入库中, 110 => 放弃确认中, 120 => 放弃已确认
        /// </summary>
        [Required, AvailableValues(CarType.Jiao, CarType.Pao, CarType.Fang, CarType.Yueye, CarType.ShangWu), JsonProperty("state")]
        public State State { get; set; }

        /// <summary>
        ///     评估师Id
        /// </summary>
        [JsonProperty("valuerId")]
        public int? ValuerId { get; set; }

        /// <summary>
        ///     车辆信息编号
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("vehicleInfoId")]
        public int VehicleInfoId { get; set; }

        /// <summary>
        ///     车辆评估查询信息编号
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("vehicleInspecId")]
        public int VehicleInspecId { get; set; }

        /// <summary>
        ///     车辆所在地
        /// </summary>
        [Required, Range(0, int.MaxValue), JsonProperty("vehicleLocation")]
        public int VehicleLocation { get; set; }
    }
}