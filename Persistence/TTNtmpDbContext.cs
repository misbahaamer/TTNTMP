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
        public TTNtmpDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<VendorClient> VendorClients { get; set; }
        public DbSet<CandidateFeedBack> CandidateFeedBacks { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<VendorHours> VendorHours { get; set; }
        public DbSet<EmployeeCard> EmployeeCards { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VendorPositionStatus> VendorPositionStatuses { get; set; }
        public DbSet<VendorPosition> VendorPositions { get; set; }
        public DbSet<Holds> Holds { get; set; }

    }
    
        
    
}