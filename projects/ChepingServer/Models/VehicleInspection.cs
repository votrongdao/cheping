// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:02 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:22 PM
// ***********************************************************************
// <copyright file="VehicleInspection.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    public class VehicleInspection
    {
        public string BondsNote { get; set; }

        public bool? BondsState { get; set; }

        public string ClaimNote { get; set; }

        public bool? ClaimState { get; set; }

        public string ConservationNote { get; set; }

        public bool? ConservationState { get; set; }

        public string EngineCode { get; set; }

        public int Id { get; set; }

        public string InsuranceCode { get; set; }

        public DateTime? LastConservationTime { get; set; }

        public string LicenseCode { get; set; }

        public int? RealMileage { get; set; }

        public string VinCode { get; set; }

        public string ViolationNote { get; set; }

        public bool? ViolationState { get; set; }
    }
}