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
    /// <summary>
    /// Class UserService.
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Create(User user)
        {
            user.Available = true;

            using (ChePingContext db = new ChePingContext())
            {
                await db.SaveAsync(user);
            }

            return user;
        }

        /// <summary>
        /// Disables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Disable(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null && user.Available)
                {
                    user.Available = false;
                    await db.ExecuteSaveChangesAsync();
                }

                return user;
            }
        }

        /// <summary>
        /// Edits the specified identifier.
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
        /// Enables the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Enable(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null && !user.Available)
                {
                    user.Available = true;
                    await db.ExecuteSaveChangesAsync();
                }

                return user;
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Get(int id, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if (includeUnavailable)
                {
                    return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
                }
                return await db.Users.FirstOrDefaultAsync(u => u.Id == id && u.Available);
            }
        }

        /// <summary>
        /// Gets the by cellphone.
        /// </summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;List&lt;User&gt;&gt;.</returns>
        public async Task<List<User>> GetByCellphone(string cellphone, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if ( includeUnavailable )
                {
                    return await db.Users.Where(u => u.Cellphone == cellphone).ToListAsync();
                }
                return await db.Users.Where(u => u.Cellphone == cellphone && u.Available).ToListAsync();
            }
        }

        /// <summary>
        /// Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;PaginatedList&lt;User&gt;&gt;.</returns>
        public async Task<PaginatedList<User>> GetPaginated(int pageIndex, int pageSize, bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count;
                List<User> users;
                if (includeUnavailable)
                {
                    count = await db.Users.CountAsync();
                    users = await db.Users.OrderBy(u => u.Id).Skip(pageSize*pageIndex).Take(pageSize).ToListAsync();
                }
                else
                {
                    count = await db.Users.CountAsync(u=>u.Available);
                    users = await db.Users.Where(u=>u.Available).OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
                }
                 
                return new PaginatedList<User>(pageIndex, pageSize, count, users);
            }
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <param name="includeUnavailable">if set to <c>true</c> [include unavailable].</param>
        /// <returns>Task&lt;List&lt;User&gt;&gt;.</returns>
        public async Task<List<User>> Index(bool includeUnavailable = false)
        {
            using (ChePingContext db = new ChePingContext())
            {
                if ( includeUnavailable)
                {
                    return await db.Users.ToListAsync();
                }
                return await db.Users.Where(u=>u.Available).ToListAsync();
            }
        }

        /// <summary>
        /// Logins the specified login name.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <param name="password">The password.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Login(string loginName, string password)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Users.FirstOrDefaultAsync(u => u.Cellphone == loginName && u.Password == password);
            }
        }
    }
}