// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:22 PM
// ***********************************************************************
// <copyright file="User.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    public class User
    {
        public string Cellphone { get; set; }

        public int Id { get; set; }

        public int JobTitle { get; set; }

        public int OutletId { get; set; }

        public string Password { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }
    }
}