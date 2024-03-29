// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-22  9:55 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  11:01 PM
// ***********************************************************************
// <copyright file="CaseController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.DTO;
using ChepingServer.Enum;
using ChepingServer.Filters;
using ChepingServer.Models;
using ChepingServer.Requests;
using ChepingServer.Responses;
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
        ///     接受报价
        /// </summary>
        /// <param name="caseId">订单 id</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("AcceptPrice"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AcceptPrice([FromUri] int caseId)
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

            if (@case.State != State.Qiatan)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.AcceptPriceAsync(caseId);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     新增订单
        /// </summary>
        /// <param name="request">订单内容</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载用户信息
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
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
                InnerColorName = request.InnerColorName,
                LicenseLocation = request.LicenseLocation,
                LicenseTime = request.LicenseTime,
                ModelId = -1,
                ModelName = request.ModelName,
                ModifiedContent = request.ModifiedContent,
                OuterColor = request.OuterColor,
                OuterColorName = request.OuterColorName,
                SeriesName = request.SeriesName,
                VehicleLocation = request.VehicleLocation
            };

            @case = await this.caseService.AddCaseAsync(@case, info, request.PhotoIds);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     添加查询信息
        /// </summary>
        /// <param name="request">查询结果</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
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
        ///     添加洽谈结果信息
        /// </summary>
        /// <param name="request">洽谈结果信息</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [Route("AddQiatanInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddQiatanInfo(AddQiatanInfoRequest request)
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

            VehicleInspection inspection = new VehicleInspection
            {
                VehicleOwner = request.VehicleOwner,
                VehicleOwnerCellphone = request.VehicleOwnerCellphone,
                VehicleOwnerBank = request.VehicleOwnerBank,
                VehicleOwnerBankCardNo = request.VehicleOwnerBankCardNo,
                VehicleOwnerIdNo = request.VehicleOwnerIdNo
            };

            @case = await this.caseService.AddQiatanInfoAsync(@case.Id, inspection);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     添加评估信息
        /// </summary>
        /// <param name="request">The request.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [Route("AddValueInfo"), ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
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

            @case = await this.caseService.AddValueInfoAsync(@case.Id, inspection, request.Price);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     添加验车信息
        /// </summary>
        /// <param name="request">The request.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [Route("AddYancheInfo"), CookieAuthorize, ActionParameterRequired, ActionParameterValidate(Order = 1), ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> AddYancheInfo(AddYancheInfoRequest request)
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

            @case = await this.caseService.AddYancheInfoAsync(@case.Id, inspection, request.PhotoIds);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     申请打款
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="price">The price.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("ApplyPayment"), CookieAuthorize, ResponseType(typeof(CaseDto))]
        public async Task<IHttpActionResult> ApplyPayment([FromUri] int caseId, int price)
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

            if (@case.State != State.ShenqingDakuan)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.ApplyPaymentAsync(caseId, price);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     打款审核
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("ApprovePayment"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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

            if (@case.State != State.DakuanShenhe)
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
        /// <response code="200"></response>
        /// <response code="400">
        ///     无此订单，请确认订单id是否正确
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("{id}"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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
        ///     按车类型获取分页订单信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="carType">Type of the car.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载用户信息
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("List"), CookieAuthorize, ResponseType(typeof(IPaginatedList<VehicleResponse>))]
        public async Task<IHttpActionResult> GetCases([FromUri] int pageIndex, [FromUri] int pageSize, [FromUri] CarType carType)
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            PaginatedList<Case> cases = await this.caseService.GetCasesAsync(user, pageIndex, pageSize, carType);

            Dictionary<int, VehicleInfo> vehicleInfos = await this.caseService.GetVehicleInfos(cases.Items.Select(i => i.VehicleInfoId).ToList());

            IPaginatedList<VehicleResponse> responses = cases.ToPaginated(c =>
            {
                VehicleResponse response = new VehicleResponse();
                var info = vehicleInfos[c.VehicleInfoId];
                List<int> photoIds = this.caseService.GetPhotos(c.Id);
                string cp = this.caseService.GetPhotoContent(c.Id);
                response.Photo = cp;
                response.State = c.State;
                response.Abandon = c.Abandon;
                response.AbandonReason = c.AbandonReason;
                response.BrandName = info.BrandName;
                response.CaseType = c.CaseType;
                response.CooperationMethod = info.CooperationMethod;
                response.CreateTime = c.CreateTime;
                response.DirectorId = c.DirectorId;
                response.DisplayMileage = info.DisplayMileage;
                response.ExpectedPrice = info.ExpectedPrice;
                response.FactoryTime = info.FactoryTime;
                response.Id = c.Id;
                response.InnerColor = info.InnerColor;
                response.InnerColorName = info.InnerColorName;
                response.LicenseLocation = info.LicenseLocation;
                response.LicenseTime = info.LicenseTime;
                response.ManagerId = c.ManagerId;
                response.ModelId = info.ModelId;
                response.ModelName = info.ModelName;
                response.ModifiedContent = info.ModifiedContent;
                response.OuterColor = info.OuterColor;
                response.OuterColorName = info.OuterColorName;
                response.OutletId = c.OutletId;
                response.PurchasePrice = c.PurchasePrice;
                response.PurchaserId = c.PurchaserId;
                response.QueryingId = c.QueryingId;
                response.SerialId = c.SerialId;
                response.SeriesName = info.SeriesName;
                response.State = c.State;
                response.ValuerId = c.ValuerId;
                response.VehicleInfoId = c.VehicleInfoId;
                response.VehicleInspecId = c.VehicleInspecId;
                response.VehicleLocation = info.VehicleLocation;
                response.Photos = photoIds;
                return response;
            });

            return this.Ok(responses);
        }

        /// <summary>
        ///     获取订单分页信息
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Paginated"), CookieAuthorize, ResponseType(typeof(PaginatedList<CaseDto>))]
        public async Task<IHttpActionResult> GetPaginated([FromUri] int pageIndex, [FromUri] int pageSize)
        {
            PaginatedList<Case> cases = await this.caseService.GetPaginatedAsync(pageIndex, pageSize);

            return this.Ok(cases.ToPaginated(m => m.ToDto()));
        }

        /// <summary>
        ///     获取待办事项
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载用户信息
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("Todos"), CookieAuthorize, ResponseType(typeof(List<VehicleResponse>))]
        public async Task<IHttpActionResult> GetTodos()
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            List<Case> cases = await this.caseService.GetTodosAsync(user);

            Dictionary<int, VehicleInfo> vehicleInfos = await this.caseService.GetVehicleInfos(cases.Select(i => i.VehicleInfoId).ToList());

            List<VehicleResponse> responses = cases.Select(c =>
            {
                VehicleResponse response = new VehicleResponse();
                var info = vehicleInfos[c.VehicleInfoId];
                List<int> photoIds = this.caseService.GetPhotos(c.Id);
                string cp = this.caseService.GetPhotoContent(c.Id);
                response.Photo = cp;
                response.State = c.State;
                response.Abandon = c.Abandon;
                response.AbandonReason = c.AbandonReason;
                response.BrandName = info.BrandName;
                response.CaseType = c.CaseType;
                response.CooperationMethod = info.CooperationMethod;
                response.CreateTime = c.CreateTime;
                response.DirectorId = c.DirectorId;
                response.DisplayMileage = info.DisplayMileage;
                response.ExpectedPrice = info.ExpectedPrice;
                response.FactoryTime = info.FactoryTime;
                response.Id = c.Id;
                response.InnerColor = info.InnerColor;
                response.InnerColorName = info.InnerColorName;
                response.LicenseLocation = info.LicenseLocation;
                response.ManagerId = c.ManagerId;
                response.ModelId = info.ModelId;
                response.ModelName = info.ModelName;
                response.ModifiedContent = info.ModifiedContent;
                response.OuterColor = info.OuterColor;
                response.OuterColorName = info.OuterColorName;
                response.OutletId = c.OutletId;
                response.PurchasePrice = c.PurchasePrice;
                response.PurchaserId = c.PurchaserId;
                response.QueryingId = c.QueryingId;
                response.SerialId = c.SerialId;
                response.SeriesName = info.SeriesName;
                response.State = c.State;
                response.ValuerId = c.ValuerId;
                response.VehicleInfoId = c.VehicleInfoId;
                response.VehicleInspecId = c.VehicleInspecId;
                response.VehicleLocation = info.VehicleLocation;
                response.Photos = photoIds;
                return response;
            }).ToList();

            return this.Ok(responses);
        }

        /// <summary>
        ///     获取警告信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载用户信息
        /// </response>
        /// <response code="500"></response>
        [HttpGet, Route("Warnings"), CookieAuthorize, ResponseType(typeof(List<VehicleResponse>))]
        public async Task<IHttpActionResult> GetWarnings()
        {
            User user = await this.userService.Get(this.CurrentUser.Id);
            if (user == null)
            {
                return this.BadRequest("无法加载用户信息");
            }

            List<Case> cases = await this.caseService.GetWarningAsync(user);

            Dictionary<int, VehicleInfo> vehicleInfos = await this.caseService.GetVehicleInfos(cases.Select(i => i.VehicleInfoId).ToList());

            List<VehicleResponse> responses = cases.Select(c =>
            {
                VehicleResponse response = new VehicleResponse();
                var info = vehicleInfos[c.VehicleInfoId];
                List<int> photoIds = this.caseService.GetPhotos(c.Id);
                string cp = this.caseService.GetPhotoContent(c.Id);
                response.Photo = cp;
                response.State = c.State;
                response.Abandon = c.Abandon;
                response.AbandonReason = c.AbandonReason;
                response.BrandName = info.BrandName;
                response.CaseType = c.CaseType;
                response.CooperationMethod = info.CooperationMethod;
                response.CreateTime = c.CreateTime;
                response.DirectorId = c.DirectorId;
                response.DisplayMileage = info.DisplayMileage;
                response.ExpectedPrice = info.ExpectedPrice;
                response.FactoryTime = info.FactoryTime;
                response.Id = c.Id;
                response.InnerColor = info.InnerColor;
                response.InnerColorName = info.InnerColorName;
                response.LicenseLocation = info.LicenseLocation;
                response.LicenseTime = info.LicenseTime;
                response.ManagerId = c.ManagerId;
                response.ModelId = info.ModelId;
                response.ModelName = info.ModelName;
                response.ModifiedContent = info.ModifiedContent;
                response.OuterColor = info.OuterColor;
                response.OuterColorName = info.OuterColorName;
                response.OutletId = c.OutletId;
                response.PurchasePrice = c.PurchasePrice;
                response.PurchaserId = c.PurchaserId;
                response.QueryingId = c.QueryingId;
                response.SerialId = c.SerialId;
                response.SeriesName = info.SeriesName;
                response.State = c.State;
                response.ValuerId = c.ValuerId;
                response.VehicleInfoId = c.VehicleInfoId;
                response.VehicleInspecId = c.VehicleInspecId;
                response.VehicleLocation = info.VehicleLocation;
                response.Photos = photoIds;
                return response;
            }).ToList();

            return this.Ok(responses);
        }

        /// <summary>
        ///     获取所有订单信息
        /// </summary>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("Index"), CookieAuthorize, ResponseType(typeof(List<CaseDto>))]
        public async Task<IHttpActionResult> Index()
        {
            return this.Ok(await this.caseService.IndexAsync());
        }

        /// <summary>
        ///     采购
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("Purchase"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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
        ///     放弃订单
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="message">The message.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     失败原因不能为空
        ///     <br />
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("Reject"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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
        ///     确认放弃订单
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <response code="200"></response>
        /// <response code="400">
        ///     无法加载事项信息
        ///     <br />
        ///     操作未授权
        ///     <br />
        ///     事项状态错误
        /// </response>
        /// <response code="401">请登录</response>
        /// <response code="500"></response>
        [HttpGet, Route("RejectionConfirm"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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
        ///     审核订单
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
        [HttpGet, Route("ReviewCase"), CookieAuthorize, ResponseType(typeof(CaseDto))]
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

            if (@case.State != State.Shenhe && @case.State != State.Baojia)
            {
                return this.BadRequest("事项状态错误");
            }

            @case = await this.caseService.ReviewCaseAsync(caseId, purchasePrice);

            return this.Ok(@case.ToDto());
        }

        /// <summary>
        ///     获取订单车辆信息
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("VehicleInfo"), CookieAuthorize, ResponseType(typeof(CaseInfoResponse))]
        [SuppressMessage("ReSharper", "FunctionComplexityOverflow")]
        public async Task<IHttpActionResult> VehicleInfo(int caseId)
        {
            var result = await this.caseService.GetCaseWithVehicleInfoAsync(caseId);

            var inspection = await this.caseService.GetVehicleInspectionAsync(caseId);

            var photoId = this.caseService.GetPhotos(caseId);
            var pc = this.caseService.GetPhotoContent(caseId);

            CaseInfoResponse response = new CaseInfoResponse();
            var c = result.Item1;
            var info = result.Item2;

            string valuerName = "未评估";
            if (c.ValuerId.HasValue)
            {
                var valuer = await this.userService.Get(c.ValuerId.Value, true);
                if (valuer != null)
                {
                    valuerName = valuer.UserName;
                }
            }

            response.State = c.State;
            response.Abandon = c.Abandon;
            response.AbandonReason = c.AbandonReason;
            response.BrandName = info.BrandName;
            response.CaseType = c.CaseType;
            response.CooperationMethod = info.CooperationMethod;
            response.CreateTime = c.CreateTime;
            response.DirectorId = c.DirectorId;
            response.DisplayMileage = info.DisplayMileage;
            response.ExpectedPrice = info.ExpectedPrice;
            response.FactoryTime = info.FactoryTime;
            response.Id = c.Id;
            response.InnerColor = info.InnerColor;
            response.InnerColorName = info.InnerColorName;
            response.LicenseLocation = info.LicenseLocation;
            response.LicenseTime = info.LicenseTime;
            response.ManagerId = c.ManagerId;
            response.ModelId = info.ModelId;
            response.ModelName = info.ModelName;
            response.ModifiedContent = info.ModifiedContent;
            response.OuterColor = info.OuterColor;
            response.OuterColorName = info.OuterColorName;
            response.OutletId = c.OutletId;
            response.PurchasePrice = c.PurchasePrice;
            response.PurchaserId = c.PurchaserId;
            response.QueryingId = c.QueryingId;
            response.SerialId = c.SerialId;
            response.SeriesName = info.SeriesName;
            response.State = c.State;
            response.ValuerId = c.ValuerId;
            response.VehicleInfoId = c.VehicleInfoId;
            response.VehicleInspecId = c.VehicleInspecId;
            response.VehicleLocation = info.VehicleLocation;
            response.Photos = photoId;
            response.Photo = pc;
            response.PhotoContents = this.caseService.GetPhotoContents(caseId);
            response.VinCode = inspection.VinCode;
            response.EngineCode = inspection.EngineCode;
            response.InsuranceCode = inspection.InsuranceCode;
            response.LicenseCode = inspection.LicenseCode;
            response.RealMileage = inspection.RealMileage.GetValueOrDefault();
            response.LastConservationTime = inspection.LastConservationTime.GetValueOrDefault();
            response.ConservationState = inspection.ConservationState.GetValueOrDefault();
            response.ConservationNote = inspection.ConservationNote;
            response.ClaimState = inspection.ClaimState.GetValueOrDefault();
            response.ClaimNote = inspection.ClaimNote;
            response.BondsState = inspection.BondsState.GetValueOrDefault();
            response.BondsNote = inspection.BondsNote;
            response.ViolationState = inspection.ViolationState.GetValueOrDefault();
            response.ViolationNote = inspection.ViolationNote;
            response.PreferentialPrice = inspection.PreferentialPrice.GetValueOrDefault();
            response.MaxMileage = inspection.MaxMileage.GetValueOrDefault();
            response.MinMileage = inspection.MinMileage.GetValueOrDefault();
            response.SaleGrade = inspection.SaleGrade.GetValueOrDefault();
            response.WebAveragePrice = inspection.WebAveragePrice.GetValueOrDefault();
            response.WebPrice = inspection.WebPrice.GetValueOrDefault();
            response.FloorPrice = inspection.FloorPrice.GetValueOrDefault();
            response.ValuerName = valuerName;
            response.VehicleOwner = inspection.VehicleOwner;
            response.VehicleOwnerBank = inspection.VehicleOwnerBank;
            response.VehicleOwnerBankCardNo = inspection.VehicleOwnerBankCardNo;
            response.VehicleOwnerCellphone = inspection.VehicleOwnerCellphone;
            response.VehicleOwnerIdNo = inspection.VehicleOwnerIdNo;
            return this.Ok(response);
        }

        /// <summary>
        ///     获取订单车型信息
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <response code="200"></response>
        /// <response code="500"></response>
        [HttpGet, Route("VehicleInspection"), CookieAuthorize, ResponseType(typeof(VehicleInspection))]
        public async Task<IHttpActionResult> VehicleInspection(int caseId)
        {
            return this.Ok(await this.caseService.GetVehicleInspectionAsync(caseId));
        }
    }
}