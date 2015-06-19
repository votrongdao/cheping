// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  11:24 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:02 AM
// ***********************************************************************
// <copyright file="AcceptPriceRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Requests
{
    public class AcceptPriceRequest
    {
        /// <summary>
        ///     相关事项Id
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        ///     最终确定价格
        /// </summary>
        public int Price { get; set; }
    }
}