// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  2:19 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  2:21 PM
// ***********************************************************************
// <copyright file="CookieAuthorizeAttribute.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http.Controllers;
using System.Web.Security;
using Moe.AspNet.Filters;
using Moe.Lib;

namespace ChepingServer.Filters
{
    /// <summary>
    ///     Class CookieAuthorizeAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class CookieAuthorizeAttribute : OrderedAuthorizationFilterAttribute
    {
        /// <summary>
        ///     Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using <see cref="T:System.Web.Http.Filters.AuthorizationFilterAttribute" />.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token;

            if (!this.IsValid(actionContext, out token))
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }

            base.OnAuthorization(actionContext);
        }

        /// <summary>
        ///     Formats the error message.
        /// </summary>
        /// <returns>string</returns>
        private static string FormatErrorMessage() => "AUTH:请先登录";

        /// <summary>
        ///     Processes requests that fail authorization. This default implementation creates a new
        ///     response with the Unauthorized status code. Override this method to provide your own
        ///     handling for unauthorized requests.
        /// </summary>
        /// <param name="actionContext">The context.</param>
        private static void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext), @"actionContext can not be null");
            }

            actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, FormatErrorMessage());
        }

        /// <summary>
        ///     Determines whether the specified action context is valid.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="newToken">The new token.</param>
        /// <returns>bool</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     actionContext;actionContext can not be null
        /// </exception>
        private bool IsValid(HttpActionContext actionContext, out string newToken)
        {
            newToken = "";

            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext), @"actionContext can not be null");
            }

            IEnumerable<string> header;
            if (actionContext.Request.Headers.TryGetValues("x-CP", out header))
            {
                string tokenValue = header.FirstOrDefault();
                if (tokenValue.IsNotNullOrEmpty())
                {
                    try
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(tokenValue);
                        if (ticket != null) actionContext.RequestContext.Principal = new GenericPrincipal(new GenericIdentity(ticket.Name), null);
                    }
                    catch (ArgumentException)
                    {
                        // ignore
                    }
                }
            }

            IPrincipal user = actionContext.RequestContext.Principal;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            // Token 格式检验，必须由3部分组成
            if (string.IsNullOrWhiteSpace(user.Identity.Name) || user.Identity.Name.Split(',').Count() != 3)
            {
                return false;
            }

            string[] tokenContents = user.Identity.Name.Split(',');

            // Identifier
            string userId = tokenContents[0];
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            // 用户名检验，必须是手机号格式
            string cellphone = tokenContents[1];
            if (string.IsNullOrWhiteSpace(cellphone))
            {
                return false;
            }

            long expireDateTime;
            if (!long.TryParse(tokenContents[2], out expireDateTime))
            {
                return false;
            }

            // Token 有效期已过
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (DateTime.FromBinary(expireDateTime) < DateTime.UtcNow.AddHours(8))
            {
                return false;
            }

            return true;
        }
    }
}