using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Labb_T2.Models
{
    public class Labb_T2Context : DbContext
    {
        public Labb_T2Context (DbContextOptions<Labb_T2Context> options)
            : base(options)
        {
        }

        public DbSet<Labb_T2.Models.Product> Product { get; set; }
    }
}
