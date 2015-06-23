// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:59 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:59 AM
// ***********************************************************************
// <copyright file="ValueDto.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;

namespace ChepingServer.DTO
{
    /// <summary>
    ///     ValueDto.
    /// </summary>
    public class ValueDto
    {
        /// <summary>
        /// Gets or sets the floor price.
        /// </summary>
        /// <value>The floor price.</value>
        public int FloorPrice { get; set; }

        /// <summary>
        /// Gets or sets the records.
        /// </summary>
        /// <value>The records.</value>
        public List<TranscationRecordDto> Records { get; set; }

        /// <summary>
        /// Gets or sets the web average price.
        /// </summary>
        /// <value>The web average price.</value>
        public int WebAveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the web price.
        /// </summary>
        /// <value>The web price.</value>
        public int WebPrice { get; set; }
    }
}