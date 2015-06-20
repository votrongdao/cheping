// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-20  12:50 PM
// ***********************************************************************
// <copyright file="PhotoMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     PhotoMap.
    /// </summary>
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhotoMap" /> class.
        /// </summary>
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Content)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Photos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CaseId).HasColumnName("CaseId");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.UploadTime).HasColumnName("UploadTime");
        }
    }
}