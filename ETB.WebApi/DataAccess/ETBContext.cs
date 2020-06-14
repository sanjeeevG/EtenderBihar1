using ETB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApi.DataAccess
{
    public class ETBContext : DbContext
    {

        public DbSet<UserInfo> UserInfos { get; set;}
        public DbSet<UserSignInLog> UserSignInLogs { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderDoc> TenderDocs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        public DbSet<ExternalContact> ExternalContacts { get; set; }


        public ETBContext(DbContextOptions<ETBContext> options) : base(options)
        {
            
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);

            //Service Validation
            modelBuilder.Entity<Service>().HasIndex(x => x.Name).IsUnique();


            //UserInfo Validation
            modelBuilder.Entity<UserInfo>().HasIndex(x => x.UserId).IsUnique();

            //UserDetai
            //modelBuilder.Entity<UserDetail>().HasOne(x => x.UserInfo);

            #region OnStateCreation
            modelBuilder.Entity<State>().HasData(DbInitializer.GetStateSeed());
            #endregion

            #region OnDistrictCreation
            modelBuilder.Entity<District>().HasData(DbInitializer.GetDistrictsSeed());
            #endregion

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // base.OnConfiguring(optionsBuilder);
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("ETBContext");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }

        //}
    }
}
