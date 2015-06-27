// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  8:14 PM
// ***********************************************************************
// <copyright file="VehicleInspection.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using ChepingServer.Enum;

namespace ChepingServer.Models
{
    /// <summary>
    ///     VehicleInspection.
    /// </summary>
    public class VehicleInspection
    {
        /// <summary>
        ///     Gets or sets the bonds note.
        /// </summary>
        /// <value>The bonds note.</value>
        public string BondsNote { get; set; }

        /// <summary>
        ///     Gets or sets the state of the bonds.
        /// </summary>
        /// <value>The state of the bonds.</value>
        public bool? BondsState { get; set; }

        /// <summary>
        ///     Gets or sets the claim note.
        /// </summary>
        /// <value>The claim note.</value>
        public string ClaimNote { get; set; }

        /// <summary>
        ///     Gets or sets the state of the claim.
        /// </summary>
        /// <value>The state of the claim.</value>
        public bool? ClaimState { get; set; }

        /// <summary>
        ///     Gets or sets the conservation note.
        /// </summary>
        /// <value>The conservation note.</value>
        public string ConservationNote { get; set; }

        /// <summary>
        ///     Gets or sets the state of the conservation.
        /// </summary>
        /// <value>The state of the conservation.</value>
        public bool? ConservationState { get; set; }

        /// <summary>
        ///     Gets or sets the engine code.
        /// </summary>
        /// <value>The engine code.</value>
        public string EngineCode { get; set; }

        /// <summary>
        ///     Gets or sets the floor price.
        /// </summary>
        /// <value>The floor price.</value>
        public int? FloorPrice { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the insurance code.
        /// </summary>
        /// <value>The insurance code.</value>
        public string InsuranceCode { get; set; }

        /// <summary>
        ///     Gets or sets the last conservation time.
        /// </summary>
        /// <value>The last conservation time.</value>
        public DateTime? LastConservationTime { get; set; }

        /// <summary>
        ///     Gets or sets the license code.
        /// </summary>
        /// <value>The license code.</value>
        public string LicenseCode { get; set; }

        /// <summary>
        ///     Gets or sets the maximum mileage.
        /// </summary>
        /// <value>The maximum mileage.</value>
        public int? MaxMileage { get; set; }

        /// <summary>
        ///     Gets or sets the minimum mileage.
        /// </summary>
        /// <value>The minimum mileage.</value>
        public int? MinMileage { get; set; }

        /// <summary>
        ///     Gets or sets the preferential price.
        /// </summary>
        /// <value>The preferential price.</value>
        public int? PreferentialPrice { get; set; }

        /// <summary>
        ///     Gets or sets the real mileage.
        /// </summary>
        /// <value>The real mileage.</value>
        public int? RealMileage { get; set; }

        /// <summary>
        ///     Gets or sets the sale grade.
        /// </summary>
        /// <value>The sale grade.</value>
        public SaleGrade? SaleGrade { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle owner.
        /// </summary>
        /// <value>The vehicle owner.</value>
        public string VehicleOwner { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle owner bank.
        /// </summary>
        /// <value>The vehicle owner bank.</value>
        public string VehicleOwnerBank { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle owner bank card no.
        /// </summary>
        /// <value>The vehicle owner bank card no.</value>
        public string VehicleOwnerBankCardNo { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle owner cellphone.
        /// </summary>
        /// <value>The vehicle owner cellphone.</value>
        public string VehicleOwnerCellphone { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [vehicle owner identifier no].
        /// </summary>
        /// <value><c>true</c> if [vehicle owner identifier no]; otherwise, <c>false</c>.</value>
        public string VehicleOwnerIdNo { get; set; }

        /// <summary>
        ///     Gets or sets the vin code.
        /// </summary>
        /// <value>The vin code.</value>
        public string VinCode { get; set; }

        /// <summary>
        ///     Gets or sets the violation note.
        /// </summary>
        /// <value>The violation note.</value>
        public string ViolationNote { get; set; }

        /// <summary>
        ///     Gets or sets the state of the violation.
        /// </summary>
        /// <value>The state of the violation.</value>
        public bool? ViolationState { get; set; }

        /// <summary>
        ///     Gets or sets the web average price.
        /// </summary>
        /// <value>The web average price.</value>
        public int? WebAveragePrice { get; set; }

        /// <summary>
        ///     Gets or sets the web price.
        /// </summary>
        /// <value>The web price.</value>
        public int? WebPrice { get; set; }
    }
}