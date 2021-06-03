using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecullumInfraWeb.Models
{
    public class SecullumInfraWebContext : DbContext
    {
        public SecullumInfraWebContext (DbContextOptions<SecullumInfraWebContext> options)
            : base(options)
        {
        }

        public DbSet<SecullumInfraWeb.Models.Hardware> Hardware { get; set; }
    }
}
