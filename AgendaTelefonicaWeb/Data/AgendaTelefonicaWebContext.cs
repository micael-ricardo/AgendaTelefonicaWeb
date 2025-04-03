using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendaTelefonicaWeb.Models;

namespace AgendaTelefonicaWeb.Data
{
    public class AgendaTelefonicaWebContext : DbContext
    {
        public AgendaTelefonicaWebContext (DbContextOptions<AgendaTelefonicaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Contato> Contato { get; set; } = default!;
        public DbSet<Telefone> Telefone { get; set; } = default!;
    }
}
