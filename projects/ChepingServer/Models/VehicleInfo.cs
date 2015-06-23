// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:57 AM
// ***********************************************************************
// <copyright file="VehicleInfo.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using ChepingServer.Enum;

namespace ChepingServer.Models
{
    /// <summary>
    ///     VehicleInfo.
    /// </summary>
    public class VehicleInfo
    {
        /// <summary>
        ///     Gets or sets the name of the brand.
        /// </summary>
        /// <value>The name of the brand.</value>
        public string BrandName { get; set; }

        /// <summary>
        ///     Gets or sets the cooperation method.
        /// </summary>
        /// <value>The cooperation method.</value>
        public CooperationMethod CooperationMethod { get; set; }

        /// <summary>
        ///     Gets or sets the display mileage.
        /// </summary>
        /// <value>The display mileage.</value>
        public int DisplayMileage { get; set; }

        /// <summary>
        ///     Gets or sets the expected price.
        /// </summary>
        /// <value>The expected price.</value>
        public int? ExpectedPrice { get; set; }

        /// <summary>
        ///     Gets or sets the factory time.
        /// </summary>
        /// <value>The factory time.</value>
        public DateTime? FactoryTime { get; set; }

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
        ///     Gets or sets the license location.
        /// </summary>
        /// <value>The license location.</value>
        public int? LicenseLocation { get; set; }

        /// <summary>
        ///     Gets or sets the license time.
        /// </summary>
        /// <value>The license time.</value>
        public DateTime LicenseTime { get; set; }

        /// <summary>
        ///     Gets or sets the model identifier.
        /// </summary>
        /// <value>The model identifier.</value>
        public int ModelId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the model.
        /// </summary>
        /// <value>The name of the model.</value>
        public string ModelName { get; set; }

        /// <summary>
        ///     Gets or sets the content of the modified.
        /// </summary>
        /// <value>The content of the modified.</value>
        public string ModifiedContent { get; set; }

        /// <summary>
        ///     Gets or sets the color of the outer.
        /// </summary>
        /// <value>The color of the outer.</value>
        public int OuterColor { get; set; }

        /// <summary>
        ///     Gets or sets the name of the series.
        /// </summary>
        /// <value>The name of the series.</value>
        public string SeriesName { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle location.
        /// </summary>
        /// <value>The vehicle location.</value>
        public int VehicleLocation { get; set; }
    }
}