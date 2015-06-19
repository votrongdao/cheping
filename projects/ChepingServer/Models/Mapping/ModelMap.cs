// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:16 PM
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

            this.Property(t => t.Brand)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Series)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Modeling)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Models");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Brand).HasColumnName("Brand");
            this.Property(t => t.Series).HasColumnName("Series");
            this.Property(t => t.Modeling).HasColumnName("Modeling");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Available).HasColumnName("Available");
        }
    }
}