// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:10 PM
// ***********************************************************************
// <copyright file="SeriesMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class SeriesMap : EntityTypeConfiguration<Series>
    {
        public SeriesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SeriesName)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Series");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BrandId).HasColumnName("BrandId");
            this.Property(t => t.SeriesName).HasColumnName("SeriesName");
        }
    }
}