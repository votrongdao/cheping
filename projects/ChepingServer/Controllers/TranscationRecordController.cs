// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  7:14 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  7:16 PM
// ***********************************************************************
// <copyright file="TranscationRecordController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Models;
using ChepingServer.Services;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     Class TranscationRecordController.
    /// </summary>
    [RoutePrefix("api/TranscationRecord")]
    public class TranscationRecordController : ApiControllerBase
    {
        /// <summary>
        ///     The transcation record service
        /// </summary>
        private readonly TranscationRecordService transcationRecordService = new TranscationRecordService();

        /// <summary>
        ///     根据Id获取交易数据
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        /// 无此交易数据，请确认交易数据id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("{id}"), ResponseType(typeof(TranscationRecordDto))]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            TranscationRecord transcationRecord = await this.transcationRecordService.Get(id);

            if (transcationRecord == null)
            {
                return this.BadRequest("无此交易数据，请确认交易数据id是否正确");
            }

            return this.Ok(transcationRecord.ToDto());
        }


        /// <summary>
        /// 根据查询条件获取交易数据信息
        /// </summary>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="minMileage">The minimum mileage.</param>
        /// <param name="maxMileage">The maximum mileage.</param>
        /// <param name="licenseTime">The license time.</param>
        /// <response code="200">
        /// </response>
        /// <response code="500">
        /// </response>
        [HttpGet, Route("TranscationRecords"), ResponseType(typeof(List<TranscationRecord>))]
        public async Task<IHttpActionResult> GetTranscationRecords([FromUri] int modelId, [FromUri] int minMileage, [FromUri] int maxMileage, [FromUri] DateTime licenseTime)
        {
            return this.Ok(await this.transcationRecordService.GetTranscationRecords(modelId, minMileage, maxMileage, licenseTime));
        }

        /// <summary>
        ///     根据查询条件获取交易数据分页信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="minMileage">The minimum mileage.</param>
        /// <param name="maxMileage">The maximum mileage.</param>
        /// <param name="licenseTime">The license time.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<TranscationRecordDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri] int modelId, [FromUri] int minMileage, [FromUri] int maxMileage, [FromUri] DateTime licenseTime)
        {
            PaginatedList<TranscationRecord> transcationRecords = await this.transcationRecordService.GetPaginated(pageIndex, pageSize, modelId, minMileage, maxMileage, licenseTime);

            return this.Ok(transcationRecords.ToPaginated(m => m.ToDto()));
        }

        /// <summary>
        ///     获取所有交易数据信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Index"), ResponseType(typeof(List<TranscationRecordDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.transcationRecordService.Index());
        }
    }
}