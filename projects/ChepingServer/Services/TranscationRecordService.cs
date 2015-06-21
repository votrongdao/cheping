// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  9:34 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  9:34 AM
// ***********************************************************************
// <copyright file="TranscationRecordService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ChepingServer.Models;
using Moe.Lib;

namespace ChepingServer.Services
{
    /// <summary>
    /// Class TranscationRecordService.
    /// </summary>
    public class TranscationRecordService
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TranscationRecord&gt;.</returns>
        public async Task<TranscationRecord> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.TranscationRecords.FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="modelId">The model identifier.</param>
        /// <param name="minMileage">The minimum mileage.</param>
        /// <param name="maxMileage">The maximum mileage.</param>
        /// <param name="licenseTime">The license time.</param>
        /// <returns>Task&lt;TranscationRecord&gt;.</returns>
        public async Task<List<TranscationRecord>> GetTranscationRecords(int modelId, int minMileage, int maxMileage, DateTime licenseTime)
        {
            using (ChePingContext db = new ChePingContext())
            {
                DateTime start = new DateTime(licenseTime.Year,1,1);
                DateTime end = start.AddYears(1).AddMilliseconds(-1);

                return await db.TranscationRecords.Where(t => t.ModelId == modelId && t.Mileage >=minMileage && t.Mileage <= maxMileage && t.LicenseTime >= start &&
                                t.LicenseTime <= end).ToListAsync();
            }
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;TranscationRecord&gt;&gt;.</returns>
        public async Task<List<TranscationRecord>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.TranscationRecords.ToListAsync();
            }
        }

        /// <summary>
        /// Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;TranscationRecord&gt;&gt;.</returns>
        public async Task<PaginatedList<TranscationRecord>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.TranscationRecords.CountAsync();
                List<TranscationRecord> transcationRecords = await db.TranscationRecords.OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

                return new PaginatedList<TranscationRecord>(pageIndex, pageSize, count, transcationRecords);
            }
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
        /// <returns>Task&lt;PaginatedList&lt;TranscationRecord&gt;&gt;.</returns>
        public async Task<PaginatedList<TranscationRecord>> GetPaginated(int pageIndex, int pageSize, int modelId,  int minMileage, int maxMileage, DateTime licenseTime)
        {
            using (ChePingContext db = new ChePingContext())
            {
                DateTime start = new DateTime(licenseTime.Year, 1, 1);
                DateTime end = start.AddYears(1).AddMilliseconds(-1);

                int count = await db.TranscationRecords.CountAsync();
                List<TranscationRecord> transcationRecords = await db.TranscationRecords.Where(t => t.ModelId == modelId && t.Mileage >= minMileage && t.Mileage <=maxMileage && t.LicenseTime >= start &&
                                t.LicenseTime <= end).OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

                return new PaginatedList<TranscationRecord>(pageIndex, pageSize, count, transcationRecords);
            }
        }


    }
}