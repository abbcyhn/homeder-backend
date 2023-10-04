using Domain.Entities;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Configs;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddProvider(new FileLoggerProvider(@"..\Persistence\logs.txt"));
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseUpperSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new CountryCodeConfig());
            modelBuilder.ApplyConfiguration(new CitizenshipConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserEmailConfig());
            modelBuilder.ApplyConfiguration(new UserPhoneConfig());
            modelBuilder.ApplyConfiguration(new UserDetailsConfig());
            modelBuilder.ApplyConfiguration(new UserApartmentConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserTypeConfig());
            modelBuilder.ApplyConfiguration(new UserActionConfig());
            modelBuilder.ApplyConfiguration(new ApartmentConfig());
            modelBuilder.ApplyConfiguration(new ApartmentPriceConfig());
            modelBuilder.ApplyConfiguration(new ApartmentPhotoConfig());
            modelBuilder.ApplyConfiguration(new ApartmentGeneralDetailConfig());
            modelBuilder.ApplyConfiguration(new ApartmentEquipmentDetailConfig());
            modelBuilder.ApplyConfiguration(new ApartmentSecurityDetailConfig());
            modelBuilder.ApplyConfiguration(new ApartmentMediaDetailConfig());
            modelBuilder.ApplyConfiguration(new ApartmentAdditionalDetailConfig());
            modelBuilder.ApplyConfiguration(new ApartmentTenantDetailConfig());
        }
    }
}
