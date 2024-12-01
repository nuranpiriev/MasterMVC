using InanceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Metadata;

namespace InanceMVC.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasMany(s => s.Orders)
                .WithOne(s => s.Service)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            
           
            
            modelBuilder.Entity<Master>()
                .HasMany(o=>o.Orders)
                .WithOne(o=>o.Master)
                .HasForeignKey(s => s.MasterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
