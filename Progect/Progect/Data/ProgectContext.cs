using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progect.Models;

namespace Progect.Data
{
    public class ProgectContext : DbContext
    {
        public ProgectContext (DbContextOptions<ProgectContext> options)
            : base(options)
        {
        }

        public DbSet<Progect.Models.Documents> Documents { get; set; } = default!;

        public DbSet<Progect.Models.FunctionalArea> FunctionalArea { get; set; }

        public DbSet<Progect.Models.Images> Images { get; set; }

        public DbSet<Progect.Models.Role> Role { get; set; }

        public DbSet<Progect.Models.Sections> Sections { get; set; }

        public DbSet<Progect.Models.Structures> Structures { get; set; }

        public DbSet<Progect.Models.Types> Types { get; set; }

        public DbSet<Progect.Models.Users> Users { get; set; }
    }
}
