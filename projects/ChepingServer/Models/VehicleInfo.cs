// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:40 PM
// ***********************************************************************
// <copyright file="VehicleInfo.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using ChepingServer.Enum;

namespace ChepingServer.Models
{
    public class VehicleInfo
    {
        public string BrandName { get; set; }

        public CooperationMethod CooperationMethod { get; set; }

        public int DisplayMileage { get; set; }

        public int ExpectedPrice { get; set; }

        public DateTime FactoryTime { get; set; }

        public int Id { get; set; }

        public int InnerColor { get; set; }

        public string LicenseLocation { get; set; }

        public DateTime LicenseTime { get; set; }

        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public string ModifiedContent { get; set; }

        public int OuterColor { get; set; }

        public string SeriesName { get; set; }

        public string VehicleLocation { get; set; }
    }
}