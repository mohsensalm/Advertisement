using Advertisement.Entites;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace Advertisement.DBContext
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<UserVideo> UserVideos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configurations can go here if needed
        }
    }
}