using AdvertisementApp.DataAccess.Configurations;
using AdvertisementApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementApp.DataAccess.Context
{
    public class AdvertiesmentContext : DbContext
    {
        public AdvertiesmentContext(DbContextOptions<AdvertiesmentContext> options) : base(options)
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<ProvidedServices> ProvidedServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdverstisementAppUserStatusConfigration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }
    }
}
