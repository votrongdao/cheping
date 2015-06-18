// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:16 PM
// ***********************************************************************
// <copyright file="City.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int Id { get; set; }

        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }
    }
}