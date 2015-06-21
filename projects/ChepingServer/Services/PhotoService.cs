// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-20  9:02 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  9:05 AM
// ***********************************************************************
// <copyright file="PhotoService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ChepingServer.Models;
using Moe.Lib;
using System;

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
        public async Task<string> Create(Photo photo)
        {
            using (ChePingContext db = new ChePingContext())
            {
                photo.UploadTime = DateTime.UtcNow.AddHours(8);
                await db.SaveAsync(photo);
            }
            return photo.Id.ToString();
        }

        /// <summary>
        ///     Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> Delete(int id)
        {
            bool isSuccess = false;
            using (ChePingContext db = new ChePingContext())
            {
                Photo photo = await db.Photos.FirstOrDefaultAsync(p => p.Id == id);
                if (photo != null)
                {
                    db.Remove(photo);
                    photo = await db.Photos.FirstOrDefaultAsync(p => p.Id == id);
                    if (photo == null) isSuccess = true;
                }
                return await Task.FromResult(isSuccess);
            }
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

        /// <summary>
        ///     Gets the paginated.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;PaginatedList&lt;Photo&gt;&gt;.</returns>
        public async Task<PaginatedList<Photo>> GetPaginated(int pageIndex, int pageSize)
        {
            using (ChePingContext db = new ChePingContext())
            {
                int count = await db.Photos.CountAsync();
                List<Photo> photos = await db.Photos.OrderBy(u => u.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

                return new PaginatedList<Photo>(pageIndex, pageSize, count, photos);
            }
        }

        /// <summary>
        ///     Gets the photos.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <returns>Task&lt;List&lt;Photo&gt;&gt;.</returns>
        public async Task<List<Photo>> GetPhotos(int caseId)
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Photos.Where(p => p.CaseId == caseId).ToListAsync();
            }
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>Task&lt;List&lt;Photo&gt;&gt;.</returns>
        public async Task<List<Photo>> Index()
        {
            using (ChePingContext db = new ChePingContext())
            {
                return await db.Photos.ToListAsync();
            }
        }
    }
}