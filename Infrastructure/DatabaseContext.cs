using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using MySql.Data.MySqlClient;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;

using TheaterBackend.Domain.Models;

namespace TheaterBackend.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Screening> Screenings => Set<Screening>();
        public DbSet<Screen> Screens => Set<Screen>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<Showcase> Showcases => Set<Showcase>();
        public DbSet<Theater> Theaters => Set<Theater>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
    }
}
