// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-27  8:07 PM
// ***********************************************************************
// <copyright file="VehicleInspectionMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     VehicleInspectionMap.
    /// </summary>
    public class VehicleInspectionMap : EntityTypeConfiguration<VehicleInspection>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VehicleInspectionMap" /> class.
        /// </summary>
        public VehicleInspectionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.VinCode)
                .HasMaxLength(200);

            this.Property(t => t.EngineCode)
                .HasMaxLength(200);

            this.Property(t => t.InsuranceCode)
                .HasMaxLength(200);

            this.Property(t => t.LicenseCode)
                .HasMaxLength(200);

            this.Property(t => t.ConservationNote)
                .HasMaxLength(200);

            this.Property(t => t.ClaimNote)
                .HasMaxLength(200);

            this.Property(t => t.BondsNote)
                .HasMaxLength(200);

            this.Property(t => t.ViolationNote)
                .HasMaxLength(200);

            this.Property(t => t.VehicleOwner)
                .HasMaxLength(50);

            this.Property(t => t.VehicleOwnerCellphone)
                .HasMaxLength(20);

            this.Property(t => t.VehicleOwnerBank)
                .HasMaxLength(50);

            this.Property(t => t.VehicleOwnerBankCardNo)
                .HasMaxLength(50);

            this.Property(t => t.VehicleOwnerIdNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleInspections");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VinCode).HasColumnName("VinCode");
            this.Property(t => t.EngineCode).HasColumnName("EngineCode");
            this.Property(t => t.InsuranceCode).HasColumnName("InsuranceCode");
            this.Property(t => t.LicenseCode).HasColumnName("LicenseCode");
            this.Property(t => t.RealMileage).HasColumnName("RealMileage");
            this.Property(t => t.LastConservationTime).HasColumnName("LastConservationTime");
            this.Property(t => t.ConservationState).HasColumnName("ConservationState");
            this.Property(t => t.ConservationNote).HasColumnName("ConservationNote");
            this.Property(t => t.ClaimState).HasColumnName("ClaimState");
            this.Property(t => t.ClaimNote).HasColumnName("ClaimNote");
            this.Property(t => t.BondsState).HasColumnName("BondsState");
            this.Property(t => t.BondsNote).HasColumnName("BondsNote");
            this.Property(t => t.ViolationState).HasColumnName("ViolationState");
            this.Property(t => t.ViolationNote).HasColumnName("ViolationNote");
            this.Property(t => t.PreferentialPrice).HasColumnName("PreferentialPrice");
            this.Property(t => t.MaxMileage).HasColumnName("MaxMileage");
            this.Property(t => t.MinMileage).HasColumnName("MinMileage");
            this.Property(t => t.SaleGrade).HasColumnName("SaleGrade");
            this.Property(t => t.WebAveragePrice).HasColumnName("WebAveragePrice");
            this.Property(t => t.WebPrice).HasColumnName("WebPrice");
            this.Property(t => t.FloorPrice).HasColumnName("FloorPrice");
            this.Property(t => t.VehicleOwner).HasColumnName("VehicleOwner");
            this.Property(t => t.VehicleOwnerCellphone).HasColumnName("VehicleOwnerCellphone");
            this.Property(t => t.VehicleOwnerBank).HasColumnName("VehicleOwnerBank");
            this.Property(t => t.VehicleOwnerBankCardNo).HasColumnName("VehicleOwnerBankCardNo");
            this.Property(t => t.VehicleOwnerIdNo).HasColumnName("VehicleOwnerIdNo");
        }
    }
}