// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  1:13 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-21  6:08 PM
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
using Moe.AspNet.Filters;
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
        ///     创建城市信息
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     城市信息已经存在
        /// </response>
        /// <response code="500"></response>
        [HttpPost, Route("Create"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(CityDto))]
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
        ///     是否存在城市信息
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpPost, Route("Exist"), ActionParameterRequired("dto"), ActionParameterValidate(Order = 1), ResponseType(typeof(BoolResponse))]
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
        ///     获取城市信息
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此城市，请确认城市id是否正确
        /// </response>
        /// <response code="500"></response>
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
        ///     根据省份名获取城市列表
        /// </summary>
        /// <param name="provinceName">Name of the province.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Cities"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetCities([FromUri] string provinceName)
        {
            return this.Ok(await this.cityService.GetCities(provinceName));
        }

        /// <summary>
        ///     获取城市分页信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<CityDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize)
        {
            PaginatedList<City> cities = await this.cityService.GetPaginated(pageIndex, pageSize);

            return this.Ok(cities.ToPaginated(c => c.ToDto()));
        }

        /// <summary>
        ///     获取所有省份名列表
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Provinces"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetProvinces()
        {
            return this.Ok(await this.cityService.GetProvinces());
        }

        /// <summary>
        ///     获取所有城市信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Index"), ResponseType(typeof(List<CityDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.cityService.Index());
        }
    }
}