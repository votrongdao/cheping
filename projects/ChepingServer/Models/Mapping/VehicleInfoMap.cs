// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  7:33 PM
// ***********************************************************************
// <copyright file="VehicleInfoMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     VehicleInfoMap.
    /// </summary>
    public class VehicleInfoMap : EntityTypeConfiguration<VehicleInfo>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VehicleInfoMap" /> class.
        /// </summary>
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

            this.Property(t => t.ModifiedContent)
                .IsRequired();

            this.Property(t => t.ModelName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.OuterColorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.InnerColorName)
                .IsRequired()
                .HasMaxLength(50);

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
            this.Property(t => t.ExpectedPrice).HasColumnName("ExpectedPrice");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
            this.Property(t => t.OuterColorName).HasColumnName("OuterColorName");
            this.Property(t => t.InnerColorName).HasColumnName("InnerColorName");
        }
    }
}