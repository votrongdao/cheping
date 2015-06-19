// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  1:40 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  2:29 AM
// ***********************************************************************
// <copyright file="OutletService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
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
    ///     OutletService.
    /// </summary>
    public class OutletService
    {
        /// <summary>
        ///     Creates the specified outlet.
        /// </summary>
        /// <param name="outlet">The outlet.</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        /// <exception cref="ApplicationException">网点信息已经存在</exception>
        public async Task<Outlet> Create(Outlet outlet)
        {
            if (await this.Exist(outlet))
            {
                throw new ApplicationException("网点信息已经存在");
            }

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(outlet);
            }

            return outlet;
        }

        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="outlet">The outlet.</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        public async Task<Outlet> Edit(int id, Outlet outlet)
        {
            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveOrUpdateAsync(outlet, o => o.Id == id);
            }

            return outlet;
        }

        /// <summary>
        ///     Exists the specified outlet.
        /// </summary>
        /// <param name="outlet">The outlet.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Exist(Outlet outlet)
        {
            using (ChePingContext db = new ChePingContext())
            {
                //use cityId and outletName to match
                return await db.Outlets.AnyAsync(o => o.CityId == outlet.CityId && o.OutletName == outlet.OutletName);
            }
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        public async Task<Outlet> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Outlets.FirstOrDefaultAsync(o => o.Id == id);
            }
        }

        /// <summary>
        ///     Gets the outlet names.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetOutletNames(int cityId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Outlets.Where(o => o.CityId == cityId).Select(o => o.OutletName).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the outlets.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <returns>Task&lt;List&lt;Outlet&gt;&gt;.</returns>
        public async Task<List<Outlet>> GetOutlets(int cityId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Outlets.Where(o => o.CityId == cityId).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;Outlet&gt;&gt;.</returns>
        public async Task<PaginatedList<Outlet>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Outlets.CountAsync();
                List<Outlet> outlets = await db.Outlets.OrderBy(o => o.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                return new PaginatedList<Outlet>(pageIndex, pageSize, count, outlets);
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;Outlet&gt;&gt;.</returns>
        public async Task<List<Outlet>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Outlets.ToListAsync();
            }
        }
    }
}