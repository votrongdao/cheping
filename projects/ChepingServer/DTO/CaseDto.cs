// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  1:57 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  2:07 PM
// ***********************************************************************
// <copyright file="CaseDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Enum;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     CaseDto.
    /// </summary>
    public class CaseDto
    {
        /// <summary>
        ///     是否确认放弃
        /// </summary>
        public bool? Abandon { get; set; }

        /// <summary>
        ///     放弃原因
        /// </summary>
        public string AbandonReason { get; set; }

        /// <summary>
        ///     事项类型，10 => 轿车, 20 => 跑车, 30 => 房车, 40 => 越野车, 50 => 商务用车
        /// </summary>
        public CarType CaseType { get; set; }

        /// <summary>
        ///     总监Id
        /// </summary>
        public int? DirectorId { get; set; }

        /// <summary>
        ///     Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     总经理Id
        /// </summary>
        public int? ManagerId { get; set; }

        /// <summary>
        ///     网点Id
        /// </summary>
        public int OutletId { get; set; }

        /// <summary>
        ///     采购价格
        /// </summary>
        public int PurchasePrice { get; set; }

        /// <summary>
        ///     采购员Id
        /// </summary>
        public int PurchaserId { get; set; }

        /// <summary>
        ///     查询师Id
        /// </summary>
        public int? QueryingId { get; set; }

        /// <summary>
        ///     事项序列号
        /// </summary>
        public string SerialId { get; set; }

        /// <summary>
        ///     事项状态, 10 => 评估中, 20 => 审核中, 30 => 审核失败, 40 => 验车中, 50 => 验车失败, 60 => 查询补充信息中, 70 => 收购中, 80 => 收购失败, 90 => 付款中, 100 => 入库中, 110 => 放弃确认中, 120 => 放弃已确认
        /// </summary>
        public int State { get; set; }

        /// <summary>
        ///     评估师Id
        /// </summary>
        public int? ValuerId { get; set; }

        /// <summary>
        ///     车辆信息编号
        /// </summary>
        public int VehicleInfoId { get; set; }

        /// <summary>
        ///     车辆评估查询信息编号
        /// </summary>
        public int VehicleInspecId { get; set; }
    }
}