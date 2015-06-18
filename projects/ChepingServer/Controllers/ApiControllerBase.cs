// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  9:04 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  9:06 AM
// ***********************************************************************
// <copyright file="ApiControllerBase.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Http;

namespace ChepingServer.Controllers
{
    /// <summary>
    /// ApiControllerBase.
    /// </summary>
    public abstract class ApiControllerBase : ApiController
    {
        /// <summary>
        ///     The current user
        /// </summary>
        private CurrentUser currentUser;

        /// <summary>
        ///     Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        protected CurrentUser CurrentUser => this.currentUser ?? (this.currentUser = this.GetCurrentUser());

        /// <summary>
        ///     Creates an <see cref="T:System.Web.Http.IHttpActionResult" /> (200 OK).
        /// </summary>
        /// <returns>An <see cref="T:System.Web.Http.IHttpActionResult" /> (200 OK).</returns>
        protected new IHttpActionResult Ok()
        {
            return base.Ok(new object());
        }

        /// <summary>
        ///     Gets the current user.
        /// </summary>
        /// <returns>CurrentUser.</returns>
        private CurrentUser GetCurrentUser()
        {
            IPrincipal principal = this.User;

            if (principal?.Identity == null || !principal.Identity.IsAuthenticated)
            {
                return null;
            }

            string token = principal.Identity.Name;
            string[] tokens = token.Split(',');

            if (string.IsNullOrWhiteSpace(token) || tokens.Length != 3)
            {
                return null;
            }

            DateTime expiryTime = DateTime.MinValue;
            long expiry;
            if (long.TryParse(tokens[2], out expiry))
            {
                expiryTime = DateTime.FromBinary(expiry);
            }

            return new CurrentUser
            {
                Id = Convert.ToInt32(tokens[0]),
                Cellphone = tokens[1],
                LoginTime = expiryTime
            };
        }
    }

    /// <summary>
    ///     Class CurrentUser.
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        ///     Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        public string Cellphone { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the expiry time.
        /// </summary>
        /// <value>The expiry time.</value>
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public DateTime LoginTime { get; set; }
    }
}