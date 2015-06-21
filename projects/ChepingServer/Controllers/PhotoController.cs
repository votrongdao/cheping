// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-21  10:27 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-21  11:22 AM
// ***********************************************************************
// <copyright file="PhotoController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
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
        public async Task<IHttpActionResult> Create()
        {
            var httpRequest = HttpContext.Current.Request;

            byte[] buff = null;

            // Check if files are available
            if (httpRequest.Files.Count > 0 && httpRequest.Files[0].ContentLength > 0)
            {
                HttpPostedFile postedFile = httpRequest.Files[0];
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter iFormatter = new BinaryFormatter();
                    iFormatter.Serialize(ms, postedFile);
                    buff = ms.GetBuffer();
                }
            }

            Photo photo = new Photo
            {
                Content = buff, //decode byte stream before
                CaseId = 0
            };

            return this.Ok(new { Result = (await this.photoService.Create(photo)) });
        }

        /// <summary>
        ///     Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Delete"), ResponseType(typeof(BoolResponse))]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            Photo photo = await this.photoService.Get(id);

            if (photo == null)
            {
                return this.BadRequest("无此图片，请确认图片id是否正确");
            }

            return this.Ok(new BoolResponse { Result = await this.photoService.Delete(id) });
        }

        [HttpPost, Route("{id}"), ResponseType(typeof(Photo))]
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