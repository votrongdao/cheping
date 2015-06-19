// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  2:03 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  2:28 AM
// ***********************************************************************
// <copyright file="OutletController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
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
    ///     OutletController.
    /// </summary>
    [RoutePrefix("api/Outlets")]
    public class OutletController : ApiControllerBase
    {
        /// <summary>
        ///     The city service
        /// </summary>
        private readonly CityService cityService = new CityService();

        /// <summary>
        ///     The outlet service
        /// </summary>
        private readonly OutletService outletService = new OutletService();

        /// <summary>
        ///     Creates the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("Create"), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Create(OutletDto dto)
        {
            Outlet outlet = new Outlet
            {
                Address = dto.Address,
                Cellphone = dto.Cellphone,
                CityId = dto.CityId,
                Contact = dto.Contact,
                OutletName = dto.OutletName,
                Available = true
            };

            if (await this.outletService.Exist(outlet))
            {
                return this.BadRequest("网点信息已经存在");
            }

            //if not exist, retrieve the city data by cityId and add it to outlet entity.
            City city = await this.cityService.Get(outlet.CityId);
            outlet.CityName = city.CityName;
            outlet.ProvinceName = city.ProvinceName;

            return this.Ok((await this.outletService.Create(outlet)).ToDto());
        }

        /// <summary>
        /// Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Disable"), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Disable([FromUri] int id)
        {
            Outlet outlet = await this.outletService.Get(id, true);

            if (outlet == null)
            {
                return this.BadRequest("无此网点，请确认网点id是否正确");
            }

            outlet = await this.outletService.Disable(id);

            return this.Ok(outlet.ToDto());
        }

        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("{id}/Edit"), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Edit([FromUri] int id, OutletDto dto)
        {
            Outlet outlet = await this.outletService.Get(id);

            if (outlet == null)
            {
                return this.BadRequest("无此网点，请确认网点id是否正确");
            }

            outlet.Address = dto.Address;
            outlet.Cellphone = dto.Cellphone;
            outlet.Contact = dto.Contact;

            return this.Ok((await this.outletService.Edit(id, outlet)).ToDto());
        }

        [HttpPost, Route("{id}/Enable"), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Enable([FromUri] int id)
        {
            Outlet outlet = await this.outletService.Get(id, true);

            if (outlet == null)
            {
                return this.BadRequest("无此网点，请确认网点id是否正确");
            }

            outlet = await this.outletService.Enable(id);

            return this.Ok(outlet.ToDto());
        }

        /// <summary>
        ///     Exists the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Exist"), ResponseType(typeof(BoolResponse))]
        public async Task<IHttpActionResult> Exist(OutletDto dto)
        {
            Outlet outlet = new Outlet
            {
                CityId = dto.CityId,
                OutletName = dto.OutletName
            };

            return this.Ok(new BoolResponse { Result = await this.outletService.Exist(outlet) });
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Get(int id, [FromUri] bool includeUnavailable = false)
        {
            Outlet outlet = await this.outletService.Get(id, includeUnavailable);

            if (outlet == null)
            {
                return this.BadRequest("无此网点，请确认网点id是否正确");
            }

            return this.Ok(outlet.ToDto());
        }

        /// <summary>
        ///     Gets the outlets.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Outlets"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetOutlets([FromUri] int cityId, [FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.outletService.GetOutlets(cityId,includeUnavailable));
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<OutletDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri] bool includeUnavailable = false)
        {
            PaginatedList<Outlet> outlets = await this.outletService.GetPaginated(pageIndex, pageSize, includeUnavailable);

            return this.Ok(outlets.ToPaginated(o => o.ToDto()));
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Index"), ResponseType(typeof(List<OutletDto>))]
        public async Task<IHttpActionResult> Index([FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.outletService.Index(includeUnavailable));
        }
    }
}