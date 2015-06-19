// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  3:15 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  10:04 AM
// ***********************************************************************
// <copyright file="ChePingContext.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity;
using ChepingServer.Models.Mapping;
using Moe.EntityFramework;

namespace ChepingServer.Models
{
    public class ChePingContext : DbContextBase
    {
        static ChePingContext()
        {
            Database.SetInitializer<ChePingContext>(null);
        }

        public ChePingContext()
            : base("Name=ChePingContext")
        {
        }

        public DbSet<Case> Cases { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Outlet> Outlets { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<TranscationRecord> TranscationRecords { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<VehicleInfo> VehicleInfos { get; set; }

        public DbSet<VehicleInspection> VehicleInspections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaseMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new OutletMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new TranscationRecordMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new VehicleInfoMap());
            modelBuilder.Configurations.Add(new VehicleInspectionMap());
        }
    }
}