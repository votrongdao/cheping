// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:14 PM
// ***********************************************************************
// <copyright file="TranscationRecordMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class TranscationRecordMap : EntityTypeConfiguration<TranscationRecord>
    {
        public TranscationRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Location)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("TranscationRecords");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BrandId).HasColumnName("BrandId");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Mileage).HasColumnName("Mileage");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Time).HasColumnName("Time");
        }
    }
}