// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:51 PM
// ***********************************************************************
// <copyright file="Model.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    /// <summary>
    ///     Model.
    /// </summary>
    public class Model
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Model" /> is available.
        /// </summary>
        /// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Available { get; set; }

        /// <summary>
        ///     Gets or sets the brand.
        /// </summary>
        /// <value>The brand.</value>
        public string Brand { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the modeling.
        /// </summary>
        /// <value>The modeling.</value>
        public string Modeling { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public int Price { get; set; }

        /// <summary>
        ///     Gets or sets the series.
        /// </summary>
        /// <value>The series.</value>
        public string Series { get; set; }
    }
}