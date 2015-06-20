// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:52 PM
// ***********************************************************************
// <copyright file="Case.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Enum;

namespace ChepingServer.Models
{
    /// <summary>
    ///     Case.
    /// </summary>
    public class Case
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Case" /> is abandon.
        /// </summary>
        /// <value><c>null</c> if [abandon] contains no value, <c>true</c> if [abandon]; otherwise, <c>false</c>.</value>
        public bool? Abandon { get; set; }

        /// <summary>
        ///     Gets or sets the abandon reason.
        /// </summary>
        /// <value>The abandon reason.</value>
        public string AbandonReason { get; set; }

        /// <summary>
        ///     Gets or sets the type of the case.
        /// </summary>
        /// <value>The type of the case.</value>
        public CarType CaseType { get; set; }

        /// <summary>
        ///     Gets or sets the director identifier.
        /// </summary>
        /// <value>The director identifier.</value>
        public int? DirectorId { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the manager identifier.
        /// </summary>
        /// <value>The manager identifier.</value>
        public int? ManagerId { get; set; }

        /// <summary>
        ///     Gets or sets the outlet identifier.
        /// </summary>
        /// <value>The outlet identifier.</value>
        public int OutletId { get; set; }

        /// <summary>
        ///     Gets or sets the purchase price.
        /// </summary>
        /// <value>The purchase price.</value>
        public int PurchasePrice { get; set; }

        /// <summary>
        ///     Gets or sets the purchaser identifier.
        /// </summary>
        /// <value>The purchaser identifier.</value>
        public int PurchaserId { get; set; }

        /// <summary>
        ///     Gets or sets the querying identifier.
        /// </summary>
        /// <value>The querying identifier.</value>
        public int? QueryingId { get; set; }

        /// <summary>
        ///     Gets or sets the serial identifier.
        /// </summary>
        /// <value>The serial identifier.</value>
        public string SerialId { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State { get; set; }

        /// <summary>
        ///     Gets or sets the valuer identifier.
        /// </summary>
        /// <value>The valuer identifier.</value>
        public int? ValuerId { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle information identifier.
        /// </summary>
        /// <value>The vehicle information identifier.</value>
        public int VehicleInfoId { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle inspec identifier.
        /// </summary>
        /// <value>The vehicle inspec identifier.</value>
        public int VehicleInspecId { get; set; }
    }
}