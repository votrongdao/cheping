// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:50 AM
// ***********************************************************************
// <copyright file="TranscationRecordMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     TranscationRecordMap.
    /// </summary>
    public class TranscationRecordMap : EntityTypeConfiguration<TranscationRecord>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TranscationRecordMap" /> class.
        /// </summary>
        public TranscationRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
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