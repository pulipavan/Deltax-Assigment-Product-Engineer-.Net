using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.producer)
                .WithMany()
                .HasForeignKey(m => m.producer_id)
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<MovieGallery>()
                .HasOne(mg => mg.movie)
                .WithMany(m => m.movie_galleries)
                .HasForeignKey(mg => mg.movie_id);

            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.movie_id, ma.actor_id });
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.movie)
                .WithMany(m => m.movieactors)
                .HasForeignKey(ma => ma.movie_id);
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.actor)
                .WithMany(a => a.movieactors)
                .HasForeignKey(ma => ma.actor_id);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<MovieGallery> Movie_galleries { get; set; }
    }
}
