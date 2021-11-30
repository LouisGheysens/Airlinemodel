using AirLineModelClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineModelClassLibrary {
    public class AirLineContext: DbContext {

        public DbSet<Airline> AirLines { get; set; }

        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<CabinMember> CabinMembers { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<PassengerInfo> PassengerInfos { get; set; }

        public DbSet<Pilot> Pilots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(@"Data Source=DESKTOP-3CJB43N\SQLEXPRESS;Initial Catalog=AirlineDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Flight>().HasOne(f => f.Piloot).WithMany(p => p.VluchtenPiloot);
            builder.Entity<Flight>().HasOne(f => f.CoPiloot).WithMany(p => p.VluchtenCoPiloot);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
