// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  9:55 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  11:40 PM
// ***********************************************************************
// <copyright file="UserController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using ChepingServer.DTO;
using ChepingServer.Enum;
using ChepingServer.Filters;
using ChepingServer.Models;
using ChepingServer.Requests;
using ChepingServer.Responses;
using ChepingServer.Services;
using Moe.AspNet.Filters;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     Class UserController.
    /// </summary>
    [RoutePrefix("api/Users")]
    public class UserController : ApiControllerBase
    {
        /// <summary>
        ///     The SMS service
        /// </summary>
        private readonly SmsService smsService = new SmsService();

        /// <summary>
        ///     The user service
        /// </summary>
        private readonly UserService userService = new UserService();

        /// <summary>
        ///     用户注册
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpPost, Route("Create"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Create(UserDto dto)
        {
            if (dto.JobTitle == JobTitle.Valuer || dto.JobTitle == JobTitle.Querying || dto.JobTitle == JobTitle.Manager)
            {
                dto.OutletId = 1;
            }

            string valuerGroup = "10,20,30,40,50";
            if (dto.JobTitle == JobTitle.Purchaser)
            {
                valuerGroup = dto.ValuerGroup;
            }

            User user = new User
            {
                Available = true,
                Cellphone = dto.Cellphone,
                HangOn = false,
                JobTitle = dto.JobTitle,
                OutletId = dto.OutletId,
                UserName = dto.UserName,
                ValuerGroup = valuerGroup
            };

            int outletCode = user.OutletId + 1000;

            string titleCode = "0" + (int)dto.JobTitle;
            titleCode = titleCode.Substring(titleCode.Length - 3, 3);

            string userCode = "{0}{1}{2}".FormatWith(outletCode, titleCode, user.Cellphone.Substring(user.Cellphone.Length - 4, 4));
            user.UserCode = userCode;

            string password = Guid.NewGuid().ToString().Substring(0, 8);

            user.Password = MD5Hash.ComputeMD5Hash(password);

            user = await this.userService.Create(user);

            await this.smsService.SendMessage(user.Cellphone, "登录密码：{0}".FormatWith(password));

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     停用用户
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("{id}/Disable"), CookieAuthorize, ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Disable([FromUri] int id)
        {
            User user = await this.userService.Get(id, true);

            if (user == null)
            {
                return this.BadRequest("无此用戶，请确认用戶id是否正确");
            }

            user = await this.userService.Disable(id);

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("{id}/Edit"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Edit([FromUri] int id, UserDto dto)
        {
            User user = await this.userService.Get(id);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            user.Cellphone = dto.Cellphone;
            user.JobTitle = dto.JobTitle;
            user.OutletId = dto.OutletId;
            user.UserName = dto.UserName;

            int outletCode = user.OutletId + 1000;

            string titleCode = "0" + dto.JobTitle;
            titleCode = titleCode.Substring(titleCode.Length - 3, 3);

            string userCode = "{0}{1}{2}".FormatWith(outletCode, titleCode, user.Cellphone.Substring(user.Cellphone.Length - 4, 4));
            user.UserCode = userCode;

            return this.Ok((await this.userService.Edit(id, user)).ToDto());
        }

        /// <summary>
        ///     启用用户
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("{id}/Enable"), CookieAuthorize, ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Enable([FromUri] int id)
        {
            User user = await this.userService.Get(id, true);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            user = await this.userService.Enable(id);

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     获取用户信息
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("{id}"), CookieAuthorize, ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Get(int id, [FromUri] bool includeUnavailable = false)
        {
            User user = await this.userService.Get(id, includeUnavailable);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     获取当前登录用户的信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">无此用户，请确认用户id是否正确</response>
        /// <response code="401">请登陆</response>
        /// <response code="500"></response>
        [HttpGet, Route(""), CookieAuthorize, ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Get()
        {
            User user = await this.userService.Get(this.CurrentUser.Id, true);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            string outletName;
            using (ChePingContext db = new ChePingContext())
            {
                Outlet outlet = await db.Outlets.FirstOrDefaultAsync(o => o.Id == user.OutletId);
                outletName = outlet.OutletName;
            }

            return this.Ok(user.ToDto(outletName));
        }

        /// <summary>
        ///     通过手机号获取用户列表
        /// </summary>
        /// <param name="cellphone">手机号</param>
        /// <param name="includeUnavailable">是否包含已经禁用的用户</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("{cellphone}/Cellphone"), CookieAuthorize, ResponseType(typeof(List<UserDto>))]
        public async Task<IHttpActionResult> GetByCellphone(string cellphone, [FromUri] bool includeUnavailable = false)
        {
            List<User> users = await this.userService.GetByCellphone(cellphone, includeUnavailable);

            return this.Ok(users.Select(u => u.ToDto()));
        }

        /// <summary>
        ///     获取分页用户信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Paginated"), CookieAuthorize, ResponseType(typeof(PaginatedList<UserDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri] bool includeUnavailable = false)
        {
            PaginatedList<User> users = await this.userService.GetPaginated(pageIndex, pageSize, includeUnavailable);

            return this.Ok(users.ToPaginated(u => u.ToDto()));
        }

        /// <summary>
        ///     获取所有用户信息
        /// </summary>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Index"), CookieAuthorize, ResponseType(typeof(List<UserDto>))]
        public async Task<IHttpActionResult> Index([FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.userService.Index(includeUnavailable));
        }

        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="request">The request.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     用户名或者密码错误，请确认后重试
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("Login"), ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(StringResponse))]
        public async Task<IHttpActionResult> Login(SignInRequest request)
        {
            User user = await this.userService.Login(request.LoginName, request.Password);

            if (user == null)
            {
                return this.BadRequest("用户名或者密码错误，请确认后重试");
            }

            string token = SetCookie(user.Id, user.Cellphone);

            return this.Ok(new StringResponse { Result = token });
        }

        /// <summary>
        ///     用户重置密码
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("{id}/ResetPassword"), CookieAuthorize, ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> ResetPassword(int id, [FromUri] bool includeUnavailable = false)
        {
            User user = await this.userService.Get(id, includeUnavailable);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            string password = Guid.NewGuid().ToString().Substring(0, 8);

            user.Password = MD5Hash.ComputeMD5Hash(password);
            user = await this.userService.Edit(id, user);

            await this.smsService.SendMessage(user.Cellphone, "登录密码：{0}".FormatWith(password));

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     设置 Cookie.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cellphone">The cellphone.</param>
        private static string SetCookie(int userId, string cellphone)
        {
            DateTime expiry = DateTime.UtcNow.AddHours(8).Date.AddDays(1).AddMilliseconds(-1);
            string userData = $"{userId},{cellphone},{expiry.ToBinary()}";
            FormsAuthentication.SetAuthCookie(userData, true);
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(userData, true);
            HttpContext.Current.Response.Headers.Add("x-cp", cookie.Value);
            return cookie.Value;
        }
    }
}