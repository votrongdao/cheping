// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:21 PM
// ***********************************************************************
// <copyright file="TranscationRecord.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    public class TranscationRecord
    {
        public int BrandId { get; set; }

        public int Id { get; set; }

        public string Location { get; set; }

        public int Mileage { get; set; }

        public int ModelId { get; set; }

        public int Price { get; set; }

        public int SeriesId { get; set; }

        public DateTime? Time { get; set; }
    }
}