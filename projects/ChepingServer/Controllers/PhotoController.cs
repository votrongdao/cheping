// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  12:13 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  10:29 AM
// ***********************************************************************
// <copyright file="PhotoController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Models;
using ChepingServer.Responses;
using ChepingServer.Services;
using Moe.AspNet.Filters;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     Class PhotoController.
    /// </summary>
    [RoutePrefix("api/Photos")]
    public class PhotoController : ApiControllerBase
    {
        private readonly PhotoService photoService = new PhotoService();

        /// <summary>
        ///     Creates the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("Create"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Create(PhotoDto dto)
        {
            Photo photo = new Photo
            {
                Content = dto.Content, //decode byte stream before
                UploadTime = DateTime.UtcNow,
                CaseId = 0
            };

            return this.Ok(new { Result = (await this.photoService.Create(photo)).Id.ToString() });
        }

        /// <summary>
        ///     Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Delete"), ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Disable([FromUri] int id)
        {
            Photo photo = await this.photoService.Get(id);

            if (photo == null)
            {
                return this.BadRequest("无此图片，请确认图片id是否正确");
            }

            return this.Ok(new BoolResponse { Result = await this.photoService.Delete(id) });
        }
    }
}