// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  11:37 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  11:42 PM
// ***********************************************************************
// <copyright file="AddChaxunInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace ChepingServer.Requests
{
    public class AddChaxunInfoRequest
    {
        public string BondsNote { get; set; }

        public bool BondsState { get; set; }

        public int CaseId { get; set; }

        public string ClaimNote { get; set; }

        public bool ClaimState { get; set; }

        public string ConservationNote { get; set; }

        public bool ConservationState { get; set; }

        public DateTime LastConservationTime { get; set; }

        public int RealMileage { get; set; }

        public string ViolationNote { get; set; }

        public bool ViolationState { get; set; }
    }
}