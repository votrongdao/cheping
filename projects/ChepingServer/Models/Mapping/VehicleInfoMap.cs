// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:20 AM
// ***********************************************************************
// <copyright file="VehicleInfoMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class VehicleInfoMap : EntityTypeConfiguration<VehicleInfo>
    {
        public VehicleInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.BrandName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SeriesName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.LicenseLocation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VehicleLocation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ModifiedContent)
                .IsRequired();

            this.Property(t => t.ModelName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("VehicleInfos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BrandName).HasColumnName("BrandName");
            this.Property(t => t.SeriesName).HasColumnName("SeriesName");
            this.Property(t => t.OuterColor).HasColumnName("OuterColor");
            this.Property(t => t.InnerColor).HasColumnName("InnerColor");
            this.Property(t => t.LicenseLocation).HasColumnName("LicenseLocation");
            this.Property(t => t.LicenseTime).HasColumnName("LicenseTime");
            this.Property(t => t.DisplayMileage).HasColumnName("DisplayMileage");
            this.Property(t => t.VehicleLocation).HasColumnName("VehicleLocation");
            this.Property(t => t.FactoryTime).HasColumnName("FactoryTime");
            this.Property(t => t.CooperationMethod).HasColumnName("CooperationMethod");
            this.Property(t => t.ModifiedContent).HasColumnName("ModifiedContent");
            this.Property(t => t.PsychologicalPrice).HasColumnName("PsychologicalPrice");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
        }
    }
}