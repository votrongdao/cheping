// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:50 PM
// ***********************************************************************
// <copyright file="CityMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     CityMap.
    /// </summary>
    public class CityMap : EntityTypeConfiguration<City>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CityMap" /> class.
        /// </summary>
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProvinceName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Cities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProvinceName).HasColumnName("ProvinceName");
            this.Property(t => t.CityName).HasColumnName("CityName");
        }
    }
}