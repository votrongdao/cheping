// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:17 AM
// ***********************************************************************
// <copyright file="CaseMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class CaseMap : EntityTypeConfiguration<Case>
    {
        public CaseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SerialId)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AbandonReason)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Cases");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SerialId).HasColumnName("SerialId");
            this.Property(t => t.PurchasePrice).HasColumnName("PurchasePrice");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.VehicleInfoId).HasColumnName("VehicleInfoId");
            this.Property(t => t.VehicleInspecId).HasColumnName("VehicleInspecId");
            this.Property(t => t.PurchaserId).HasColumnName("PurchaserId");
            this.Property(t => t.ValuerId).HasColumnName("ValuerId");
            this.Property(t => t.QueryingId).HasColumnName("QueryingId");
            this.Property(t => t.DirectorId).HasColumnName("DirectorId");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            this.Property(t => t.Abandon).HasColumnName("Abandon");
            this.Property(t => t.AbandonReason).HasColumnName("AbandonReason");
            this.Property(t => t.OutletId).HasColumnName("OutletId");
            this.Property(t => t.CaseType).HasColumnName("CaseType");
        }
    }
}