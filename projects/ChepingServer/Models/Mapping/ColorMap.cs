// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:48 AM
// ***********************************************************************
// <copyright file="ColorMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     ColorMap.
    /// </summary>
    public class ColorMap : EntityTypeConfiguration<Color>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ColorMap" /> class.
        /// </summary>
        public ColorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ColorName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ColorCode)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Colors");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ColorName).HasColumnName("ColorName");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
        }
    }
}