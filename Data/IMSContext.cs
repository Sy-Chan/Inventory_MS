using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_MS.Models;

namespace Inventory_MS.Data
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> options)
            : base(options)
        {

        }

        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Inventory_MS.Models.Type> Type { get; set; }
        public DbSet<RepairRecord> RepairRecords { get; set; }
    }
}
