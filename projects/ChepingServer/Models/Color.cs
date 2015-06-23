// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:53 AM
// ***********************************************************************
// <copyright file="Color.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    /// <summary>
    ///     Color.
    /// </summary>
    public class Color
    {
        /// <summary>
        ///     Gets or sets the color code.
        /// </summary>
        /// <value>The color code.</value>
        public string ColorCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the color.
        /// </summary>
        /// <value>The name of the color.</value>
        public string ColorName { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
    }
}