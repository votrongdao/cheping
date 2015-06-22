// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-22  2:19 PM
// ***********************************************************************
// <copyright file="Photo.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    /// <summary>
    ///     Photo.
    /// </summary>
    public class Photo
    {
        /// <summary>
        ///     Gets or sets the case identifier.
        /// </summary>
        /// <value>The case identifier.</value>
        public int CaseId { get; set; }

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the upload time.
        /// </summary>
        /// <value>The upload time.</value>
        public DateTime UploadTime { get; set; }
    }
}