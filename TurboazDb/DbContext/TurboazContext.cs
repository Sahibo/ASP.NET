using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TurboazDb.DataAccess.DbContext;

public class TurboazContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Showroom> Showrooms { get; set; }
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<WheelDriveType> WheelDriveTypes { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<TransmissionType> TransmissionTypes { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Cars to Showrooms (one-to-many)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.Showroom)
            .WithMany()
            .HasForeignKey(c => c.ShowRoomId);

        // Cars to BodyTypes (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.BodyType)
            .WithMany()
            .HasForeignKey(c => c.BodyTypeID);

        // Cars to Cities (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.City)
            .WithMany()
            .HasForeignKey(c => c.CityID);

        // Cars to Colors (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.Color)
            .WithMany()
            .HasForeignKey(c => c.ColorID);

        // Cars to WheelDriveTypes (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.WheelDriveType)
            .WithMany()
            .HasForeignKey(c => c.WheelDriveTypeID);

        // Cars to FuelTypes (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.FuelType)
            .WithMany()
            .HasForeignKey(c => c.FuelTypeID);

        // Cars to TransmissionTypes (many-to-one)
        modelBuilder.Entity<Car>()
            .HasRequired(c => c.TransmissionType)
            .WithMany()
            .HasForeignKey(c => c.TransmissionTypeID);

        // Other configurations, if any...

        base.OnModelCreating(modelBuilder);
    }
}