#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elektronika.Models;

namespace Elektronika.Data
{
    public class ElektronikaContext : DbContext
    {
        public ElektronikaContext (DbContextOptions<ElektronikaContext> options)
            : base(options)
        {
        }

        public DbSet<Elektronika.Models.Alkatresz> Alkatresz { get; set; }
    }
}
