using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utils;
using System;

namespace Models
{
    public class ApplicationDbContext : DbContext
    {
        private ILogger logger = AppLoggerFactory.GetLogger("ApplicationDbContext");

        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationGuest> ReservationGuests { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "app.db");
            logger.LogDebug(String.Format("Set db path to {0}", DbPath));
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}