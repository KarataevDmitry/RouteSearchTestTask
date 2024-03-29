﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using TaskSolution.DAL.Data.ContextConfigurations;
using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        [
            UseSorting,
            UseFiltering
        ]
        public DbSet<TravelRoute> TravelRoutes { get; set; }
        
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        
            modelBuilder.ApplyConfiguration(new TravelRouteContextConfiguration());
            
        }
    }
}