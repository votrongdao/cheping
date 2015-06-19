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
using ChepingServer.Services;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    /// Class TranscationRecordController.
    /// </summary>
    [RoutePrefix("api/TranscationRecord")]
    public class TranscationRecordController : ApiControllerBase
    {

        /// <summary>
        /// The transcation record service
        /// </summary>
        private readonly TranscationRecordService transcationRecordService = new TranscationRecordService();


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(TranscationRecordDto))]
        public async Task<IHttpActionResult> Get([FromUri] int id )
        {
            TranscationRecord transcationRecord = await this.transcationRecordService.Get(id);

            if (transcationRecord == null)
            {
                return this.BadRequest("无此交易数据，请确认交易数据id是否正确");
            }

            return this.Ok(transcationRecord.ToDto());
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="minMileage">The minimum mileage.</param>
        /// <param name="maxMileage">The maximum mileage.</param>
        /// <param name="licenseTime">The license time.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("TranscationRecords"), ResponseType(typeof(List<string>))]
        public async Task<IHttpActionResult> GetBrands([FromUri] int modelId, [FromUri] int minMileage, [FromUri] int maxMileage, [FromUri] DateTime licenseTime)
        {
            return this.Ok(await this.transcationRecordService.GetTranscationRecords(modelId,minMileage,maxMileage,licenseTime));
        }


        /// <summary>
        /// Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="minMileage">The minimum mileage.</param>
        /// <param name="maxMileage">The maximum mileage.</param>
        /// <param name="licenseTime">The license time.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<TranscationRecordDto>))]
        public async Task<IHttpActionResult> GetPaginated(int pageIndex, int pageSize, [FromUri]int modelId, [FromUri]int minMileage, [FromUri]int maxMileage, [FromUri] DateTime licenseTime)
        {
            PaginatedList<TranscationRecord> transcationRecords = await this.transcationRecordService.GetPaginated(pageIndex, pageSize, modelId,minMileage,maxMileage,licenseTime);

            return this.Ok(transcationRecords.ToPaginated(m => m.ToDto()));
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Index"), ResponseType(typeof(List<TranscationRecordDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.transcationRecordService.Index());
        }

    }
}
