// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  7:42 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  10:26 PM
// ***********************************************************************
// <copyright file="UserService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ChepingServer.Models;
using Moe.Lib;

namespace ChepingServer.Services
{
    public class UserService
    {
        /// <summary>
        ///     Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Create(User user)
        {
            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(user);
            }

            return user;
        }

        /// <summary>
        ///     Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Edit(int id, User user)
        {
            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveOrUpdateAsync(user, t => t.Id == id);
            }

            return user;
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        /// <summary>
        ///     Gets the by cellphone.
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>Task&lt;List&lt;User&gt;&gt;.</returns>
        public async Task<List<User>> GetByCellphone(string cellphone)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Users.Where(u => u.Cellphone == cellphone).ToListAsync();
            }
        }

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;User&gt;&gt;.</returns>
        public async Task<PaginatedList<User>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Users.CountAsync();
                List<User> users = await db.Users.OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                return new PaginatedList<User>(pageIndex, pageSize, count, users);
            }
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;User&gt;&gt;.</returns>
        public async Task<List<User>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Users.ToListAsync();
            }
        }
    }
}