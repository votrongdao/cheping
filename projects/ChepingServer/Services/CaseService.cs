// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  9:02 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  10:46 AM
// ***********************************************************************
// <copyright file="CaseService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ChepingServer.Enum;
using ChepingServer.Models;
using Moe.Lib;

namespace ChepingServer.Services
{
    /// <summary>
    ///     CaseService.
    /// </summary>
    public class CaseService
    {
        public static readonly State[] DirectorTodoStates = { State.Shenhe, State.Baojia, State.ShenqingDakuan };
        public static readonly State[] DirectorWarningStates = { State.YancheShibai, State.QiatanShibai, State.DakuanShenheShibai };
        public static readonly State[] ManagerTodoStates = { State.DakuanShenhe };
        public static readonly State[] ManagerWarningStates = { State.CaigouShibai };
        public static readonly State[] PurchaserTodoStates = { State.Yanche, State.Qiatan, State.Caigou };
        public static readonly State[] PurchaserWarningStates = { State.ShenheShibai, State.FangqiBaojia, State.FangqiShenqingDakuan };
        public static readonly State[] QueryingTodoStates = { State.Chaxun };
        public static readonly State[] ValuerTodoStates = { State.Pinggu };

        /// <summary>
        ///     accept price as an asynchronous operation.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="price">The price.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">未能加载事项信息</exception>
        public async Task<Case> AcceptPriceAsync(int caseId, int price)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                if (@case.State == State.Qiatan)
                {
                    @case.State = State.ShenqingDakuan;
                    @case.PurchasePrice = price;
                    await db.ExecuteSaveChangesAsync();
                }

