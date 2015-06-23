// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:54 AM
// ***********************************************************************
// <copyright file="TranscationRecord.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    /// <summary>
    ///     TranscationRecord.
    /// </summary>
    public class TranscationRecord
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the color of the inner.
        /// </summary>
        /// <value>The color of the inner.</value>
        public int InnerColor { get; set; }

        /// <summary>
        ///     Gets or sets the license time.
        /// </summary>
        /// <value>The license time.</value>
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     Gets or sets the mileage.
        /// </summary>
        /// <value>The mileage.</value>
        public int Mileage { get; set; }

        /// <summary>
        ///     Gets or sets the model identifier.
        /// </summary>
        /// <value>The model identifier.</value>
        public int ModelId { get; set; }

        /// <summary>
        ///     Gets or sets the color of the outer.
        /// </summary>
        /// <value>The color of the outer.</value>
        public int OuterColor { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public int Price { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; }
    }
}