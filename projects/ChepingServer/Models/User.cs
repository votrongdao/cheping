// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:33 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-23  8:31 PM
// ***********************************************************************
// <copyright file="User.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Enum;

namespace ChepingServer.Models
{
    /// <summary>
    ///     User.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="User" /> is available.
        /// </summary>
        /// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Available { get; set; }

        /// <summary>
        ///     Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        public string Cellphone { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [hang on].
        /// </summary>
        /// <value><c>true</c> if [hang on]; otherwise, <c>false</c>.</value>
        public bool HangOn { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the job title.
        /// </summary>
        /// <value>The job title.</value>
        public JobTitle JobTitle { get; set; }

        /// <summary>
        ///     Gets or sets the outlet identifier.
        /// </summary>
        /// <value>The outlet identifier.</value>
        public int OutletId { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the user code.
        /// </summary>
        /// <value>The user code.</value>
        public string UserCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the valuer group.
        /// </summary>
        /// <value>The valuer group.</value>
        public string ValuerGroup { get; set; }
    }
}