                return @case;
            }
        }

        /// <summary>
        ///     add case as an asynchronous operation.
        /// </summary>
        /// <param name="case">The case.</param>
        /// <param name="info">The information.</param>
        /// <returns>Task&lt;CaseDto&gt;.</returns>
        public async Task<Case> AddCaseAsync(Case @case, VehicleInfo info)
        {
            if (info.ModelId == -1)
            {
                return await this.AddSpecialCaseAsync(@case, info);
            }

            return await this.AddGeneralCaseAsync(@case, info);
        }

        /// <summary>
        ///     add chaxun information as an asynchronous operation.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="chaxunInfo">The chaxun information.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">
        ///     事项的状态不合法
        ///     or
        ///     未能加载验车信息
        /// </exception>
        public async Task<Case> AddChaxunInfoAsync(int caseId, VehicleInspection chaxunInfo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);

                if (@case == null || @case.State != State.Chaxun)
                {
                    throw new ApplicationException("事项的状态不合法");
                }

                VehicleInspection inspection = await db.VehicleInspections.FirstOrDefaultAsync(i => i.Id == @case.Id);
                if (inspection == null)
                {
                    throw new ApplicationException("未能加载验车信息");
                }

                inspection.RealMileage = chaxunInfo.RealMileage;
                inspection.LastConservationTime = chaxunInfo.LastConservationTime;
                inspection.ConservationState = chaxunInfo.ConservationState;
                inspection.ConservationNote = chaxunInfo.ConservationNote;
                inspection.ClaimState = chaxunInfo.ClaimState;
                inspection.ClaimNote = chaxunInfo.ClaimNote;
                inspection.BondsState = chaxunInfo.BondsState;
                inspection.BondsNote = chaxunInfo.BondsNote;
                inspection.ViolationState = chaxunInfo.ViolationState;
                inspection.ViolationNote = chaxunInfo.ViolationNote;

                @case.State = State.Baojia;

                await db.ExecuteSaveChangesAsync();

                return @case;
            }
        }

        /// <summary>
        ///     add value information as an asynchronous operation.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="valueInfo">The value information.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">
        ///     事项的状态不合法
        ///     or
        ///     未能加载验车信息
        /// </exception>
        public async Task<Case> AddValueInfoAsync(int caseId, VehicleInspection valueInfo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);

                if (@case == null || @case.State != State.Yanche)
                {
                    throw new ApplicationException("事项的状态不合法");
                }

                VehicleInspection inspection = await db.VehicleInspections.FirstOrDefaultAsync(i => i.Id == @case.Id);
                if (inspection == null)
                {
                    throw new ApplicationException("未能加载验车信息");
                }

                inspection.PreferentialPrice = valueInfo.PreferentialPrice;
                inspection.MaxMileage = valueInfo.MaxMileage;
                inspection.MinMileage = valueInfo.MinMileage;
                inspection.SaleGrade = valueInfo.SaleGrade;
                inspection.WebAveragePrice = valueInfo.WebAveragePrice;
                inspection.WebPrice = valueInfo.WebPrice;
                inspection.FloorPrice = valueInfo.FloorPrice;

                @case.State = State.Shenhe;

                await db.ExecuteSaveChangesAsync();

                return @case;
            }
        }

        /// <summary>
        ///     Adds the yanche information.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="yancheInfo">The yanche information.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">
        ///     事项的状态不合法
        ///     or
        ///     未能加载验车信息
        /// </exception>
        public async Task<Case> AddYancheInfoAsync(int caseId, VehicleInspection yancheInfo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);

                if (@case == null || @case.State != State.Yanche)
                {
                    throw new ApplicationException("事项的状态不合法");
                }

                VehicleInspection inspection = await db.VehicleInspections.FirstOrDefaultAsync(i => i.Id == @case.Id);
                if (inspection == null)
                {
                    throw new ApplicationException("未能加载验车信息");
                }

                inspection.VinCode = yancheInfo.VinCode;
                inspection.EngineCode = yancheInfo.EngineCode;
                inspection.InsuranceCode = yancheInfo.InsuranceCode;
                inspection.LicenseCode = yancheInfo.LicenseCode;

                @case.State = State.Chaxun;

                await db.ExecuteSaveChangesAsync();

                return @case;
            }
        }

        /// <summary>
        ///     Approves the payment.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        public async Task<Case> ApprovePaymentAsync(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                if (@case.State == State.ShenqingDakuan)
                {
                    @case.State = State.Caigou;
                    await db.ExecuteSaveChangesAsync();
                }

                return @case;
            }
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        public async Task<Case> GetAsync(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cases.FirstOrDefaultAsync(c => c.Id == id);
            }
        }

        /// <summary>
        ///     get cases as an asynchronous operation.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="carType">Type of the car.</param>
        /// <returns>Task&lt;PaginatedList&lt;Case&gt;&gt;.</returns>
        public async Task<PaginatedList<Case>> GetCasesAsync(User user, int pageIndex, int pageSize, CarType carType)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int totalCount = 0;
                List<Case> cases = new List<Case>();
                switch (user.JobTitle)
                {
                    case JobTitle.Purchaser:
                        totalCount = await db.Cases.Where(c => c.PurchaserId == user.Id && c.CaseType == carType).CountAsync();
                        cases = await db.Cases.Where(c => c.PurchaserId == user.Id && c.CaseType == carType).OrderByDescending(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                        break;

                    case JobTitle.Valuer:
                        totalCount = await db.Cases.Where(c => c.ValuerId == user.Id && c.CaseType == carType).CountAsync();
                        cases = await db.Cases.Where(c => c.ValuerId == user.Id && c.CaseType == carType).OrderByDescending(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                        break;

                    case JobTitle.Querying:
                        totalCount = await db.Cases.Where(c => c.QueryingId == user.Id && c.CaseType == carType).CountAsync();
                        cases = await db.Cases.Where(c => c.PurchaserId == user.Id && c.CaseType == carType).OrderByDescending(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                        break;

                    case JobTitle.Director:
                        totalCount = await db.Cases.Where(c => c.DirectorId == user.Id && c.CaseType == carType).CountAsync();
                        cases = await db.Cases.Where(c => c.PurchaserId == user.Id && c.CaseType == carType).OrderByDescending(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                        break;

                    case JobTitle.Manager:
                        totalCount = await db.Cases.Where(c => c.ManagerId == user.Id).CountAsync();
                        cases = await db.Cases.Where(c => c.PurchaserId == user.Id).OrderByDescending(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                        break;
                }

                return new PaginatedList<Case>(pageIndex, pageSize, totalCount, cases);
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;Case&gt;&gt;.</returns>
        public async Task<PaginatedList<Case>> GetPaginatedAsync(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Cases.CountAsync();
                List<Case> cases = await db.Cases.OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

                return new PaginatedList<Case>(pageIndex, pageSize, count, cases);
            }
        }

        /// <summary>
        ///     get todos as an asynchronous operation.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;List&lt;Case&gt;&gt;.</returns>
        public async Task<List<Case>> GetTodosAsync(User user)
        {
            using (ChePingContext db = new ChePingContext())
            {
                switch (user.JobTitle)
                {
                    case JobTitle.Purchaser:
                        return await db.Cases.Where(c => PurchaserTodoStates.Contains(c.State) && c.PurchaserId == user.Id).ToListAsync();

                    case JobTitle.Valuer:
                        return await db.Cases.Where(c => QueryingTodoStates.Contains(c.State) && c.ValuerId == user.Id).ToListAsync();

                    case JobTitle.Querying:
                        return await db.Cases.Where(c => QueryingTodoStates.Contains(c.State) && c.QueryingId == user.Id).ToListAsync();

                    case JobTitle.Director:
                        return await db.Cases.Where(c => DirectorTodoStates.Contains(c.State) && c.DirectorId == user.Id).ToListAsync();

                    case JobTitle.Manager:
                        return await db.Cases.Where(c => ManagerTodoStates.Contains(c.State) && c.ManagerId == user.Id).ToListAsync();

                    default:
                        return new List<Case>();
                }
            }
        }

        /// <summary>
        ///     Gets the vehicle information.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;VehicleInfo&gt;.</returns>
        /// <exception cref="System.ApplicationException">未能加载事项信息</exception>
        public async Task<VehicleInfo> GetVehicleInfoAsync(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                return await db.VehicleInfos.FirstOrDefaultAsync(v => v.Id == @case.VehicleInfoId);
            }
        }

        /// <summary>
        ///     Gets the vehicle inspection.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;VehicleInspection&gt;.</returns>
        /// <exception cref="System.ApplicationException">未能加载事项信息</exception>
        public async Task<VehicleInspection> GetVehicleInspectionAsync(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                return await db.VehicleInspections.FirstOrDefaultAsync(v => v.Id == @case.VehicleInspecId);
            }
        }

        /// <summary>
        ///     get warning as an asynchronous operation.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;List&lt;Case&gt;&gt;.</returns>
        public async Task<List<Case>> GetWarningAsync(User user)
        {
            using (ChePingContext db = new ChePingContext())
            {
                switch (user.JobTitle)
                {
                    case JobTitle.Purchaser:
                        return await db.Cases.Where(c => PurchaserWarningStates.Contains(c.State) && c.PurchaserId == user.Id).ToListAsync();

                    case JobTitle.Director:
                        return await db.Cases.Where(c => DirectorWarningStates.Contains(c.State) && c.DirectorId == user.Id).ToListAsync();

                    case JobTitle.Manager:
                        return await db.Cases.Where(c => ManagerWarningStates.Contains(c.State) && c.ManagerId == user.Id).ToListAsync();

                    default:
                        return new List<Case>();
                }
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;Case&gt;&gt;.</returns>
        public async Task<List<Case>> IndexAsync()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cases.ToListAsync();
            }
        }

        /// <summary>
        ///     Approves the payment.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        public async Task<Case> PurchaseAsync(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                if (@case.State == State.Caigou)
                {
                    @case.State = State.Ruku;
                    await db.ExecuteSaveChangesAsync();
                }

                return @case;
            }
        }

        /// <summary>
        ///     Rejects the specified case identifier.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">未能加载事项信息</exception>
        public async Task<Case> RejectAsync(int caseId, string message)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                switch (@case.State)
                {
                    case State.Shenhe:
                        @case.State = State.ShenheShibai;
                        break;

                    case State.Yanche:
                        @case.State = State.YancheShibai;
                        break;

                    case State.Baojia:
                        @case.State = State.FangqiBaojia;
                        break;

                    case State.Qiatan:
                        @case.State = State.QiatanShibai;
                        break;

                    case State.ShenqingDakuan:
                        @case.State = State.FangqiShenqingDakuan;
                        break;

                    case State.DakuanShenhe:
                        @case.State = State.DakuanShenheShibai;
                        break;

                    case State.Caigou:
                        @case.State = State.CaigouShibai;
                        break;
                }

                @case.AbandonReason = message;
                @case.Abandon = false;
                await db.ExecuteSaveChangesAsync();

                return @case;
            }
        }

        /// <summary>
        ///     Rejections the confirm.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">未能加载事项信息</exception>
        public async Task<Case> RejectionConfirmAsync(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                if (@case.Abandon == false)
                {
                    @case.Abandon = true;
                    await db.ExecuteSaveChangesAsync();
                }

                return @case;
            }
        }

        /// <summary>
        ///     review case as an asynchronous operation.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="purchasePrice">The purchase price.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        public async Task<Case> ReviewCaseAsync(int caseId, int purchasePrice)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);
                if (@case == null)
                {
                    throw new ApplicationException("未能加载事项信息");
                }

                if (@case.State == State.Shenhe)
                {
                    @case.PurchasePrice = purchasePrice;
                    @case.State = State.Yanche;
                    await db.ExecuteSaveChangesAsync();
                }

                if (@case.State == State.Baojia)
                {
                    @case.PurchasePrice = purchasePrice;
                    @case.State = State.Qiatan;
                    await db.ExecuteSaveChangesAsync();
                }

                return @case;
            }
        }

        /// <summary>
        ///     add general case as an asynchronous operation.
        /// </summary>
        /// <param name="case">The case.</param>
        /// <param name="info">The information.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ChepingServer.Models.Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">
        ///     无法加载车型信息
        ///     or
        ///     无法加载用户信息
        ///     or
        ///     无在岗评估师，事项添加失败
        ///     or
        ///     评估师分配错误，事项添加失败
        /// </exception>
        private async Task<Case> AddGeneralCaseAsync(Case @case, VehicleInfo info)
        {
            Case newCase = new Case
            {
                Abandon = false,
                AbandonReason = "",
                CaseType = @case.CaseType,
                DirectorId = null,
                ManagerId = null,
                OutletId = 0, // need update
                PurchasePrice = 0,
                PurchaserId = @case.PurchaserId,
                QueryingId = null,
                SerialId = @case.SerialId,
                State = State.Pinggu,
                ValuerId = null, // need update
                VehicleInfoId = 0, // need update
                VehicleInspecId = 0 // need update
            };

            VehicleInfo newInfo = new VehicleInfo
            {
                BrandName = info.BrandName,
                CooperationMethod = info.CooperationMethod,
                DisplayMileage = info.DisplayMileage,
                ExpectedPrice = info.ExpectedPrice,
                FactoryTime = info.FactoryTime,
                InnerColor = info.InnerColor,
                LicenseLocation = info.LicenseLocation,
                LicenseTime = info.LicenseTime,
                ModelId = info.ModelId,
                ModelName = info.ModelName,
                ModifiedContent = info.ModifiedContent,
                OuterColor = info.OuterColor,
                SeriesName = info.SeriesName,
                VehicleLocation = info.VehicleLocation
            };

            VehicleInspection newVehicleInspection = new VehicleInspection();

            int purchaserId = @case.PurchaserId;
            using (ChePingContext db = new ChePingContext())
            {
                Model model = await db.Models.FirstOrDefaultAsync(m => m.Id == info.ModelId);

                if (model == null)
                {
                    throw new ApplicationException("无法加载车型信息");
                }

                newInfo.ModelId = model.Id;
                newInfo.BrandName = model.Brand;
                newInfo.SeriesName = model.Series;
                newInfo.ModelName = model.Modeling;

                await db.SaveAsync(newInfo);

                await db.SaveAsync(newVehicleInspection);

                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == purchaserId && u.JobTitle == JobTitle.Purchaser && u.Available);
                if (user == null)
                {
                    throw new ApplicationException("无法加载用户信息");
                }

                int valuerId;
                List<User> valuers = await db.Users.Where(u => u.Available && !u.HangOn && u.OutletId == user.OutletId && u.JobTitle == JobTitle.Valuer && u.ValuerGroup == newCase.CaseType).ToListAsync();

                var workingValuers = await db.Cases.Where(c => c.OutletId == user.OutletId && ValuerTodoStates.Contains(c.State) && c.ValuerId != null)
                    .GroupBy(c => c.ValuerId).Select(g => new { g.Key, Count = g.Count() }).ToListAsync();

                valuers.RemoveAll(v => workingValuers.Select(i => i.Key).Contains(v.Id));

                if (valuers.Count > 0)
                {
                    valuerId = valuers[0].Id;
                }
                else
                {
                    if (workingValuers.Count == 0)
                    {
                        throw new ApplicationException("无在岗评估师，事项添加失败");
                    }

                    valuerId = workingValuers.OrderBy(v => v.Count).Select(v => v.Key).First().GetValueOrDefault();

                    if (valuerId == 0)
                    {
                        throw new ApplicationException("评估师分配错误，事项添加失败");
                    }
                }

                newCase.ValuerId = valuerId;
                newCase.OutletId = user.OutletId;
                newCase.VehicleInfoId = newInfo.Id;
                newCase.VehicleInspecId = newVehicleInspection.Id;

                await db.SaveAsync(@case);
            }

            return newCase;
        }

        /// <summary>
        ///     add special case as an asynchronous operation.
        /// </summary>
        /// <param name="case">The case.</param>
        /// <param name="info">The information.</param>
        /// <returns>Task&lt;CaseDto&gt;.</returns>
        /// <exception cref="System.ApplicationException">无法加载用户信息</exception>
        private async Task<Case> AddSpecialCaseAsync(Case @case, VehicleInfo info)
        {
            Case newCase = new Case
            {
                Abandon = false,
                AbandonReason = "",
                CaseType = @case.CaseType,
                DirectorId = null, // need update
                ManagerId = null,
                OutletId = 0, // need update
                PurchasePrice = 0,
                PurchaserId = @case.PurchaserId,
                QueryingId = null,
                SerialId = @case.SerialId,
                State = State.Shenhe,
                ValuerId = null,
                VehicleInfoId = 0, // need update
                VehicleInspecId = 0 // need update
            };

            VehicleInfo newInfo = new VehicleInfo
            {
                BrandName = info.BrandName,
                CooperationMethod = info.CooperationMethod,
                DisplayMileage = info.DisplayMileage,
                ExpectedPrice = info.ExpectedPrice,
                FactoryTime = info.FactoryTime,
                InnerColor = info.InnerColor,
                LicenseLocation = info.LicenseLocation,
                LicenseTime = info.LicenseTime,
                ModelId = -1,
                ModelName = info.ModelName,
                ModifiedContent = info.ModifiedContent,
                OuterColor = info.OuterColor,
                SeriesName = info.SeriesName,
                VehicleLocation = info.VehicleLocation
            };

            VehicleInspection newVehicleInspection = new VehicleInspection();

            int purchaserId = @case.PurchaserId;
            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(newInfo);

                await db.SaveAsync(newVehicleInspection);

                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == purchaserId && u.JobTitle == JobTitle.Purchaser && u.Available);
                if (user == null)
                {
                    throw new ApplicationException("无法加载用户信息");
                }

                List<User> directors = await db.Users.Where(u => u.Available && u.OutletId == user.OutletId && u.JobTitle == JobTitle.Director).ToListAsync();

                int caseCount = await db.Cases.CountAsync(c => c.OutletId == user.OutletId && DirectorTodoStates.Contains(c.State) && c.DirectorId != null);
                int index = caseCount % directors.Count;

                int directorId = directors[index].Id;

                newCase.DirectorId = directorId;
                newCase.OutletId = user.OutletId;
                newCase.VehicleInfoId = newInfo.Id;
                newCase.VehicleInspecId = newVehicleInspection.Id;

                await db.SaveAsync(@case);
            }

            return newCase;
        }
    }
}