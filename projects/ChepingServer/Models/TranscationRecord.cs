// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:21 AM
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
        public int Id { get; set; }

        public int InnerColor { get; set; }

        public DateTime LicenseTime { get; set; }

        public int Mileage { get; set; }

        public int ModelId { get; set; }

        public int OuterColor { get; set; }

        public int Price { get; set; }

        public string Source { get; set; }
    }
}