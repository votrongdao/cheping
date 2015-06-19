// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:21 AM
// ***********************************************************************
// <copyright file="Photo.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    public class Photo
    {
        public int CaseId { get; set; }

        public byte[] Content { get; set; }

        public int Id { get; set; }

        public DateTime UploadTime { get; set; }
    }
}