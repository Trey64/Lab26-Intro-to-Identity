using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab26Tom.Models
{
    public class Lab26TomContext : DbContext
    {
        public Lab26TomContext (DbContextOptions<Lab26TomContext> options)
            : base(options)
        {
        }

        public DbSet<Lab26Tom.Models.LFG> LFG { get; set; }
    }
}
