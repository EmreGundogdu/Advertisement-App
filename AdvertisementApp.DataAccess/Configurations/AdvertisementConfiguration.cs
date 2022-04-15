using AdvertisementApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.CreatedTime).HasDefaultValue(DateTime.Now); //default olarak değer oluşturur.
        }
    }
}
