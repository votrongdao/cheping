// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  10:09 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  8:20 PM
// ***********************************************************************
// <copyright file="SmsService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using ChepingServer.Models;
using Microsoft.Azure;
using Moe.Lib;

namespace ChepingServer.Services
{
    /// <summary>
    ///     SmsService.
    /// </summary>
    public class SmsService
    {
        private static readonly string MessageTemplate;
        private static readonly string Password;
        private static readonly string ProductId;
        private static readonly string SendMessageUrl;
        private static readonly string UserName;

        static SmsService()
        {
            SendMessageUrl = "http://www.ztsms.cn:8800/sendSms.do?";
            MessageTemplate = "username={0}&password={1}&mobile={2}&content={3}【{4}】&dstime=&productid={5}&xh=";
            UserName = "jymao";
            Password = CloudConfigurationManager.GetSetting("SmsServicePassword");
            ProductId = "676767";
        }

        /// <summary>
        ///     Sends the message.
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public async Task SendMessage(string cellphone, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.GetAsync(SendMessageUrl + MessageTemplate.FormatWith(UserName, Password, cellphone, message, "通道测试", ProductId));
            }
        }

        /// <summary>
        ///     Sends the notice message.
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>Task.</returns>
        public async Task SendNoticeMessage(string cellphone)
        {
            try
            {
                await this.SendMessage(cellphone, "您有新的代办任务，请尽快登录系统完成");
            }
            catch (Exception)
            {
                //ignore
            }
        }

        /// <summary>
        ///     Sends the notice message.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task.</returns>
        public async Task SendNoticeMessage(int userId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    await this.SendNoticeMessage(user.Cellphone);
                }
            }
        }
    }
}