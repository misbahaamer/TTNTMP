using System.Collections.Generic;
using System.Collections;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using TTNtmp.Persistence;
using TTNtmp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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