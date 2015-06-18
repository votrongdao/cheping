// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  11:10 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:21 AM
// ***********************************************************************
// <copyright file="ModelService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
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
    public class ModelService
    {
        /// <summary>
        ///     Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public async Task<Model> Create(Model model)
        {
            if (await this.Exist(model))
            {
                throw new ApplicationException("车型信息已经存在");
            }

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(model);
            }

            return model;
        }

        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public async Task<Model> Edit(int id, Model model)
        {
            if (await this.Exist(model))
            {
                throw new ApplicationException("车型信息已经存在");
            }

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveOrUpdateAsync(model, t => t.Id == id);
            }

            return model;
        }

        /// <summary>
        ///     Exists the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ChepingServer.Models.Model&gt;.</returns>
        public async Task<bool> Exist(Model model)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.AnyAsync(m => m.Brand == model.Brand && m.Series == model.Series && m.Modeling == model.Modeling);
            }
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public async Task<Model> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        /// <summary>
        ///     Gets the brands.
        /// </summary>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetBrands()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.GroupBy(m => m.Brand).Select(m => m.Key).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the modelings.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <param name="series">The series.</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetModelings(string brand, string series)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.Where(m => m.Brand == brand && m.Series == series).GroupBy(m => m.Series).Select(m => m.Key).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;Model&gt;&gt;.</returns>
        public async Task<PaginatedList<Model>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Models.CountAsync();
                List<Model> models = await db.Models.OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                return new PaginatedList<Model>(pageIndex, pageSize, count, models);
            }
        }

        /// <summary>
        ///     Gets the series.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetSeries(string brand)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.Where(m => m.Brand == brand).GroupBy(m => m.Series).Select(m => m.Key).ToListAsync();
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;Model&gt;&gt;.</returns>
        public async Task<List<Model>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Models.ToListAsync();
            }
        }
    }
}