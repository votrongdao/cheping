// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:18 PM
// ***********************************************************************
// <copyright file="OutletMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class OutletMap : EntityTypeConfiguration<Outlet>
    {
        public OutletMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OutletName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ProvinceName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CityName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Contact)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Cellphone)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Outlets");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OutletName).HasColumnName("OutletName");
            this.Property(t => t.ProvinceName).HasColumnName("ProvinceName");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Cellphone).HasColumnName("Cellphone");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.Available).HasColumnName("Available");
        }
    }
}