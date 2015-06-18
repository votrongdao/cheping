// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:20 PM
// ***********************************************************************
// <copyright file="Model.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Models
{
    public class Model
    {
        public int BrandId { get; set; }

        public int Id { get; set; }

        public string ModelName { get; set; }

        public int Price { get; set; }

        public int SeriesId { get; set; }
    }
}