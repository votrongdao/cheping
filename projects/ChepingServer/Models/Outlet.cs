// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:21 AM
// ***********************************************************************
// <copyright file="Outlet.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    public class Outlet
    {
        public string Address { get; set; }

        public int Available { get; set; }

        public string Cellphone { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string Contact { get; set; }

        public int Id { get; set; }

        public string OutletName { get; set; }

        public string ProvinceName { get; set; }
    }
}