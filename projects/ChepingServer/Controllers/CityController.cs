// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  12:57 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  1:15 AM
// ***********************************************************************
// <copyright file="CityController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
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
    ///     CityController.
    /// </summary>
    [RoutePrefix("api/Cities")]
    public class CityController : ApiControllerBase
    {
        /// <summary>
        ///     The city service
        /// </summary>
        private readonly CityService cityService = new CityService();

        /// <summary>
        ///     Creates the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpPost, Route("Create"), ResponseType(typeof(CityDto))]
        public async Task<IHttpActionResult> Create(CityDto dto)
        {
            City city = new City
            {
                CityName = dto.CityName,
                ProvinceName = dto.ProvinceName
            };

            if (await this.cityService.Exist(city))
            {
                return this.BadRequest("城市信息已经存在");
            }

            return this.Ok((await this.cityService.Create(city)).ToDto());
        }

        /// <summary>
        ///     Exists the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Exist"), ResponseType(typeof(BoolResponse))]
        public async Task<IHttpActionResult> Exist(CityDto dto)
        {
            City city = new City
            {
                CityName = dto.CityName,
                ProvinceName = dto.ProvinceName
            };

            return this.Ok(new BoolResponse { Result = await this.cityService.Exist(city) });
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(CityDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            City city = await this.cityService.Get(id);

            if (city == null)
            {
                return this.BadRequest("无此城市，请确认城市id是否正确");
            }

            return this.Ok(city.ToDto());
        }

        /// <summary>
        ///     Gets the cities.
        /// </summary>
        /// <param name="provinceName">Name of the province.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Cities"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetCities([FromUri] string provinceName)
        {
            return this.Ok(await this.cityService.GetCities(provinceName));
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<CityDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize)
        {
            PaginatedList<City> cities = await this.cityService.GetPaginated(pageIndex, pageSize);

            return this.Ok(cities.ToPaginated(c => c.ToDto()));
        }

        /// <summary>
        ///     Gets the provinces.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Provinces"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetProvinces()
        {
            return this.Ok(await this.cityService.GetProvinces());
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Index"), ResponseType(typeof(List<CityDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.cityService.Index());
        }
    }
}