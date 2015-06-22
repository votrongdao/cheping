// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-21  10:27 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  2:27 PM
// ***********************************************************************
// <copyright file="PhotoService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ChepingServer.Models;

namespace ChepingServer.Services
{
    /// <summary>
    ///     Class PhotoService.
    /// </summary>
    public class PhotoService
    {
        /// <summary>
        ///     Creates the specified photo.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns>Task&lt;Photo&gt;.</returns>
        public async Task<int> Create(Photo photo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                photo.UploadTime = DateTime.UtcNow.AddHours(8);
                await db.SaveAsync(photo);
            }
            return photo.Id;
        }

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Photo&gt;.</returns>
        public async Task<Photo> Get(int id)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Photos.FirstOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}