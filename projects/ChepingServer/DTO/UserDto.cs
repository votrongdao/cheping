// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  8:08 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  8:08 PM
// ***********************************************************************
// <copyright file="UserDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Models;

namespace ChepingServer.DTO
{
    public static class UserEx
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Cellphone = user.Cellphone,
                Id = user.Id,
                JobTitle = user.JobTitle,
                OutletId = user.OutletId,
                UserCode = user.UserCode,
                UserName = user.UserName
            };
        }
    }

    public class UserDto
    {
        public string Cellphone { get; set; }

        public int Id { get; set; }

        public int JobTitle { get; set; }

        public int OutletId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }
    }
}