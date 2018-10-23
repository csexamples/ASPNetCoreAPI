using System;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Entities
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
    }
}
