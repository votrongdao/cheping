// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:33 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:04 PM
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
using Moe.AspNet.Filters;
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
        ///     新增网点信息
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 网点信息已经存在
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("Create"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(OutletDto))]
        public async Task<IHttpActionResult> Create(OutletDto dto)
        {
            Outlet outlet = new Outlet
            {
                Available = true,
                Address = dto.Address,
                Cellphone = dto.Cellphone,
                CityId = dto.CityId,
                Contact = dto.Contact,
                OutletName = dto.OutletName
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
        ///     停用网点
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此网点，请确认网点id是否正确
        /// </response>
        /// <response code="500"></response>
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
        ///     编辑网点信息
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此网点，请确认网点id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("{id}/Edit"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(OutletDto))]
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

        /// <summary>
        ///     启用网点
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此网点，请确认网点id是否正确
        /// </response>
        /// <response code="500"></response>
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
        ///     网点是否存在
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpPost, Route("Exist"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(BoolResponse))]
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
        ///     根据Id获取网点信息
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此网点，请确认网点id是否正确
        /// </response>
        /// <response code="500"></response>
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
        ///     根据城市Id获取网点列表
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Outlets"), ResponseType(typeof(List<Outlet>))]
        public async Task<IHttpActionResult> GetOutlets([FromUri] int cityId, [FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.outletService.GetOutlets(cityId, includeUnavailable));
        }

        /// <summary>
        ///     获取网点分页信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<OutletDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri] bool includeUnavailable = false)
        {
            PaginatedList<Outlet> outlets = await this.outletService.GetPaginated(pageIndex, pageSize, includeUnavailable);

            return this.Ok(outlets.ToPaginated(o => o.ToDto()));
        }

        /// <summary>
        ///     获取所有网点信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Index"), ResponseType(typeof(List<OutletDto>))]
        public async Task<IHttpActionResult> Index([FromUri] bool includeUnavailable = false)
        {
            return this.Ok(await this.outletService.Index(includeUnavailable));
        }
    }
}