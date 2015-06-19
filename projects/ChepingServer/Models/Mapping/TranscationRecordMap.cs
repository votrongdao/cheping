// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  3:19 AM
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

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("TranscationRecords");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.Mileage).HasColumnName("Mileage");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.LicenseTime).HasColumnName("LicenseTime");
            this.Property(t => t.OuterColor).HasColumnName("OuterColor");
            this.Property(t => t.InnerColor).HasColumnName("InnerColor");
            this.Property(t => t.Source).HasColumnName("Source");
        }
    }
}