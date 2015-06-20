// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  9:02 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  10:38 AM
// ***********************************************************************
// <copyright file="CaseController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
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
using Moe.Lib;

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
        ///     Accepts the price.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AcceptPrice"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AcceptPrice(AcceptPriceRequest request)
        {
            Case @case = await this.caseService.GetAsync(request.CaseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.PurchaserId != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Qiatan)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.AcceptPriceAsync(request.CaseId, request.Price);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Adds the case.
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
                State = State.Pinggu,
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

            @case = await this.caseService.AddCaseAsync(@case, info);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Adds the chaxun information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AddChaxunInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddChaxunInfo(AddChaxunInfoRequest request)
        {
            Case @case = await this.caseService.GetAsync(request.CaseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.QueryingId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Chaxun)
            {
                return this.BadRequest("事项状态错误");
            }

            VehicleInspection inspection = new VehicleInspection
            {
                RealMileage = request.RealMileage,
                LastConservationTime = request.LastConservationTime,
                ConservationState = request.ConservationState,
                ConservationNote = request.ConservationNote,
                ClaimState = request.ClaimState,
                ClaimNote = request.ClaimNote,
                BondsState = request.BondsState,
                BondsNote = request.BondsNote,
                ViolationState = request.ViolationState,
                ViolationNote = request.ViolationNote
            };

            @case = await this.caseService.AddChaxunInfoAsync(@case.Id, inspection);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Adds the value information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AddValueInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddValueInfo(AddValueInfoRequest request)
        {
            Case @case = await this.caseService.GetAsync(request.CaseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.ValuerId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Pinggu)
            {
                return this.BadRequest("事项状态错误");
            }

            VehicleInspection inspection = new VehicleInspection
            {
                PreferentialPrice = request.PreferentialPrice,
                MaxMileage = request.MaxMileage,
                MinMileage = request.MinMileage,
                SaleGrade = request.SaleGrade,
                WebAveragePrice = request.WebAveragePrice,
                WebPrice = request.WebPrice,
                FloorPrice = request.FloorPrice
            };

            @case = await this.caseService.AddValueInfoAsync(@case.Id, inspection);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Adds the yanche information.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("AddYancheInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddYancheInfo(AddYancheInfoRequest request)
        {
            Case @case = await this.caseService.GetAsync(request.CaseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.ValuerId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Yanche)
            {
                return this.BadRequest("事项状态错误");
            }

            VehicleInspection inspection = new VehicleInspection
            {
                VinCode = request.VinCode,
                EngineCode = request.EngineCode,
                InsuranceCode = request.InsuranceCode,
                LicenseCode = request.LicenseCode
            };

            @case = await this.caseService.AddYancheInfoAsync(@case.Id, inspection);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Approves the payment.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("ApprovePayment"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> ApprovePayment([FromUri] int caseId)
        {
            Case @case = await this.caseService.GetAsync(caseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.ManagerId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.ShenqingDakuan)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.ApprovePaymentAsync(caseId);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     根据订单Id获取订单
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("{id}"), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            Case @case = await this.caseService.GetAsync(id);

            if (@case == null)
            {
                return this.BadRequest("无此订单，请确认订单id是否正确");
            }

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Paginated"), ResponseType(typeof(PaginatedList<CaseDto>))]
        public async Task<IHttpActionResult> GetPaginated([FromUri]int pageIndex, [FromUri]int pageSize)
        {
            PaginatedList<Case> cases = await this.caseService.GetPaginatedAsync(pageIndex, pageSize);

            return this.Ok(cases.ToPaginated(m => m.ToDto()));
        }

        /// <summary>
        ///     Gets the todos.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Todos"), ResponseType(typeof(List<CaseDto>))]
        public async Task<IHttpActionResult> GetTodos()
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            List<Case> cases = await this.caseService.GetTodosAsync(user);

            return this.Ok(cases.Select(c => c.ToDto()));
        }

        /// <summary>
        ///     Gets the warnings.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Warnings"), ResponseType(typeof(List<CaseDto>))]
        public async Task<IHttpActionResult> GetWarnings()
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            List<Case> cases = await this.caseService.GetWarningAsync(user);

            return this.Ok(cases.Select(c => c.ToDto()));
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("Index"), ResponseType(typeof(List<CaseDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.caseService.IndexAsync());
        }

        /// <summary>
        ///     Purchases the specified case identifier.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("Purchase"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> Purchase([FromUri] int caseId)
        {
            Case @case = await this.caseService.GetAsync(caseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.PurchaserId != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Caigou)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.PurchaseAsync(caseId);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Rejects the specified case identifier.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("Reject"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> Reject([FromUri] int caseId, [FromUri] string message)
        {
            if (message.IsNullOrEmpty())
            {
                return this.BadRequest("失败原因不能为空");
            }

            Case @case = await this.caseService.GetAsync(caseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            switch (@case.State)
            {
                case State.Shenhe:
                    if (@case.DirectorId.GetValueOrDefault(-100) != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.Yanche:
                    if (@case.PurchaserId != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.Baojia:
                    if (@case.DirectorId.GetValueOrDefault(-100) != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.Qiatan:
                    if (@case.PurchaserId != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.ShenqingDakuan:
                    if (@case.DirectorId.GetValueOrDefault(-100) != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.DakuanShenhe:
                    if (@case.ManagerId.GetValueOrDefault(-100) != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                case State.Caigou:
                    if (@case.PurchaserId != this.CurrentUser.Id)
                    {
                        return this.BadRequest("操作未授权");
                    }
                    break;

                default:
                    return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.RejectAsync(caseId, message);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Rejections the confirm.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("RejectionConfirm"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> RejectionConfirm([FromUri] int caseId)
        {
            Case @case = await this.caseService.GetAsync(caseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.DirectorId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.Abandon != false)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.RejectionConfirmAsync(caseId);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Reviews the case.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="purchasePrice">The purchase price.</param>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        [Route("ReviewCase"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> ReviewCase([FromUri] int caseId, [FromUri] int purchasePrice)
        {
            Case @case = await this.caseService.GetAsync(caseId);
            if (@case == null)
            {
                return this.BadRequest("无法加载事项信息");
            }

            if (@case.DirectorId.GetValueOrDefault(-100) != this.CurrentUser.Id)
            {
                return this.BadRequest("操作未授权");
            }

            if (@case.State != State.Shenhe || @case.State != State.Baojia)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.ReviewCaseAsync(caseId, purchasePrice);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     Vehicles the information.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("VehicleInfo"), ResponseType(typeof(VehicleInfo))]
        public async Task<IHttpActionResult> VehicleInfo(int caseId)
        {
            return this.Ok(await this.caseService.GetVehicleInfoAsync(caseId));
        }

        /// <summary>
        ///     Vehicles the inspection.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [HttpGet, Route("VehicleInspection"), ResponseType(typeof(VehicleInspection))]
        public async Task<IHttpActionResult> VehicleInspection(int caseId)
        {
            return this.Ok(await this.caseService.GetVehicleInspectionAsync(caseId));
        }
    }
}