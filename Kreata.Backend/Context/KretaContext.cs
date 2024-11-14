
using Kreta.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public class KretaContext : DbContext
    {
        private DbSet<Student> _students;
        private DbSet<Teacher> _teachers;
        private DbSet<Player> _players;
        private DbSet<Club> _clubs;
        private DbSet<User> _users;

        public KretaContext(DbContextOptions<KretaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
