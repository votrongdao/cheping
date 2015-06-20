// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  9:07 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  10:32 PM
// ***********************************************************************
// <copyright file="MiscController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Threading.Tasks;
using System.Web.Http;
using ChepingServer.DTO;
using ChepingServer.Models;
using ChepingServer.Services;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     MiscController.
    /// </summary>
    [RoutePrefix("api/Sms")]
    public class MiscController : ApiControllerBase
    {
        private readonly SmsService smsService = new SmsService();
        private readonly UserService userService = new UserService();

        /// <summary>
        ///     发送验证码
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="message">The message.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [Route("Send")]
        public async Task<IHttpActionResult> Send(int id, string message)
        {
            User user = await this.userService.Get(id);
            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            await this.smsService.SendMessage(user.Cellphone, message);

            return this.Ok();
        }

        /// <summary>
        ///     发送重置密码
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此用户，请确认用户id是否正确
        /// </response>
        /// <response code="500"></response>
        [Route("SendPassword")]
        public async Task<IHttpActionResult> SendPassword(int id)
        {
            User user = await this.userService.Get(id);

            if (user == null)
            {
                return this.BadRequest("无此用户，请确认用户id是否正确");
            }

            await this.smsService.SendMessage(user.Cellphone, "登录密码：{0}".FormatWith(user.Password));

            return this.Ok(user.ToDto());
        }
    }
}