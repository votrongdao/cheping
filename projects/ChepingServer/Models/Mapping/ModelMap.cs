// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:08 PM
// ***********************************************************************
// <copyright file="ModelMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class ModelMap : EntityTypeConfiguration<Model>
    {
        public ModelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ModelName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Models");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BrandId).HasColumnName("BrandId");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
            this.Property(t => t.Price).HasColumnName("Price");
        }
    }
}