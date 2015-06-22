// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  3:51 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  3:52 PM
// ***********************************************************************
// <copyright file="PhotoController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.Filters;
using ChepingServer.Models;
using ChepingServer.Requests;
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
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("Create"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(IntResponse))]
        public async Task<IHttpActionResult> Create(AddPhotoRequest request)
        {
            Photo photo = new Photo
            {
                CaseId = request.CaseId,
                Content = request.Content,
                UploadTime = DateTime.UtcNow.AddHours(8)
            };

            int id = await this.photoService.Create(photo);

            return this.Ok(id);
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}"), CookieAuthorize, ResponseType(typeof(Photo))]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            Photo photo = await this.photoService.Get(id);

            if (photo == null)
            {
                return this.BadRequest("无此图片，请确认图片id是否正确");
            }

            return this.Ok(photo);
        }
    }
}