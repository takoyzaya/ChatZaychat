using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatZaychatAPI.Models
{
    public class MainContext : DbContext
    {
        private static bool _created = false;
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
            if (!_created)
            {
                Database.Migrate();
                _created = true;
            }
        }


        public DbSet<ChatZaychatAPI.Models.Message> Message { get; set; }
        public DbSet<ChatZaychatAPI.Models.UserContacts> UserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserContacts>()
                .Property<string>("ExtendedDataStr")
                .HasField("_extendedData");
        }
    }
}
