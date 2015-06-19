// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  12:41 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:54 PM
// ***********************************************************************
// <copyright file="CityService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
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
    ///     CityService.
    /// </summary>
    public class CityService
    {
        /// <summary>
        ///     Creates the specified city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns>Task&lt;City&gt;.</returns>
        /// <exception cref="ApplicationException">城市信息已经存在</exception>
        public async Task<City> Create(City city)
        {
            if (await this.Exist(city))
            {
                throw new ApplicationException("城市信息已经存在");
            }

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(city);
            }

            return city;
        }

        /// <summary>
        ///     Exists the specified city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Exist(City city)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.AnyAsync(c => c.ProvinceName == city.ProvinceName && c.CityName == city.CityName);
            }
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;City&gt;.</returns>
        public async Task<City> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.FirstOrDefaultAsync(c => c.Id == id);
            }
        }

        /// <summary>
        ///     Gets the cities.
        /// </summary>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetCities()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.Select(c => c.CityName).Distinct().ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the cities.
        /// </summary>
        /// <param name="provinceName">Name of the province.</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetCities(string provinceName)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.Where(c => c.ProvinceName == provinceName).Select(c => c.CityName).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;City&gt;&gt;.</returns>
        public async Task<PaginatedList<City>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Cities.CountAsync();
                List<City> cities = await db.Cities.OrderBy(c => c.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                return new PaginatedList<City>(pageIndex, pageSize, count, cities);
            }
        }

        /// <summary>
        ///     Gets the provinces.
        /// </summary>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public async Task<List<string>> GetProvinces()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.GroupBy(c => c.ProvinceName).Select(m => m.Key).ToListAsync();
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;City&gt;&gt;.</returns>
        public async Task<List<City>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Cities.ToListAsync();
            }
        }
    }
}