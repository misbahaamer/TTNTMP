using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TTNtmp.Models;

namespace TTNtmp.Persistence
{
    public class TTNtmpDbContext : DbContext
    {
        public TTNtmpDbContext(DbContextOptions<TTNtmpDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}