// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-18  6:01 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-18  6:14 PM
// ***********************************************************************
// <copyright file="UserMap.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity.ModelConfiguration;

namespace ChepingServer.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserCode)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Cellphone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserCode).HasColumnName("UserCode");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.OutletId).HasColumnName("OutletId");
            this.Property(t => t.JobTitle).HasColumnName("JobTitle");
            this.Property(t => t.Cellphone).HasColumnName("Cellphone");
            this.Property(t => t.Password).HasColumnName("Password");
        }
    }
}