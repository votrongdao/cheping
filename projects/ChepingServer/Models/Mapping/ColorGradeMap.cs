// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:48 AM
// ***********************************************************************
// <copyright file="ColorGradeMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    /// <summary>
    ///     ColorGradeMap.
    /// </summary>
    public class ColorGradeMap : EntityTypeConfiguration<ColorGrade>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ColorGradeMap" /> class.
        /// </summary>
        public ColorGradeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.GoodColors)
                .IsRequired();

            this.Property(t => t.MiddleColors)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ColorGrade");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.GoodColors).HasColumnName("GoodColors");
            this.Property(t => t.MiddleColors).HasColumnName("MiddleColors");
        }
    }
}