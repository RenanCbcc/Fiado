using Fiado.Models.ClienteModelos;
using Fiado.Models.ContaModelos;
using Fiado.Models.NotaModelos;
using Fiado.Models.PagamentoModelos;
using Microsoft.EntityFrameworkCore;

namespace Fiado
{
    public class FiadoContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }


        public FiadoContexto(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The entity type 'IdentityUserLogin<string>' requires a primary 
            //key to be defined. So we do this at the base.
            base.OnModelCreating(modelBuilder);
                                    

        }
    }
}
