using Fiado.Models;
using Fiado.Models.AtendenteModelos;
using Fiado.Models.ClienteModelos;
using Fiado.Models.NotaModelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado
{
    public class FiadoContexto : IdentityDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Nota> Notas { get; set; }

        public FiadoContexto(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The entity type 'IdentityUserLogin<string>' requires a primary 
            //key to be defined. So we do this at the base.
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Base>();
            modelBuilder.Entity<Pessoa>();

        }
    }
}
