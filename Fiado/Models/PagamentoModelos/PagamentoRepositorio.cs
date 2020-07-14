using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiado.Models.PagamentoModelos
{
    public interface IPagamentoRepositorio
    {
        Task<Pagamento> GetPagamento(int Id);
        IQueryable<Pagamento> Pagamentos();
        Task Adicionar(Pagamento pagamento);

    }


    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly FiadoContexto contexto;

        public PagamentoRepositorio(FiadoContexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Pagamento pagamento)
        {
            await contexto.Pagamentos.AddAsync(pagamento);
            await contexto.SaveChangesAsync();
        }

        public IQueryable<Pagamento> Pagamentos()
        {
            return contexto.Pagamentos;
        }

        public async Task<Pagamento> GetPagamento(int Id)
        {
            return await contexto.Pagamentos.FindAsync(Id);
        }
    }
}
