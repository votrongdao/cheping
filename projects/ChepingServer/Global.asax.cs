// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  7:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  11:20 AM
// ***********************************************************************
// <copyright file="Global.asax.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web;
using System.Web.Http;

namespace ChepingServer
{
    /// <summary>
    ///     WebApiApplication.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        ///     Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}