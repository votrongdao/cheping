// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:33 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:52 PM
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
        /// <exception cref="System.ApplicationException">网点信息已经存在</exception>
        /// <exception cref="ApplicationException">网点信息已经存在</exception>
        public async Task<Outlet> Create(Outlet outlet)
        {
            if (await this.Exist(outlet))
            {
                throw new ApplicationException("网点信息已经存在");
            }
            outlet.Available = true;

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(outlet);
            }

            return outlet;
        }

        /// <summary>
        ///     Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        public async Task<Outlet> Disable(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Outlet outlet = await db.Outlets.FirstOrDefaultAsync(o => o.Id == id);
                if (outlet != null && outlet.Available)
                {
                    outlet.Available = false;
                    await db.ExecuteSaveChangesAsync();
                }

                return outlet;
            }
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
        ///     Enables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        public async Task<Outlet> Enable(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                Outlet outlet = await db.Outlets.FirstOrDefaultAsync(o => o.Id == id);
                if (outlet != null && !outlet.Available)
                {
                    outlet.Available = true;
                    await db.ExecuteSaveChangesAsync();
                }

                return outlet;
            }
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
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;Outlet&gt;.</returns>
        public async Task<Outlet> Get(int id, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if (includeUnavailable)
                {
                    return await db.Outlets.FirstOrDefaultAsync(o => o.Id == id);
                }

                return await db.Outlets.FirstOrDefaultAsync(o => o.Id == id && o.Available);
            }
        }

        /// <summary>
        ///     Gets the outlet names.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetOutletNames(int cityId, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if (includeUnavailable)
                {
                    return await db.Outlets.Where(o => o.CityId == cityId).Select(o => o.OutletName).ToListAsync();
                }

                return await db.Outlets.Where(o => o.CityId == cityId && o.Available).Select(o => o.OutletName).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the outlets.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;List&lt;Outlet&gt;&gt;.</returns>
        public async Task<List<Outlet>> GetOutlets(int cityId, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if (includeUnavailable)
                {
                    return await db.Outlets.Where(o => o.CityId == cityId).ToListAsync();
                }

                return await db.Outlets.Where(o => o.CityId == cityId && o.Available).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;PaginatedList&lt;Outlet&gt;&gt;.</returns>
        public async Task<PaginatedList<Outlet>> GetPaginated(int pageIndex, int pageSize, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count;
                List<Outlet> outlets;
                if (includeUnavailable)
                {
                    count = await db.Outlets.CountAsync();
                    outlets = await db.Outlets.OrderBy(o => o.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                }
                else
                {
                    count = await db.Outlets.CountAsync(o => o.Available);
                    outlets = await db.Outlets.Where(o => o.Available).OrderBy(o => o.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                }

                return new PaginatedList<Outlet>(pageIndex, pageSize, count, outlets);
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;List&lt;Outlet&gt;&gt;.</returns>
        public async Task<List<Outlet>> Index(bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if (includeUnavailable)
                {
                    return await db.Outlets.ToListAsync();
                }
                return await db.Outlets.Where(o => o.Available).ToListAsync();
            }
        }
    }
}