// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:22 PM
// ***********************************************************************
// <copyright file="VehicleInfo.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Models
{
    public class VehicleInfo
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public int CooperationMethod { get; set; }

        public int DisplayMileage { get; set; }

        public int ExternalColor { get; set; }

        public DateTime FactoryTime { get; set; }

        public int Id { get; set; }

        public int InternalColor { get; set; }

        public string LicenseLocation { get; set; }

        public DateTime LicenseTime { get; set; }

        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public string ModifiedContent { get; set; }

        public int PsychologicalPrice { get; set; }

        public int SeriesId { get; set; }

        public string SeriesName { get; set; }

        public string VehicleLocation { get; set; }
    }
}