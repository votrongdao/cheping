// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  12:26 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  12:38 PM
// ***********************************************************************
// <copyright file="VehicleModelController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.Models;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     VehicleModelController.
    /// </summary>
    [RoutePrefix("VehicleModel")]
    public class VehicleModelController : ApiController
    {
        /// <summary>
        ///     所有的车型品牌列表
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Brands"), ResponseType(typeof(Dictionary<int, string>))]
        public async Task<IHttpActionResult> VehicleModels()
        {
            Dictionary<int, string> brands = new Dictionary<int, string>();
            using (ChePingContext db = new ChePingContext())
            {
                var models = await db.VehicleModels.OrderBy(i => i.Id).ToListAsync();
                foreach (VehicleModel model in models.Where(model => !brands.ContainsKey(model.BrandId.GetValueOrDefault())))
                {
                    brands.Add(model.BrandId.GetValueOrDefault(), model.BrandName);
                }
            }

            return this.Ok(brands);
        }

        /// <summary>
        ///     所有的车系列表
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Series"), ResponseType(typeof(List<VehicleModel>))]
        public async Task<IHttpActionResult> VehicleModels(int brandId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                List<VehicleModel> models = await db.VehicleModels.OrderBy(i => i.Id).Where(i => i.BrandId == brandId).ToListAsync();
                return this.Ok(models);
            }
        }

        /// <summary>
        ///     所有的车型列表
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="seriesId">车系id</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Models"), ResponseType(typeof(List<VehicleModel>))]
        public async Task<IHttpActionResult> VehicleModels(int brandId, int seriesId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                List<VehicleModel> models = await db.VehicleModels.OrderBy(i => i.Id).Where(i => i.BrandId == brandId
                                                                                                 && i.SeriesId == seriesId).ToListAsync();
                return this.Ok(models);
            }
        }
    }
}