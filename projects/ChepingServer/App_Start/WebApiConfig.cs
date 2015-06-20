// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  7:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:30 PM
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Tracing;
using Moe.AspNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            config.UseOrderedFilter();
            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    NullValueHandling = NullValueHandling.Include,
                    DateFormatString = "G",
                    DefaultValueHandling = DefaultValueHandling.Populate,
                    Formatting = Formatting.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            config.Formatters.Clear();
            config.Formatters.Add(formatter);

            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
            traceWriter.MinimumLevel = TraceLevel.Info;

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }

    /// <summary>
    ///     CorsPolicyFactory.
    /// </summary>
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        private readonly ICorsPolicyProvider provider = new CorsPolicyProvider();

        #region ICorsPolicyProviderFactory Members

        /// <summary>
        ///     Gets the cors policy provider.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ICorsPolicyProvider.</returns>
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return this.provider;
        }

        #endregion ICorsPolicyProviderFactory Members
    }

    /// <summary>
    ///     CorsPolicyProvider.
    /// </summary>
    public class CorsPolicyProvider : ICorsPolicyProvider
    {
        private readonly CorsPolicy policy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CorsPolicyProvider" /> class.
        /// </summary>
        public CorsPolicyProvider()
        {
            // Create a CORS policy.
            this.policy = new CorsPolicy
            {
                AllowAnyMethod = false,
                AllowAnyHeader = false,
                AllowAnyOrigin = false
            };

            this.policy.Origins.Add("http://localhost:8100");
            this.policy.Origins.Add("http://cheping.yuyidev.com");
            this.policy.Origins.Add("http://cheping-local.yuyidev.com");

            this.policy.Headers.Add("x-CP");
            this.policy.Headers.Add("x-cp");
            this.policy.Headers.Add("Set-Cookie");
            this.policy.Headers.Add("Date");

            this.policy.Methods.Add("GET");
            this.policy.Methods.Add("POST");
            this.policy.Methods.Add("PUT");
            this.policy.Methods.Add("DELETE");
        }

        #region ICorsPolicyProvider Members

        /// <summary>
        ///     Gets the <see cref="T:System.Web.Cors.CorsPolicy" />.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Web.Cors.CorsPolicy" />.
        /// </returns>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.policy);
        }

        #endregion ICorsPolicyProvider Members
    }
}