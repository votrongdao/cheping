using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Class PhotoController.
    /// </summary>
    [RoutePrefix("api/Photos")]
    public class PhotoController : ApiControllerBase
    {

        private readonly PhotoService photoService = new PhotoService();

        [HttpPost, Route("Create"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Create(PhotoDto dto)
        {
            Photo photo = new Photo
            {
                Content = dto.Content, //decode byte stream before
                UploadTime = DateTime.UtcNow,
                CaseId = 0
            };

            return this.Ok(new {Result =  (await this.photoService.Create(photo)).Id.ToString()});
        }

        [HttpPost, Route("{id}/Delete"), ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Disable([FromUri] int id)
        {
            Photo  photo = await this.photoService.Get(id);

            if (photo == null)
            {
                return this.BadRequest("无此图片，请确认图片id是否正确");
            }

            return this.Ok(new BoolResponse {Result = await this.photoService.Delete(id)});
        }





    }
}
