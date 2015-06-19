// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  11:33 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:43 PM
// ***********************************************************************
// <copyright file="ModelController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Models;
using ChepingServer.Responses;
using ChepingServer.Services;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     ModelController.
    /// </summary>
    [RoutePrefix("api/Models")]
    public class ModelController : ApiControllerBase
    {
        private readonly ModelService modelService = new ModelService();

        /// <summary>
        ///     Creates the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("Create"), ResponseType(typeof(ModelDto))]
        public async Task<IHttpActionResult> Create(ModelDto dto)
        {
            Model model = new Model
            {
                Brand = dto.Brand,
                Modeling = dto.Modeling,
                Price = dto.Price,
                Series = dto.Series,
                Available = true
            };

            if (await this.modelService.Exist(model))
            {
                return this.BadRequest("车型信息已经存在");
            }

            return this.Ok((await this.modelService.Create(model)).ToDto());
        }

        /// <summary>
        /// Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Disable"), ResponseType(typeof(ModelDto))]
        public async Task<IHttpActionResult> Disable([FromUri] int id)
        {
            Model model = await this.modelService.Get(id, true);

            if (model == null)
            {
                return this.BadRequest("无此车型，请确认车型id是否正确");
            }

            model = await this.modelService.Disable(id);

            return this.Ok(model.ToDto());
        }

        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Edit"), ResponseType(typeof(ModelDto))]
        public async Task<IHttpActionResult> Edit([FromUri] int id, ModelDto dto)
        {
            Model model = await this.modelService.Get(id, true);

            if (model == null)
            {
                return this.BadRequest("无此车型，请确认车型id是否正确");
            }

            model.Brand = dto.Brand;
            model.Modeling = dto.Modeling;
            model.Price = dto.Price;
            model.Series = dto.Series;

            if (await this.modelService.Exist(model))
            {
                return this.BadRequest("车型信息已经存在");
            }

            return this.Ok((await this.modelService.Edit(id, model)).ToDto());
        }

        /// <summary>
        /// Enables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Enable"), ResponseType(typeof(ModelDto))]
        public async Task<IHttpActionResult> Enable([FromUri] int id)
        {
            Model model = await this.modelService.Get(id, true);

            if (model == null)
            {
                return this.BadRequest("无此车型，请确认车型id是否正确");
            }

            model = await this.modelService.Enable(id);

            return this.Ok(model.ToDto());
        }

        /// <summary>
        ///     Exists the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Exist"), ResponseType(typeof(BoolResponse))]
        public async Task<IHttpActionResult> Exist(ModelDto dto)
        {
            Model model = new Model
            {
                Brand = dto.Brand,
                Modeling = dto.Modeling,
                Price = dto.Price,
                Series = dto.Series
            };

            return this.Ok(new BoolResponse { Result = await this.modelService.Exist(model) });
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(ModelDto))]
        public async Task<IHttpActionResult> Get([FromUri]int id, [FromUri] bool includeUnavailable = false)
        {
            Model model = await this.modelService.Get(id, includeUnavailable);

            if (model == null)
            {
                return this.BadRequest("无此车型，请确认车型id是否正确");
            }

            return this.Ok(model.ToDto());
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Brands"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetBrands([FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.modelService.GetBrands(includeUnavailable));
        }

        /// <summary>
        /// Gets the modelings.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="series">The series.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Modelings"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetModelings([FromUri] string brand, [FromUri] string series, [FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.modelService.GetModelings(brand, series, includeUnavailable));
        }

        /// <summary>
        /// Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<ModelDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri] bool includeUnavailable = false)
        {
            PaginatedList<Model> models = await this.modelService.GetPaginated(pageIndex, pageSize, includeUnavailable);

            return this.Ok(models.ToPaginated(m => m.ToDto()));
        }

        /// <summary>
        /// Gets the series.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Series"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetSeries([FromUri] string brand, [FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.modelService.GetSeries(brand, includeUnavailable));
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Index"), ResponseType(typeof(List<ModelDto>))]
        public async Task<IHttpActionResult> Index([FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.modelService.Index(includeUnavailable));
        }
    }
}