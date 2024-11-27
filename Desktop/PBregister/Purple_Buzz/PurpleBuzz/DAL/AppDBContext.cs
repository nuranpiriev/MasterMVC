using PurpleBuzz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PurpleBuzz.DAL
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
    }
}
