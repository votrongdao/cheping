// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  9:22 AM
// ***********************************************************************
// <copyright file="User.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Enum;

namespace ChepingServer.Models
{
    public class User
    {
        public bool Available { get; set; }

        public string Cellphone { get; set; }

        public bool HangOn { get; set; }

        public int Id { get; set; }

        public JobTitle JobTitle { get; set; }

        public int OutletId { get; set; }

        public string Password { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public CarType ValuerGroup { get; set; }
    }
}