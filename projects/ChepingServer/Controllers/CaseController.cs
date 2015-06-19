// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  11:21 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  5:41 PM
// ***********************************************************************
// <copyright file="CaseController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Enum;
using ChepingServer.Filters;
using ChepingServer.Models;
using ChepingServer.Requests;
using ChepingServer.Services;
using Moe.AspNet.Filters;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     CaseController.
    /// </summary>
    [RoutePrefix("api/Case")]
    public class CaseController : ApiControllerBase
    {
        private readonly CaseService caseService = new CaseService();
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Adds the case.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AddCase"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddCase(AddCaseRequest request)
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            Case @case = new Case
            {
                Abandon = null,
                AbandonReason = "",
                CaseType = request.CaseType,
                DirectorId = null,
                ManagerId = null,
                OutletId = user.OutletId,
                PurchasePrice = 0,
                State = State.PingguZhong,
                PurchaserId = user.Id,
                QueryingId = null,
                SerialId = user.UserCode + DateTime.UtcNow.AddHours(8).ToString("yyyyMMddHHmmss"),
                ValuerId = null,
                VehicleInfoId = 0,
                VehicleInspecId = 0
            };

            VehicleInfo info = new VehicleInfo
            {
                BrandName = request.BrandName,
                CooperationMethod = request.CooperationMethod,
                DisplayMileage = request.DisplayMileage,
                ExpectedPrice = request.ExpectedPrice,
                FactoryTime = request.FactoryTime,
                InnerColor = request.InnerColor,
                LicenseLocation = request.LicenseLocation,
                LicenseTime = request.LicenseTime,
                ModelId = request.ModelId,
                ModelName = request.ModelName,
                ModifiedContent = request.ModifiedContent,
                OuterColor = request.OuterColor,
                SeriesName = request.SeriesName,
                VehicleLocation = request.VehicleLocation
            };

            CaseDto caseDto = await this.caseService.AddCaseAsync(@case, info);

            return this.Ok(caseDto);
        }

        /// <summary>
        /// Adds the yanche information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AddYancheInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddYancheInfo(AddYancheInfoRequest request)
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            Case @case = await this.caseService.Get(request.CaseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.ValuerId.GetValueOrDefault(-100) != user.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.YancheZhong)
            {
                return this.BadRequest("操作未授权");
            }

            VehicleInspection inspection = new VehicleInspection
            {
                VinCode = request.VinCode,
                EngineCode = request.EngineCode,
                InsuranceCode = request.InsuranceCode,
                LicenseCode = request.LicenseCode
            };

            @case = await this.caseService.AddYancheInfo(@case.Id, inspection);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     查询事项信息
        /// </summary>
        /// <param name="id">
        ///     二手车编号
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("Info"), ResponseType(typeof(Case))]
        public async Task<IHttpActionResult> Info(int id)
        {
            Case info;
            using (ChePingContext db = new ChePingContext())
            {
                info = await db.Cases.FirstOrDefaultAsync(i => i.Id == id);
                if (info == null)
                {
                    return this.BadRequest("无该车辆信息");
                }
            }

            return this.Ok(info);
        }

        /// <summary>
        ///     查询二手车信息，分页查询
        /// </summary>
        /// <param name="pageIndex">分页编号，从0开始</param>
        /// <param name="pageSize">分页大小</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("Infos"), ResponseType(typeof(List<Case>))]
        public async Task<IHttpActionResult> Infos(int pageIndex, int pageSize)
        {
            List<Case> infos;
            using (ChePingContext db = new ChePingContext())
            {
                infos = await db.Cases.OrderBy(i => i.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }

            return this.Ok(infos);
        }
    }
}