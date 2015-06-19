// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  6:00 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  6:21 PM
// ***********************************************************************
// <copyright file="AddYancheInfoRequest.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Requests
{
    public class AddYancheInfoRequest
    {
        /// <summary>
        ///     对应的事项Id
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        ///     发动机编号
        /// </summary>
        public string EngineCode { get; set; }

        /// <summary>
        ///     保单号
        /// </summary>
        public string InsuranceCode { get; set; }

        /// <summary>
        ///     车牌号
        /// </summary>
        public string LicenseCode { get; set; }

        /// <summary>
        ///     车架编号
        /// </summary>
        public string VinCode { get; set; }
    }
}