// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:45 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:53 AM
// ***********************************************************************
// <copyright file="ColorGrade.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    /// <summary>
    ///     ColorGrade.
    /// </summary>
    public class ColorGrade
    {
        /// <summary>
        ///     Gets or sets the good colors.
        /// </summary>
        /// <value>The good colors.</value>
        public string GoodColors { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the middle colors.
        /// </summary>
        /// <value>The middle colors.</value>
        public string MiddleColors { get; set; }

        /// <summary>
        ///     Gets or sets the model identifier.
        /// </summary>
        /// <value>The model identifier.</value>
        public int? ModelId { get; set; }
    }
}