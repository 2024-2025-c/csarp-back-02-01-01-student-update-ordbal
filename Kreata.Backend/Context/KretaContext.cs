using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Kreata.Backend.Context
{
    public class KretaContext : DbContext
    {
        private DbSet<Student> _students;
        private DbSet<Teacher> _teachers;
        private DbSet<Player> _players;

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
    }
}
