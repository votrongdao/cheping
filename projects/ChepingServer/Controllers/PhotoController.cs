// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-21  4:41 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  5:36 AM
// ***********************************************************************
// <copyright file="PhotoController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.Models;
using ChepingServer.Responses;
using ChepingServer.Services;

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
        [HttpPost, Route("Create"), ResponseType(typeof(StringResponse))]
        public async Task<IHttpActionResult> Create([FromUri]int caseId, [FromUri]string content)
        {
            byte[] bytes = new byte[content.Length * sizeof(char)];
            System.Buffer.BlockCopy(content.ToCharArray(), 0, bytes, 0, bytes.Length);

            Photo photo = new Photo
            {
                Content = bytes,
                CaseId = caseId
            };

            return this.Ok(new StringResponse { Result = (await this.photoService.Create(photo)) });
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

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
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