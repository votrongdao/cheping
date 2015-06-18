// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  7:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  11:15 AM
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web.Http;

namespace ChepingServer
{
    /// <summary>
    ///     WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        ///     Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}