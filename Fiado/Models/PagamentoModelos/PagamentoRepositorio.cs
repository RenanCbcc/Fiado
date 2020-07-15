using Fiado.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        IQueryable<Pagamento> Buscar(PagamentoBuscaViewModel modelo);
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

        public IQueryable<Pagamento> Buscar(PagamentoBuscaViewModel modelo)
        {
            var query = "SELECT * FROM Pagamentos WHERE ";
            
            if (modelo.Atendente != null)
            {
                query += "Atendente = @p0 AND ";
            }
            if (modelo.MenorQue != null)
            {
                query += "Valor <= @p1 AND ";
            }
            if (modelo.MaiorQue != null)
            {
                query += "Valor >= @p2 AND ";
            }
            if (modelo.Data != null)
            {
                query += "[Data] <= @p3 AND ";
            }
            query += "1 = 1";
            return contexto.Pagamentos.FromSql(query, modelo.Atendente, modelo.MenorQue, modelo.MaiorQue, modelo.Data);
        }
    }
}
