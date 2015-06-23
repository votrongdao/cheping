// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:46 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  3:56 AM
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
    /// <summary>
    ///     ChePingContext.
    /// </summary>
    public class ChePingContext : DbContextBase
    {
        /// <summary>
        ///     Initializes static members of the <see cref="ChePingContext" /> class.
        /// </summary>
        static ChePingContext()
        {
            Database.SetInitializer<ChePingContext>(null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChePingContext" /> class.
        /// </summary>
        public ChePingContext()
            : base("Name=ChePingContext")
        {
        }

        /// <summary>
        ///     Gets or sets the cases.
        /// </summary>
        /// <value>The cases.</value>
        public DbSet<Case> Cases { get; set; }

        /// <summary>
        ///     Gets or sets the cities.
        /// </summary>
        /// <value>The cities.</value>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        ///     Gets or sets the color grades.
        /// </summary>
        /// <value>The color grades.</value>
        public DbSet<ColorGrade> ColorGrades { get; set; }

        /// <summary>
        ///     Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public DbSet<Color> Colors { get; set; }

        /// <summary>
        ///     Gets or sets the models.
        /// </summary>
        /// <value>The models.</value>
        public DbSet<Model> Models { get; set; }

        /// <summary>
        ///     Gets or sets the outlets.
        /// </summary>
        /// <value>The outlets.</value>
        public DbSet<Outlet> Outlets { get; set; }

        /// <summary>
        ///     Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        public DbSet<Photo> Photos { get; set; }

        /// <summary>
        ///     Gets or sets the transcation records.
        /// </summary>
        /// <value>The transcation records.</value>
        public DbSet<TranscationRecord> TranscationRecords { get; set; }

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle infos.
        /// </summary>
        /// <value>The vehicle infos.</value>
        public DbSet<VehicleInfo> VehicleInfos { get; set; }

        /// <summary>
        ///     Gets or sets the vehicle inspections.
        /// </summary>
        /// <value>The vehicle inspections.</value>
        public DbSet<VehicleInspection> VehicleInspections { get; set; }

        /// <summary>
        ///     Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaseMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new ColorGradeMap());
            modelBuilder.Configurations.Add(new ColorMap());
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