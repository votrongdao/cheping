// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:45 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:52 AM
// ***********************************************************************
// <copyright file="City.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    /// <summary>
    ///     City.
    /// </summary>
    public class City
    {
        /// <summary>
        ///     Gets or sets the name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        public string CityName { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>The name of the province.</value>
        public string ProvinceName { get; set; }
    }
}