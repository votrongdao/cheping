// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:46 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  7:28 PM
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
using ChepingServer.DTO;
using ChepingServer.Enum;
using ChepingServer.Models;

namespace ChepingServer.Services
{
    public class CaseService
    {
        public static readonly State[] DirectorTodoStates = { State.ShenheZhong, State.ShougouZhong };
        public static readonly State[] ManagerTodoStates = { State.FukuanZhong };
        public static readonly State[] PurchaserTodoStates = { State.YancheZhong, State.ShougouZhong, State.RukuZhong };
        public static readonly State[] QueryingTodoStates = { State.ChaxunZhong };
        public static readonly State[] ValuerTodoStates = { State.PingguZhong };

        /// <summary>
        ///     add case as an asynchronous operation.
        /// </summary>
        /// <param name="case">The case.</param>
        /// <param name="info">The information.</param>
        /// <returns>Task&lt;CaseDto&gt;.</returns>
        public async Task<CaseDto> AddCaseAsync(Case @case, VehicleInfo info)
        {
            if (info.ModelId == -1)
            {
                return await this.AddSpecialCaseAsync(@case, info);
            }

            return await this.AddGeneralCaseAsync(@case, info);
        }

        /// <summary>
        ///     Adds the yanche information.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="yancheInfo">The yanche information.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        /// <exception cref="System.ApplicationException">事项的状态不合法</exception>
        public async Task<Case> AddYancheInfo(int caseId, VehicleInspection yancheInfo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Case @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == caseId);

                if (@case == null || @case.State != State.YancheZhong)
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

                @case.State = State.ChaxunZhong;

                await db.ExecuteSaveChangesAsync();

                return @case;
            }
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Case&gt;.</returns>
        public async Task<Case> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cases.FirstOrDefaultAsync(c => c.Id == id);
            }
        }

        private async Task<CaseDto> AddGeneralCaseAsync(Case @case, VehicleInfo info)
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
                State = State.PingguZhong,
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

                List<User> valuers = await db.Users.Where(u => u.Available && u.OutletId == user.OutletId && u.JobTitle == JobTitle.Valuer && u.ValuerGroup == newCase.CaseType).ToListAsync();

                int caseCount = await db.Cases.CountAsync(c => c.OutletId == user.OutletId && ValuerTodoStates.Contains(c.State) && c.ValuerId != null);
                int index = caseCount % valuers.Count;

                int valuerId = valuers[index].Id;

                newCase.ValuerId = valuerId;
                newCase.OutletId = user.OutletId;
                newCase.VehicleInfoId = newInfo.Id;
                newCase.VehicleInspecId = newVehicleInspection.Id;

                await db.SaveAsync(@case);
            }

            return newCase.ToDto();
        }

        /// <summary>
        ///     add special case as an asynchronous operation.
        /// </summary>
        /// <param name="case">The case.</param>
        /// <param name="info">The information.</param>
        /// <returns>Task&lt;CaseDto&gt;.</returns>
        /// <exception cref="System.ApplicationException">无法加载用户信息</exception>
        private async Task<CaseDto> AddSpecialCaseAsync(Case @case, VehicleInfo info)
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
                State = State.ShenheZhong,
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

            return newCase.ToDto();
        }
    }
}