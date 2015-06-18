// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  7:28 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  10:27 PM
// ***********************************************************************
// <copyright file="UserController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Models;
using ChepingServer.Services;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly SmsService smsService = new SmsService();
        private readonly UserService userService = new UserService();

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost, Route("Create"), ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Create(UserDto dto)
        {
            User user = new User
            {
                Cellphone = dto.Cellphone,
                JobTitle = dto.JobTitle,
                OutletId = dto.OutletId,
                Password = Guid.NewGuid().ToString().Substring(0, 8),
                UserCode = dto.UserCode,
                UserName = dto.UserName
            };

            return this.Ok((await this.userService.Create(user)).ToDto());
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dto">The dto.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost, Route("/{id}/Edit"), ResponseType(typeof(UserDto))]
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
            user.Password = Guid.NewGuid().ToString().Substring(0, 8);
            user.UserCode = dto.UserCode;
            user.UserName = dto.UserName;

            return this.Ok((await this.userService.Edit(id, user)).ToDto());
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            User user = await this.userService.Get(id);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            return this.Ok(user.ToDto());
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet, Route("{cellphone}/Cellphone"), ResponseType(typeof(List<UserDto>))]
        public async Task<IHttpActionResult> GetByCellphone(string cellphone)
        {
            List<User> users = await this.userService.GetByCellphone(cellphone);

            return this.Ok(users.Select(u => u.ToDto()));
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<UserDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize)
        {
            PaginatedList<User> users = await this.userService.GetPaginated(pageIndex, pageSize);

            return this.Ok(users.ToPaginated(u => u.ToDto()));
        }

        /// <summary>
        ///     Resets the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("/{id}/ResetPassword"), ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> ResetPassword(int id)
        {
            User user = await this.userService.Get(id);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            user.Password = Guid.NewGuid().ToString().Substring(0, 8);

            user = await this.userService.Edit(id, user);

            await this.smsService.SendMessage(user.Cellphone, "登录密码：{0}".FormatWith(user.Password));

            return this.Ok(user.ToDto());
        }
    }
}