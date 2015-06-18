// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:15 PM
// ***********************************************************************
// <copyright file="Case.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    public class Case
    {
        public bool? Abandon { get; set; }

        public string AbandonReason { get; set; }

        public int CaseType { get; set; }

        public int? DirectorId { get; set; }

        public int Id { get; set; }

        public int? ManagerId { get; set; }

        public int OutletId { get; set; }

        public int PurchasePrice { get; set; }

        public int PurchaserId { get; set; }

        public int? QueryingId { get; set; }

        public string SerialId { get; set; }

        public int State { get; set; }

        public int? ValuerId { get; set; }

        public int VehicleInfoId { get; set; }

        public int VehicleInspecId { get; set; }
    }
}