using CarWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}