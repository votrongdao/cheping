// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:33 PM
// 
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:50 PM
// ***********************************************************************
// <copyright file="Outlet.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    /// <summary>
    ///     Outlet.
    /// </summary>
    public class Outlet
    {
        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Outlet" /> is available.
        /// </summary>
        /// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Available { get; set; }

        /// <summary>
        ///     Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        public string Cellphone { get; set; }

        /// <summary>
        ///     Gets or sets the city identifier.
        /// </summary>
        /// <value>The city identifier.</value>
        public int CityId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        public string CityName { get; set; }

        /// <summary>
        ///     Gets or sets the contact.
        /// </summary>
        /// <value>The contact.</value>
        public string Contact { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the outlet.
        /// </summary>
        /// <value>The name of the outlet.</value>
        public string OutletName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the province.
        /// </summary>
        /// <value>The name of the province.</value>
        public string ProvinceName { get; set; }
    }
}